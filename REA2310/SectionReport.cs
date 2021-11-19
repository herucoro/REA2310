using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

using GrapeCity.ActiveReports.SectionReportModel;
using RyoeiSystem.Database.Models;

namespace REA2300
{

    /// <summary>
    /// SectionReport の概要の説明です。
    /// </summary>
    public partial class SectionReport : GrapeCity.ActiveReports.SectionReport
    {
        public SectionReport(List<string> date, List<BankModel> banks)
        {
            //
            // デザイナー サポートに必要なメソッドです。
            //
            InitializeComponent();

            int count = 0;
            int[] colSum = new int[8];

            foreach (var d in date)
            {
                ((TextBox)this.pageHeader.Controls["dateHeader" + count.ToString()]).Text = 
                                                            d.Substring(2,2) + "/" + d.Substring(4,2);

                if (date.Count() <= count + 1)
                {
                    ((TextBox)this.pageHeader.Controls["dateHeader" + count.ToString()]).Text += "以降";
                }
                count++;
            }

            count = 0;
            int col = 0;

            foreach (var bank in banks)
            {
                ((TextBox)this.reportFooter1.Controls["bankName" + count.ToString()]).Text = bank.bankName;

                col = 0;
                foreach (var payment in bank.payment)
                {
                    ((TextBox)this.reportFooter1.Controls["amount" + count.ToString() + col.ToString()]).Text = 
                                                            ((int)payment.amount).ToString("#,0");

                    colSum[col] += ((int)payment.amount);
                    col++;
                }
                ((TextBox)this.reportFooter1.Controls["rowSum" + count.ToString()]).Text = ((int)bank.payment
                                                                                            .Select(x => x.amount)
                                                                                            .Sum()).ToString("#,0");
                colSum[col] += (int)bank.payment.Select(x => x.amount).Sum();
                count++;
            }
            
            for (int i = 0; i < col+1; i++)
            {
                ((TextBox)this.reportFooter1.Controls["colSum" + i.ToString()]).Text = colSum[i].ToString("#,0");
            }
        }
    }
}
