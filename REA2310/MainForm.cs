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
            this.allPaymentCbx.Click += AllDepositClicked;
            this.paymentCbx0.Click += DepositStateCheck;
            this.paymentCbx1.Click += DepositStateCheck;
            this.paymentCbx2.Click += DepositStateCheck;
            this.paymentCbx3.Click += DepositStateCheck;

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

            // アプリケーション設定情報を保持
            IData appData = new AppData();

            // 日付チェック
            date = "20" + dateMtb.Text + "/01";

            // DateTimeに変換できるかチェック
            if (!DateTime.TryParse(date, out dt))
            {                
                MessageBox.Show("日付の入力が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 入金種別が個別選択の場合は確認
            if (!this.allPaymentCbx.Checked)
            {
                bool checkPayment = false;

                foreach (CheckBox cbx in this.selectPaymentPanel.Controls)
                {
                    if (cbx.Checked)
                    {
                        checkPayment = cbx.Checked;
                        break;
                    }                    
                }

                if (!checkPayment)
                {
                    MessageBox.Show("入金種別を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 銀行が個別選択の場合は確認
            if (!this.allBankCbx.Checked)
            {
                bool checkBank = false;

                foreach (CheckBox cbx in this.selectBankPanel.Controls)
                {
                    if (cbx.Checked)
                    {
                        checkBank = cbx.Checked;
                        break;
                    }
                }

                if (!checkBank)
                {
                    MessageBox.Show("銀行を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 20yy/MM/01
            formData.date = date;

            // 決裁選択の取得
            formData.approvalState = ((RadioButton) this.approvalPanel.Controls[0]).Checked;

            // 入金種別選択の取得
            formData.paymentAll = this.allPaymentCbx.Checked;
            foreach (CheckBox payment in this.selectPaymentPanel.Controls)
                formData.selectedPayment[MainFormModel.kindsPayment[payment.Text]] = payment.Checked;

            // 銀行選択の取得
            formData.bankAll = this.allBankCbx.Checked;
            foreach (CheckBox bank in this.selectBankPanel.Controls)
                formData.selectedBank[MainFormModel.kindsBank[bank.Text]] = bank.Checked;

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
            CheckBox_Checked(this.allPaymentCbx.Checked, this.selectPaymentPanel.Controls);
        }

        private void allBankCbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(this.allBankCbx.Checked, this.selectBankPanel.Controls);
        }

        private void AllDepositClicked(object sender, EventArgs e)
        {
            foreach (CheckBox c in this.selectPaymentPanel.Controls)
            {
                c.Checked = this.allPaymentCbx.Checked;
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

            foreach (CheckBox c in this.selectPaymentPanel.Controls)
            {
                check = check && c.Checked;
            }

            this.allPaymentCbx.Checked = check;
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
