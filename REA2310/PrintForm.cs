using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using RyoeiSystem.Common;
using RyoeiSystem.Database.Controllers;

namespace REA2300
{
    public partial class PrintForm : Form
    {
        private string date;
        private IData appData;
        private string filePath;

        public PrintForm(string date, IData appData)
        {
            InitializeComponent();
            this.date = date;
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
