using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventry
{
    public class ProductData
    {
        public string productName { get; set; }
        public string productNumber { get; set; }
        public ProductData(string productName,string productNumber)//Parameterized Constructor to get the product inputs
        {
            this.productName = productName;
            this.productNumber = productNumber;
        }
    }
    public class Product : DataBase
    {
        public string productName, productNumber,productCategory,price,inStock;
        private bool AddProductList(ProductData product)
        {
            productList.Add(product.productNumber, product);
            return true;
        }
        public void AddProduct()
        {
            Console.WriteLine("Product Name : ");
            productName = Console.ReadLine();
            productNumber = GenerateProductNumber();
            ProductData product = new ProductData(productName, productNumber);
            bool status = AddProductList(product);
            if (status)
            {
                Console.WriteLine("Details Added Successfully");
            }
        }
        public void DisplayProduct()
        {
            foreach (KeyValuePair<string, ProductData> product in productList)
            {
                Console.Write("Employee Name : " + (product.Value).productName + "\n");
                Console.Write("Employee Number : " + product.Key + "\n");
            }
        }
        public void DeleteProductKey()
        {
            Console.WriteLine("Enter the product Number to Delete :");
            string index = Console.ReadLine();
            productList.Remove(index);
            Console.WriteLine("Product Removed..");
        }   
    }
}
