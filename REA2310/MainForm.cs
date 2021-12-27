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

        private void allDepositRb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(true, this.selectDepostiPanel.Controls);
        }

        private void someDepositRb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(false, this.selectDepostiPanel.Controls);
        }

        private void allBankRb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(true, this.selectBankPanel.Controls);
        }

        private void someBankRb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_Checked(false, this.selectBankPanel.Controls);
        }

        private void CheckBox_Checked(bool check, Control.ControlCollection controlPanel)
        {
            foreach (CheckBox c in controlPanel)
            {
                c.Checked = check;
            }
        }
    }
}
