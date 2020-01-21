using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StockInventry
{

    public class DataBase : RegistrationValidation
    {
        private static string userName, password;
        public string UserName1, Password1;
        internal static SortedList<string, Product> productList = new SortedList<string, Product>();
        string sqlConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        List<UserData> customerList = new List<UserData>();

        static DataBase()
        {
            userName = "Admin";
            password = "admin";
        }
        public void GetConnection()
        {
            using (SqlConnection myConnection= new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connection is not present");
                }
                else
                    Console.WriteLine("Connection Established");
                GetCustomerDetails(myConnection);
            }
        }
        private bool AddProductList(Product product)
        {
            productList.Add(product.productNumber, product);
            return true;
        }
        public void AddProduct()
        {
            Console.WriteLine("Product Name : ");
            string productName = Console.ReadLine();
            string productNumber = GenerateProductNumber();
            Product product = new Product(productName, productNumber);
            bool status = AddProductList(product);
            if (status)
            {
                Console.WriteLine("Details Added Successfully");
            }
        }
        public void DisplayProduct()
        {
            foreach (KeyValuePair<string, Product> product in productList)
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
        private bool AddCustomer(UserData user)
        {
            customerList.Add(user);
            return true;
        }
        public void GetCustomerDetails(SqlConnection myConnection)
        {

            CustomerFirstName = ValidCustomerFirstName();
            UserName = GenereteUserName();
            CustomerSecondName = ValidateCustomerSecondName();
            State = ValidateState();
            City = ValidateCity();
            PermenantAddress = ValidateAddress();
            PinCode = ValidatePinCode();
            CellNumber = ValidateCellNumber();
            Email = ValidateMail();
            DateOfBirth = ValidateDateOfBirth();
            RegistrationNumber = GenerateRegistrationNumber();
            Password = ValidatePassword();
            do
            {
                Console.WriteLine("Confirm Password : ");
                ConfirmPassword = Console.ReadLine();
                if (Password != ConfirmPassword)
                {
                    Console.WriteLine("Password doesn't Match\nRe-Enter the Password : ");
                }
            }
            while (ConfirmPassword != Password);

            UserData userData = new UserData(UserName, CustomerFirstName, CustomerSecondName, State, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Password, ConfirmPassword);
            string sql = "INSERT INTO UserData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords) VALUES ('" + UserName + "','" +
             CustomerFirstName + "','" + CustomerSecondName + "','" + State + "','" + City + "','" + PermenantAddress + "'," + PinCode + "," + CellNumber + ",'" + Email + "','" + DateOfBirth + "','" + RegistrationNumber + "','" + Password + "')";

            SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.InsertCommand = sqlCommand;
            int limit = sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            bool status = AddCustomer(userData);
            if (status==true && limit >=1 ) {
            
                Console.WriteLine("Details Added Successfully");
            }
        }
        public void AdminFunction()
        {
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
                            AddProduct();
                            break;
                        case 2:
                            DisplayProduct();
                            break;
                        case 3:
                            DeleteProductKey();
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
            try
            {
                Console.WriteLine("*********************Welcome to Customer Page*************************");
                Console.WriteLine("Enter your choice\n1.Display Product\n2.Logout");
                int select = int.Parse(Console.ReadLine());
                do
                {
                    switch (select)
                    {


                        case 1:
                            DisplayProduct();
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
        public void ToLogin()
        {
            Console.WriteLine(" User Name :");
            UserName1 = Console.ReadLine();
            Console.WriteLine("Password :");
            Password1 = Console.ReadLine();
            if (UserName1 == userName && Password1 == password)
            {
                AdminFunction();
            }
            foreach (UserData userData in customerList)
            {
                if (UserName1 == userData.UserName && Password1 == userData.Password)
                {
                    CustomerFunction();
                    break;
                }

                else
                {
                    Console.WriteLine("In-correct UserName or Password\nRe-Enter : ");
                    ToLogin();
                }
            }
        }
    }   
}

