using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

using RyoeiSystem.Common;
using RyoeiSystem.SecretData;
using RyoeiSystem.Database.Common;
using RyoeiSystem.Database.Models;

namespace RyoeiSystem.Database.Controllers
{
    class Controller
    {
        private string startDate;
        private List<string> date;
        private List<MACModel> MAC;
        private List<MALModel> MAL;
        private List<TECModel> TEC;
        private List<BankModel> bank;
        private List<MoneyDateModel> payment;

        private string filePath;
        public Controller(string date, string filePath)
        {
            this.startDate = date.Replace("/", "");
            DateTime dTime = DateTime.Parse(date);

            this.date = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                this.date.Add(dTime.AddMonths(i).ToString("yyyyMM"));
            }

            this.filePath = filePath;
        }

        public List<string> GetDate()
        {
            return date;
        }

        public List<BankModel> GetBank()
        {
            return bank;
        }

        public void CreateData()
        {
            string sql;
            
            using (var connection = new SqlConnection(Secret.connectionString))
            {
                connection.Open();

                // 項目名をMACから取得する
                sql = @"SELECT MACNAIBU, MACNNAME  
                        FROM MAC
                        WHERE MACKUBUN = @KUBUN
                        ORDER BY MACNAIBU
                        ;";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Clear();
                    DatabaseCommon.AddSqlParameter(command, "@KUBUN", SqlDbType.NChar, (object)"050");

                    using (var dataReader = command.ExecuteReader())
                    {
                        MAC = new List<MACModel>();

                        // MACのデータを取得
                        while (dataReader.Read())
                        {
                            MAC.Add(new MACModel() { MACNAIBU = (string)dataReader["MACNAIBU"], MACNNAME = (string)dataReader["MACNNAME"] });
                        }
                    }
                }

                // 入金データをTECから取得する
                sql = @"SELECT TECSEICOD, TECMEISYO, TECNYUSYU, TECTEGDAT, SUM(TECKINGAK) AS summary, TECBANKCD 
                        FROM TEC
                        WHERE TECTEGDAT >= @Date
                        AND (TECNYUSYU = 3
                        OR TECNYUSYU = 5
                        OR TECNYUSYU = 6
                        OR TECNYUSYU = 7)
                        GROUP BY TECSEICOD, TECMEISYO, TECNYUSYU, TECTEGDAT, TECBANKCD
                        ;";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Clear();
                    DatabaseCommon.AddSqlParameter(command, "@Date", SqlDbType.Int, (Object)startDate);

                    using (var dataReader = command.ExecuteReader())
                    {
                        TEC = new List<TECModel>();

                        while (dataReader.Read())
                        {
                            TEC.Add(new TECModel() { TECSEICOD = (Int16)dataReader["TECSEICOD"], TECMEISYO = (string)dataReader["TECMEISYO"],
                                TECNYUSYU = (string)dataReader["TECNYUSYU"], TECTEGDAT = (Int32)dataReader["TECTEGDAT"],
                                TECKINGAK = (double)dataReader["summary"], TECBANKCD = (Int16)dataReader["TECBANKCD"] });
                        }
                    }
                }

                foreach (var value in TEC)
                {
                    // 計上日のデータをyyyyMMに変換
                    value.TECTEGDAT = (int)(value.TECTEGDAT / 100) > int.Parse(date.Last()) ? 
                                            int.Parse(date.Last()): (int)(value.TECTEGDAT / 100);
                }

                var query = TEC.OrderBy(x => x.TECSEICOD).ThenBy(x => x.TECNYUSYU)
                            .GroupBy(x => new { TECSEICOD = x.TECSEICOD, TECMEISYO = x.TECMEISYO, TECNYUSYU = x.TECNYUSYU, TECTEGDAT = x.TECTEGDAT })
                            .Select(x => new { Key = x.Key, Sum = x.Sum(y => y.TECKINGAK) });

                int seicod = 0;
                string meisyo = "";
                string nyusyu = "";                
                foreach (var value in query)
                {                    
                    if (seicod == 0 || meisyo == "" || nyusyu == "")
                    {
                        seicod = value.Key.TECSEICOD;
                        meisyo = value.Key.TECMEISYO;
                        nyusyu = value.Key.TECNYUSYU;
                    }
                    else
                    {
                        if (seicod == value.Key.TECSEICOD && meisyo == value.Key.TECMEISYO && nyusyu == value.Key.TECNYUSYU)
                        {
                            continue;
                        }
                        else
                        {
                            seicod = value.Key.TECSEICOD;
                            meisyo = value.Key.TECMEISYO;
                            nyusyu = value.Key.TECNYUSYU;
                        }
                    }

                    var data = query
                                .OrderBy(x => x.Key.TECTEGDAT)
                                .Where(x => x.Key.TECSEICOD == seicod && x.Key.TECNYUSYU == nyusyu)
                                .ToList();

                    StreamWriter file = new StreamWriter(filePath, true, Encoding.UTF8);
                    file.Write("{0},{1},", seicod.ToString() + ":" + meisyo, nyusyu + ":" +
                                            MAC.First(x => x.MACNAIBU == nyusyu).MACNNAME);

                    foreach (var d in date)
                    {
                        // csvファイルに金額を書き込む
                        file.Write("{0},", data.Any(x => x.Key.TECTEGDAT == long.Parse(d)) ? 
                                        data.First(x => x.Key.TECTEGDAT == long.Parse(d)).Sum : 0);
                    }


                    file.Write("{0},", data.Sum(x => x.Sum));
                    file.WriteLine();
                    file.Close();
                }

                // 会社ごとの入金金額生成終了

                // 銀行の各月データ生成

                sql = @"SELECT MALGNCODE, MALGNNAMK 
                        FROM MAL 
                        ;";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Clear();

                    using (var dataReader = command.ExecuteReader())
                    {
                        MAL = new List<MALModel>();

                        while (dataReader.Read())
                        {
                            MAL.Add(new MALModel()
                            {
                                MALGNCODE = (Int16)dataReader["MALGNCODE"],
                                MALGNNAMK = (string)dataReader["MALGNNAMK"]
                            });
                        }
                    }
                }

                var bankQuery = TEC.OrderByDescending(x => x.TECBANKCD).ThenBy(x => x.TECTEGDAT)
                            .GroupBy(x => new { TECBANKCD = x.TECBANKCD, TECTEGDAT = x.TECTEGDAT })
                            .Select(x => new { Key = x.Key, Sum = x.Sum(y => y.TECKINGAK) })
                            .ToList();

                bank = new List<BankModel>();
                
                // TECBANKCDが0の時、MALに存在しないことを考慮                
                foreach (var bankData in bankQuery)
                {
                    if (!bank.Any(x => x.bankCode == bankData.Key.TECBANKCD))
                    {
                        var data = bankQuery
                                    .OrderBy(x => x.Key.TECTEGDAT)
                                    .Where(x => x.Key.TECBANKCD == bankData.Key.TECBANKCD)
                                    .ToList();

                        payment = null;
                        payment = new List<MoneyDateModel>();
                        foreach (var d in date)
                        {
                            if (data.Any(x => x.Key.TECTEGDAT == long.Parse(d))) {
                                payment.Add(new MoneyDateModel()
                                {
                                    amount = data.First(x => x.Key.TECTEGDAT == long.Parse(d)).Sum,
                                    paymentDay = d
                                });
                            }
                            else
                            {
                                payment.Add(new MoneyDateModel()
                                {
                                    amount = 0,
                                    paymentDay = d
                                });
                            }
                        }

                        bank.Add(new BankModel()
                        {
                            bankCode = data.First().Key.TECBANKCD,
                            bankName = MAL.Any(x => x.MALGNCODE == data.First().Key.TECBANKCD) ?
                                                MAL.First(x => x.MALGNCODE == data.First().Key.TECBANKCD).MALGNNAMK : "その他",
                            payment = this.payment
                        });
                    }
                }

                connection.Close();
            }
        }
    }
}
