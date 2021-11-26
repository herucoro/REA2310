using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using RyoeiSystem.Database.Common;

namespace REA2300
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var MZZ = new MZZAction();
                if (MZZAction.userId == 0)
                {
                    MessageBox.Show("MZZの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                // ミューテックス作成
                Mutex app_mutex = new Mutex(false, "REA2310");
                if (!app_mutex.WaitOne(0, false))
                {
                    MessageBox.Show("cannnot open");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                MZZ.Close();
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
