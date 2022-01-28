using RyoeiSystem.Common;
using RyoeiSystem.Database.Controllers;
using System;
using System.IO;
using System.Windows.Forms;

using REA2310.Models;

namespace REA2310
{
    public partial class PrintForm : Form
    {
        private MainFormModel formData;
        private IData appData;
        private string filePath;

        public PrintForm(MainFormModel formData, IData appData)
        {
            InitializeComponent();
            this.formData = formData;

            this.appData = appData;

            // SectionReport.csで必要なデータの参照先を設定
            filePath = this.appData.GetRootDirectoryPath() + @"\REA2310.csv";

            // 重複するため、存在していた場合は削除
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        private void viewer1_Load(object sender, EventArgs e)
        {
            // コンストラクタで設定したMainFormのデータとfileのパスをController.csへ渡す
            var control = new Controller(formData, filePath);
            control.CreateData();

            // control.CreateDate()で生成したデータをSectionReport.csへ渡す
            SectionReport sectionReport = new SectionReport(control.GetDate(), control.GetBank(), formData);
            viewer1.LoadDocument(sectionReport);
        }
    }
}
