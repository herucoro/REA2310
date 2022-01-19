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
            //this.date = date;
            this.formData = formData;

            this.appData = appData;
            filePath = this.appData.GetRootDirectoryPath() + @"\REA2300.csv";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void viewer1_Load(object sender, EventArgs e)
        {
            var control = new Controller(date, filePath);
            control.CreateData();

            SectionReport sectionReport = new SectionReport(control.GetDate(), control.GetBank());
            viewer1.LoadDocument(sectionReport);
        }
    }
}
