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

            // 入金種別ControlsEventHandler
            this.allDepositCbx.Click += AllDepositClicked;
            this.depositCbx0.Click += DepositStateCheck;
            this.depositCbx1.Click += DepositStateCheck;
            this.depositCbx2.Click += DepositStateCheck;
            this.depositCbx3.Click += DepositStateCheck;

            // 銀行ControlsEventHandler
            this.allBankCbx.Click += AllBankClicked;
            this.bankCbx0.Click += BankStateCheck;
            this.bankCbx1.Click += BankStateCheck;
            this.bankCbx2.Click += BankStateCheck;
            this.bankCbx3.Click += BankStateCheck;

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
            formData.paymentType[0] = this.allDepositCbx.Checked;
            if (this.allDepositCbx.Checked)
            {
                for (int i = 0; i < 4; i++)
                    formData.paymentType[i + 1] = true;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    formData.paymentType[i + 1] = ((CheckBox)this.selectDepositPanel.Controls[i]).Checked;
            }

            formData.bankType[0] = this.allBankCbx.Checked;
            if (this.allBankCbx.Checked)
            {
                for (int i = 0; i < 4; i++)
                    formData.bankType[i + 1] = true;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    formData.bankType[i + 1] = ((CheckBox)this.selectBankPanel.Controls[i]).Checked;
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

        private void CheckBox_Checked(bool check, Control.ControlCollection controlPanel)
        {
            foreach (CheckBox c in controlPanel)
            {
                c.Checked = check;
            }
        }

        private void allDepositCbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(this.allDepositCbx.Checked, this.selectDepositPanel.Controls);
        }

        private void allBankCbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(this.allBankCbx.Checked, this.selectBankPanel.Controls);
        }

        private void AllDepositClicked(object sender, EventArgs e)
        {
            foreach (CheckBox c in this.selectDepositPanel.Controls)
            {
                c.Checked = this.allDepositCbx.Checked;
            }
        }

        private void AllBankClicked(object sender, EventArgs e)
        {
            foreach (CheckBox c in this.selectBankPanel.Controls)
            {
                c.Checked = this.allBankCbx.Checked;
            }
        }

        private void DepositStateCheck(object sender, EventArgs e)
        {
            bool check = true;

            foreach (CheckBox c in this.selectDepositPanel.Controls)
            {
                check = check && c.Checked;
            }

            this.allDepositCbx.Checked = check;
        }

        private void BankStateCheck(object sender, EventArgs e)
        {
            bool check = true;
            foreach (CheckBox c in this.selectBankPanel.Controls)
            {
                check = check && c.Checked;
            }

            this.allBankCbx.Checked = check;
        }

    }
}
