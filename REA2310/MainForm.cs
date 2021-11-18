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
    }
}
