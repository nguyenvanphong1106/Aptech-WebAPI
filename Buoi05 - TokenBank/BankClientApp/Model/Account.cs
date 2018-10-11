using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientApp
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string PIN { get; set; }
        public decimal Balance { get; set; }
        public string Token { get; set; }
    }
}
