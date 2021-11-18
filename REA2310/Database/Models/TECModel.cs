using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyoeiSystem.Database.Models
{
    class TECModel
    {
        public int TECSEICOD;
        public string TECMEISYO;
        public string TECNYUSYU;
        public long TECKEIDAT;
        public double TECKINGAK;
        public int TECBANKCD;

        public TECModel()
        {
            TECSEICOD = 0;
            TECMEISYO = "";
            TECNYUSYU = "";
            TECKEIDAT = 0;
            TECKINGAK = 0.0;
            TECBANKCD = 0;
        }
    }
}
