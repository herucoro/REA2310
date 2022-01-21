using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REA2310.Models
{
    public class MainFormModel
    {
        public string date;
        public bool approvalType;
        public bool paymentAll;
        public Dictionary<string, int> kindsPayment;
        public Dictionary<int, bool> selectedPayment;
        public bool bankAll;
        public Dictionary<string, int> kindsBank;
        public Dictionary<int, bool> selectedBank;

        public MainFormModel()
        {
            kindsPayment = new Dictionary<string, int>()
            {
                {"手形", 3 },
                {"電債", 5 },
                {"期日指定", 6 },
                {"ファクタリング", 7 }
            };
            selectedPayment = new Dictionary<int, bool>()
            {
                {3, false },
                {5, false },
                {6, false },
                {7, false },
            };

            kindsBank = new Dictionary<string, int>()
            {
                {"豊信", 1559 },
                {"UFJ", 11 },
                {"碧信", 1560 },
                {"三井住友", 2 }
            };
            selectedBank = new Dictionary<int, bool>()
            {
                {1559, false },
                {11, false },
                {1560, false },
                {2, false },
            };
        }
    }
}
