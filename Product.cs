using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    struct Product
    {
        public string Name;
        public string Manufacturer;
        public int Quantity;
        public decimal Price;
        public int Year;

        public decimal TotalCost => Quantity * Price;
    }
}
