using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RyoeiSystem.Common;

namespace REA2310
{
    class AppData: BaseData
    {

        protected override string rootPath { get; set; }

        public AppData()
        {
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
