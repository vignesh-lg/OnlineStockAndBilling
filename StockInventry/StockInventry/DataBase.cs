using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StockInventry
{

    public class DataBase : Validation
    {
        public static string userName, password;


        internal static SortedList<string, ProductData> productList = new SortedList<string, ProductData>();
        public string sqlConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public List<UserData> customerList = new List<UserData>();
        private int choice;
        static DataBase()
        {
            userName = "Admin";
            password = "admin";
        }
        public void AdminFunction()
        {
            Product product = new Product();
            try
            {
                Console.WriteLine("*********************Welcome to Admin Page*************************");
                Console.WriteLine("Enter your choice\n1.Add Product\n2.Display Product \n3.Delete Product\n4.Logout");
                int select = int.Parse(Console.ReadLine());
                do
                {
                    switch (select)
                    {

                        case 1:
                            product.AddProduct();
                            break;
                        case 2:
                            product.DisplayProduct();
                            break;
                        case 3:
                            product.DeleteProductKey();
                            break;
                        case 4:
                            InterfaceHandler interfaceHandler = new InterfaceHandler();
                            interfaceHandler.InterfaceController();
                            break;
                    }
                    Console.WriteLine("*********************Welcome to Admin Page*************************");
                    Console.WriteLine("Enter your choice\n1.Add Product\n2.Display Product \n3.Delete Product\n4.Logout");
                    select = int.Parse(Console.ReadLine());
                } while (select != 8);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid Input..");
                AdminFunction();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input..");
                AdminFunction();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input..");
                AdminFunction();
            }
        }
        public void CustomerFunction()
        {
            Product product = new Product();
            try
            {
                Console.WriteLine("*********************Welcome to User Page*************************");
                Console.WriteLine("Enter your choice\n1.Display Product\n2.Logout");
                int select = int.Parse(Console.ReadLine());
                do
                {
                    switch (select)
                    {


                        case 1:
                            product.DisplayProduct();
                            break;
                        case 2:
                            InterfaceHandler interfaceHandler = new InterfaceHandler();
                            interfaceHandler.InterfaceController();
                            break;
                    }
                    Console.WriteLine("*********************Welcome to Customer Page*************************");
                    Console.WriteLine("Enter your choice\n1.Display Product\n2.Logout");
                    select = int.Parse(Console.ReadLine());
                } while (select != 8);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid Input..");
                CustomerFunction();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input..");
                CustomerFunction();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input..");
                CustomerFunction();
            }
        }
        public void GetConnection()
        {
            User customer = new User();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connection is not present");
                }
                else
                    Console.WriteLine("Connection Established");
                do
                {
                    Console.WriteLine("Enter your Choice :\n1.To Insert\n2. To Update\n3.To Select\n4.To Delete\n5.Log Out");
                    choice = Convert.ToInt32(Console.ReadLine());
                   
                    if (choice == 1 || choice == 2)
                        customer.GetAndUpdateCustomerDetails(myConnection, choice);
                    if (choice == 3 || choice == 4)
                        customer.DisplayAndDeleteCustomer(myConnection, choice);
                }
                while (choice != 5);
            }
        }


    }
}

