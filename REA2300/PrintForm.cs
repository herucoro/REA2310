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
            filePath = this.appData + @"\REA2300.csv";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }        

        private void CreateData()
        {            
            using (var connection = new SqlConnection(Secret.connectionString))
            {
                connection.Open();
                
                

                connection.Close();
            }
        }

        private void viewer1_Load(object sender, EventArgs e)
        {
            SectionReport sectionReport = new SectionReport();
            viewer1.LoadDocument(sectionReport);
        }
    }
}
