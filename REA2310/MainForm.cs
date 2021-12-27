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

namespace REA2300
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();

            this.allDepositCbx.Click += AllDepositClicked;
            this.depositCbx0.Click += DepositStateCheck;
            this.depositCbx1.Click += DepositStateCheck;
            this.depositCbx2.Click += DepositStateCheck;
            this.depositCbx3.Click += DepositStateCheck;

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

            IData appData = new AppData();

            // 日付チェック
            date = "20" + dateMtb.Text + "/01";

            // DateTimeに変換できるかチェック
            if (!DateTime.TryParse(date, out dt))
            {                
                MessageBox.Show("日付の入力が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            var printForm = new PrintForm(date, appData);
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
            CheckBox_Checked(this.allDepositCbx.Checked, this.selectDepostiPanel.Controls);
        }

        private void allBankCbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(this.allBankCbx.Checked, this.selectBankPanel.Controls);
        }

        private void AllDepositClicked(object sender, EventArgs e)
        {
            foreach (CheckBox c in this.selectDepostiPanel.Controls)
            {
                c.Checked = this.allDepositCbx.Checked;
            }
        }

        private void AllBankClicked(object sender, EventArgs e)
        {
            foreach(CheckBox c in this.selectBankPanel.Controls)
            {
                c.Checked = this.allBankCbx.Checked;
            }
        }

        private void DepositStateCheck(object sender, EventArgs e)
        {
            bool check = true;

            foreach(CheckBox c in this.selectDepostiPanel.Controls)
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
