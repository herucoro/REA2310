using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RyoeiSystem.Common;

using REA2310.Models;

namespace REA2310
{
    public partial class MainForm : Form
    {        
        public MainForm()
        {
            InitializeComponent();
            
            this.Text = AssemblyInformation.assemblyTitle 
                        + "(" 
                        + AssemblyInformation.assemblyProduct 
                        + " Ver." 
                        + AssemblyInformation.fileVersion 
                        + ")";
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            string date;
            DateTime dt;

            // フォーム情報を保持
            var formData = new MainFormModel();

            IData appData = new AppData();

            // 日付チェック
            date = "20" + dateMtb.Text + "/01";

            // DateTimeに変換できるかチェック
            if (!DateTime.TryParse(date, out dt))
            {                
                MessageBox.Show("日付の入力が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            formData.date = date;
            formData.approvalType = ((RadioButton) this.approvalPanel.Controls[0]).Checked == true ? true : false;
            formData.paymentType[0] = this.paymentAllCbx.Checked;
            if (this.paymentAllCbx.Checked)
            {
                for (int i = 0; i < 4; i++)
                    formData.paymentType[i + 1] = true;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    formData.paymentType[i + 1] = ((CheckBox)this.paymentPanel.Controls[i]).Checked;
            }

            formData.bankType[0] = this.bankAllCbx.Checked;
            if (this.bankAllCbx.Checked)
            {
                for (int i = 0; i < 4; i++)
                    formData.bankType[i + 1] = true;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    formData.bankType[i + 1] = ((CheckBox)this.bankPanel.Controls[i]).Checked;
            }

            var printForm = new PrintForm(formData, appData);
            printForm.ShowDialog();
        }
       
        private void endBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateMtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                {
                    ProcessTabKey(false);
                }
                else
                {
                    ProcessTabKey(true);
                }
            }
        }
    }
}
