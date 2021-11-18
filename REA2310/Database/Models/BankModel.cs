using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyoeiSystem.Database.Models
{
    public class MoneyDateModel
    {
        public double amount;
        public string paymentDay;

        public MoneyDateModel()
        {
            amount = 0.0;
            paymentDay = "";
        }
    }

    public class BankModel
    {
        public int bankCode;
        public string bankName;
        public List<MoneyDateModel> payment;
        
        public BankModel()
        {
            bankCode = 0;
            bankName = "";
            payment = new List<MoneyDateModel>();
        }
    }
}
