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

using REA2310.Models;

namespace RyoeiSystem.Database.Controllers
{
    class Controller
    {
        private string startDate;
        /// <summary>
        /// yyyyMM
        /// </summary>
        private List<string> date;
        private List<MACModel> MAC;
        private List<MALModel> MAL;
        private List<TECModel> TEC;
        private List<BankModel> bank;
        private List<MoneyDateModel> payment;
        //private List<PrintModel>[] printModels;
        private MainFormModel formData;

        private string filePath;
        public Controller(MainFormModel formData, string filePath)
        {
            // MainFormのデータを設定
            this.formData = formData;
            this.startDate = formData.date.Replace("/", "");
            DateTime dTime = DateTime.Parse(formData.date);

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

                // 項目名をMAC(共通マスタ)から取得する
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

                        // 区分マスタ(MAC)のデータを取得
                        while (dataReader.Read())
                        {
                            MAC.Add(new MACModel() 
                            {                                 
                                MACNAIBU = (string)dataReader["MACNAIBU"],  // 内部コード
                                MACNNAME = (string)dataReader["MACNNAME"]   // 内部名称
                            });
                        }
                    }
                }

                // 指定年月/01以降のデータを抽出
                sql = @"SELECT TECSEICOD, TECMEISYO, TECNYUSYU, TECTEGDAT, TECKINGAK, TECBANKCD 
                        FROM TEC 
                        WHERE TECTEGDAT >= @Date 
                        AND ";
                int count = 0;
                if (formData.paymentAll)
                {
                    sql += @"(";
                    foreach (var dic in MainFormModel.kindsPayment)
                    {
                        sql += @"TECNYUSYU = " + dic.Value;
                        count++;

                        if (count < MainFormModel.kindsPayment.Count) sql += " OR ";
                    }
                }
                else
                {
                    sql += @"(TECNYUSYU <> 0 AND TECNYUSYU <> 1 AND TECNYUSYU <> 2 AND TECNYUSYU <> 4) AND (";
                    foreach (var dic in MainFormModel.kindsPayment)
                    {
                        if (formData.selectedPayment[dic.Value])
                        {
                            sql += @"TECNYUSYU = " + dic.Value;
                            if (count < MainFormModel.kindsPayment.Count) sql += " OR ";
                        }                            
                        count++;                        
                    }
                }
                if (sql.Substring(sql.Length - 4, 4) == " OR ")
                    // " OR "を除去
                    sql = sql.Substring(0, sql.Length - 4);
                sql += ")";

                if (!formData.bankAll)
                {
                    sql += " AND (";
                    foreach (var dic in MainFormModel.kindsBank)
                    {
                        if (!formData.selectedBank[dic.Value])
                        {
                            sql += @"TECBANKCD <> " + dic.Value;
                            sql += " AND ";
                        }
                    }

                    if (sql.Substring(sql.Length - 5, 5) == " AND ")
                        // " AND "を除去
                        sql = sql.Substring(0, sql.Length - 5);
                        sql += ") ";
                }

                sql += @"ORDER BY TECSEICOD, TECTEGDAT, TECNYUSYU
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
                            TEC.Add(new TECModel()
                            {
                                TECSEICOD = (Int16)dataReader["TECSEICOD"],
                                TECMEISYO = (string)dataReader["TECMEISYO"],
                                TECNYUSYU = (string)dataReader["TECNYUSYU"],
                                TECTEGDAT = (Int32)dataReader["TECTEGDAT"],
                                TECKINGAK = (double)dataReader["TECKINGAK"],
                                TECBANKCD = (Int16)dataReader["TECBANKCD"]
                            });
                        }
                    }
                }

                foreach (var value in TEC)
                {
                    // 計上日のデータをyyyyMMに変換
                    value.yyyyMM = (int)(value.TECTEGDAT / 100) > int.Parse(date.Last()) ?
                                            date.Last() : ((int)(value.TECTEGDAT / 100)).ToString();
                    // yyyyMM : 年月(int型)
                    // dd     : 日(string型)
                    if ((int)(value.TECTEGDAT / 100) > int.Parse(date.Last()))
                    {
                        // 年月の範囲を超える場合は、手形期日を範囲の最終年月とする
                        value.yyyyMM = date.Last();
                        value.dd = ((int)(value.TECTEGDAT / 100)).ToString().Substring(4,2);
                    }
                    else
                    {
                        value.yyyyMM = ((int)(value.TECTEGDAT / 100)).ToString();
                        value.dd = ((int)(value.TECTEGDAT)).ToString().Substring(6, 2);
                    }
                }

                // MainFormで未決裁を選択されていたら、マイナス値は値の絶対値と日付を比較して
                // 存在する場合はマイナスのレコードを無視する(要確認)
                if (!formData.approvalState)
                {
                    // 
                    var copyTEC = TEC.Select((x, i) => new { content = x, index = i })
                                        .Where(x => x.content.TECKINGAK < 0).ToList();
                    copyTEC.Reverse();
                    foreach (var record in copyTEC)
                    {
                        int queryCount = TEC.Where(x => x.TECTEGDAT == record.content.TECTEGDAT)
                                                .Where(x => x.TECKINGAK + record.content.TECKINGAK == 0)
                                                .Count();
                        if (queryCount >= 1)
                        {
                            TEC.RemoveAt(record.index);
                        }
                    }
                }

                // 各月で生成されるレコード件数の最大値を求める
                // 請求先を単一にする
                var query = TEC.OrderBy(x => x.TECSEICOD)
                            .GroupBy(x => new { TECSEICOD = x.TECSEICOD });

                foreach (var group in query)
                {
                    // CSV出力用Listのインスタンスを生成
                    
                    List<PrintModel>[] printModels = new List<PrintModel>[date.Count];

                    int maxRecord = 0;
                    foreach (var ym in date)
                    {
                        // 月ごとで最大件数を求める
                        var recordCount = TEC.Where(x => x.TECSEICOD == group.Key.TECSEICOD)
                                            .Where(x => x.yyyyMM == ym)
                                            .Count();                        
                        maxRecord = recordCount > maxRecord ? recordCount : maxRecord;                        
                    }

                    // 月数分だけList型の配列を生成する
                    for (int i = 0; i < date.Count; i++)
                    {
                        printModels[i] = new List<PrintModel>();

                        // 各配列に最大のListを生成
                        // 入れるデータが無い場合は、空のまま処理する
                        for (int j = 0; j < maxRecord; j++)
                        {
                            printModels[i].Add(new PrintModel()
                            {
                                supplierCode = group.Key.TECSEICOD,
                                supplierName = TEC.First(x => x.TECSEICOD == group.Key.TECSEICOD).TECMEISYO, // 請求先名
                                yyyyMM = date[i],
                                dd = "",
                                amount = "",
                                paymentName = "",
                                bankName = "",
                            });
                        }
                    }

                    for (int i = 0; i < date.Count; i++)
                    {
                        // 請求先の特定の年月で抽出
                        var innerQuery = TEC.OrderBy(x => x.TECTEGDAT)
                                            .Where(x => x.TECSEICOD == group.Key.TECSEICOD)
                                            .Where(x => x.yyyyMM == date[i]);

                        for (int j = 0; j < maxRecord; j++)
                        {
                            // 要素が無い場合は、PrintModels[i][j]は空のまま
                            if (innerQuery.Count() > j)
                            {
                                printModels[i][j].dd = i == date.Count - 1 ? 
                                                            innerQuery.ElementAt(j).TECTEGDAT.ToString().Substring(4, 2):
                                                            innerQuery.ElementAt(j).TECTEGDAT.ToString().Substring(6, 2); // 入金日付
                                printModels[i][j].amount = innerQuery.ElementAt(j).TECKINGAK.ToString();
                                printModels[i][j].paymentName = MainFormModel.kindsPayment
                                                                    .First(x => x.Value.Equals(innerQuery.ElementAt(j).TECNYUSYU)).Key;
                                printModels[i][j].bankName = MainFormModel.kindsBank
                                                                    .First(x => x.Value.Equals(innerQuery.ElementAt(j).TECBANKCD)).Key;
                            }
                        }
                    }

                    // PrintModelsは出来上がった状態
                    // CSV出力処理↓
                    StreamWriter file = new StreamWriter(filePath, true, Encoding.UTF8);
                    for (int i = 0; i < maxRecord; i++)
                    {
                        int sumValue = 0;
                        for (int j = 0; j < date.Count; j++)
                        {
                            if (j == 0)
                            {
                                file.Write("{0},", printModels[j][i].supplierCode.ToString() + ":" +
                                                    printModels[j][i].supplierName);
                            }
                            file.Write("{0},", printModels[j][i].amount);
                            file.Write("{0},", printModels[j][i].dd); // 最終月の場合は月を入れる(要確認)
                            file.Write("{0},", printModels[j][i].paymentName.Length == 0 ? "" : MainFormModel.omitPaymentName[printModels[j][i].paymentName]);
                            file.Write("{0},", printModels[j][i].bankName.Length == 0 ? "" : MainFormModel.omitBankName[printModels[j][i].bankName]);
                            sumValue += printModels[j][i].amount == "" ? 0 : int.Parse(printModels[j][i].amount);
                        }

                        file.Write("{0},", sumValue);
                        file.WriteLine();
                    }
                    file.Close();
                }

                // ↓修正対象↓
                //// 入金データをTECから取得する
                //sql = @"SELECT TECSEICOD, TECMEISYO, TECNYUSYU, TECTEGDAT, SUM(TECKINGAK) AS summary, TECBANKCD 
                //        FROM TEC
                //        WHERE TECTEGDAT >= @Date
                //        AND (TECNYUSYU = 3
                //        OR TECNYUSYU = 5
                //        OR TECNYUSYU = 6
                //        OR TECNYUSYU = 7)
                //        GROUP BY TECSEICOD, TECMEISYO, TECNYUSYU, TECTEGDAT, TECBANKCD
                //        ;";

                //using (var command = new SqlCommand(sql, connection))
                //{
                //    command.Parameters.Clear();
                //    DatabaseCommon.AddSqlParameter(command, "@Date", SqlDbType.Int, (Object)startDate);

                //    using (var dataReader = command.ExecuteReader())
                //    {
                //        TEC = new List<TECModel>();

                //        while (dataReader.Read())
                //        {
                //            TEC.Add(new TECModel() { TECSEICOD = (Int16)dataReader["TECSEICOD"], TECMEISYO = (string)dataReader["TECMEISYO"],
                //                TECNYUSYU = (string)dataReader["TECNYUSYU"], TECTEGDAT = (Int32)dataReader["TECTEGDAT"],
                //                TECKINGAK = (double)dataReader["summary"], TECBANKCD = (Int16)dataReader["TECBANKCD"] });
                //        }
                //    }
                //}

                //foreach (var value in TEC)
                //{
                //    // 計上日のデータをyyyyMMに変換
                //    value.TECTEGDAT = (int)(value.TECTEGDAT / 100) > int.Parse(date.Last()) ? 
                //                            int.Parse(date.Last()): (int)(value.TECTEGDAT / 100);
                //}

                //var query = TEC.OrderBy(x => x.TECSEICOD).ThenBy(x => x.TECNYUSYU)
                //            .GroupBy(x => new { TECSEICOD = x.TECSEICOD, TECMEISYO = x.TECMEISYO, TECNYUSYU = x.TECNYUSYU, TECTEGDAT = x.TECTEGDAT })
                //            .Select(x => new { Key = x.Key, Sum = x.Sum(y => y.TECKINGAK) });

                //int seicod = 0;
                //string meisyo = "";
                //string nyusyu = "";                
                //foreach (var value in query)
                //{                    
                //    if (seicod == 0 || meisyo == "" || nyusyu == "")
                //    {
                //        seicod = value.Key.TECSEICOD;
                //        meisyo = value.Key.TECMEISYO;
                //        nyusyu = value.Key.TECNYUSYU;
                //    }
                //    else
                //    {
                //        if (seicod == value.Key.TECSEICOD && meisyo == value.Key.TECMEISYO && nyusyu == value.Key.TECNYUSYU)
                //        {
                //            continue;
                //        }
                //        else
                //        {
                //            seicod = value.Key.TECSEICOD;
                //            meisyo = value.Key.TECMEISYO;
                //            nyusyu = value.Key.TECNYUSYU;
                //        }
                //    }

                //    var data = query
                //                .OrderBy(x => x.Key.TECTEGDAT)
                //                .Where(x => x.Key.TECSEICOD == seicod && x.Key.TECNYUSYU == nyusyu)
                //                .ToList();

                //    StreamWriter file = new StreamWriter(filePath, true, Encoding.UTF8);
                //    file.Write("{0},{1},", seicod.ToString() + ":" + meisyo, nyusyu + ":" +
                //                            MAC.First(x => x.MACNAIBU == nyusyu).MACNNAME);

                //    foreach (var d in date)
                //    {
                //        // csvファイルに金額を書き込む
                //        file.Write("{0},", data.Any(x => x.Key.TECTEGDAT == long.Parse(d)) ? 
                //                        data.First(x => x.Key.TECTEGDAT == long.Parse(d)).Sum : 0);
                //    }

                //    file.Write("{0},", data.Sum(x => x.Sum));
                //    file.WriteLine();
                //    file.Close();
                //}
                //// 会社ごとの入金金額生成終了

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
                
                //var bankQuery = TEC.OrderByDescending(x => x.TECBANKCD).ThenBy(x => x.TECTEGDAT)
                //            .GroupBy(x => new { TECBANKCD = x.TECBANKCD, TECTEGDAT = x.TECTEGDAT })
                //            .Select(x => new { Key = x.Key, Sum = x.Sum(y => y.TECKINGAK) })
                //            .ToList();
                var bankQuery = TEC.OrderByDescending(x => x.TECBANKCD).ThenBy(x => x.TECTEGDAT)
                            .GroupBy(x => new { TECBANKCD = x.TECBANKCD, yyyyMM = x.yyyyMM })
                            .Select(x => new { Key = x.Key, Sum = x.Sum(y => y.TECKINGAK) })
                            .ToList();
                bank = new List<BankModel>();
                
                // TECBANKCDが0の時、MALに存在しないことを考慮                
                foreach (var bankData in bankQuery)
                {
                    if (!bank.Any(x => x.bankCode == bankData.Key.TECBANKCD))
                    {
                        var data = bankQuery
                                    .OrderBy(x => x.Key.yyyyMM)
                                    .Where(x => x.Key.TECBANKCD == bankData.Key.TECBANKCD)
                                    .ToList();

                        payment = null;
                        payment = new List<MoneyDateModel>();
                        foreach (var d in date)
                        {
                            if (data.Any(x => x.Key.yyyyMM == d)) {
                                payment.Add(new MoneyDateModel()
                                {
                                    amount = data.First(x => x.Key.yyyyMM == d).Sum,
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
