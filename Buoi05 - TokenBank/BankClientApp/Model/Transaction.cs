using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientApp
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountIdFrom { get; set; }
        public int AccountIdTo { get; set; }
        public decimal Ammount { get; set; }
        public System.DateTime TransDate { get; set; }
        public string Messsage { get; set; }
    }
}
