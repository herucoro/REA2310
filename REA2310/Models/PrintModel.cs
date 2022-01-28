using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REA2310.Models
{
    class PrintModel
    {
        public int supplierCode;
        public string supplierName;
        public string yyyyMM;
        public string dd;
        public string amount;
        public string paymentName;
        public string bankName;

        public PrintModel()
        {
            supplierCode = 0;
            supplierName = "";
            yyyyMM = "";
            dd = "";
            amount = "";
            paymentName = "";
            bankName = "";
        }
    }
}
