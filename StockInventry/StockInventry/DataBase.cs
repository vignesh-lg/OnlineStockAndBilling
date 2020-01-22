using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StockInventry
{

    public class DataBase : RegistrationValidation
    {
        public static string userName, password;
        
        
        internal static SortedList<string, ProductData> productList = new SortedList<string, ProductData>();
        string sqlConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public List<UserData> customerList = new List<UserData>();

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
                    Console.WriteLine("*********************Welcome to CUstomer Page*************************");
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
                int choice = Convert.ToInt32(Console.ReadLine());
                //customer.GetCustomerDetails(myConnection,choice);
                customer.DisplayCustomer(myConnection,choice);
            }
        }
        
       
    }
}

