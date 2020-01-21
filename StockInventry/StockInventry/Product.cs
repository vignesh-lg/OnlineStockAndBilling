using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventry
{
    public class Product
    {
        public string productName { get; set; }
        public string productNumber { get; set; }
        public Product(string productName,string productNumber)//Parameterized Constructor to get the product inputs
        {
            this.productName = productName;
            this.productNumber = productNumber;
        }
    }
}
