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
        public bool[] paymentType = new bool[5];
        public bool[] bankType = new bool[5];

    }
}
