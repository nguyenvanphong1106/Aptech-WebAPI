using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _136WinformShop
{
    class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }

    }
}
