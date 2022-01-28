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
        public bool approvalState;
        public bool paymentAll;
        public static Dictionary<string, string> kindsPayment;
        public Dictionary<string, bool> selectedPayment;
        public static Dictionary<string, string> omitPaymentName;
        public bool bankAll;
        public static Dictionary<string, int> kindsBank;
        public Dictionary<int, bool> selectedBank;
        public static Dictionary<string, string> omitBankName;

        public MainFormModel()
        {
            kindsPayment = new Dictionary<string, string>()
            {
                {"手形", "3" },
                {"電債", "5" },
                {"期日指定", "6" },
                {"ファクタリング", "7" }
            };
            selectedPayment = new Dictionary<string, bool>()
            {
                {"3", false },
                {"5", false },
                {"6", false },
                {"7", false },
            };
            omitPaymentName = new Dictionary<string, string>()
            {
                {"手形", "手" },
                {"電債", "電" },
                {"期日指定", "期" },
                {"ファクタリング", "フ" },
            };

            kindsBank = new Dictionary<string, int>()
            {
                {"豊信", 1559 },
                {"UFJ", 5 },
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
            omitBankName = new Dictionary<string, string>()
            {
                {"豊信", "豊" },
                {"UFJ", "U" },
                {"碧信", "碧" },
                {"三井住友", "住" }
            };
        }
    }
}
