using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RyoeiSystem.Common;

namespace REA2300
{
    class AppData: BaseData
    {

        protected override string rootPath { get; set; }

        public AppData()
        {
            //rootPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RyoeiSystem\REA2300";
            rootPath = @"C:\ryoei";

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }            
        }

        public override string GetRootDirectoryPath()
        {
            return rootPath;
        }
    }
}
