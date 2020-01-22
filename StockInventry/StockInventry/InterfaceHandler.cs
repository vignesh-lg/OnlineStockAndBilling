using System;
using System.Data.SqlClient;
using System.Configuration;
namespace StockInventry
{
    class InterfaceHandler : DataBase
    {
        private string UserName1, Password1;

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
        internal void InterfaceController()
        {
            try
            {
                Console.WriteLine("*********************Welcome to Main Page*************************");
                Console.WriteLine("Enter your choice\n1.Login\n2.Registration\n3.Exit");
                int select = int.Parse(Console.ReadLine());
                do
                {
                    switch (select)
                    {

                        case 1:
                            ToLogin();
                            break;
                        case 2:
                            GetConnection();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    Console.WriteLine("*********************Welcome to Main Page*************************");
                    Console.WriteLine("Enter your choice\n1.Login\n2.Registration\n3.Exit");
                    select = int.Parse(Console.ReadLine());
                } while (select != 8);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid Input..");
                InterfaceController();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input..");
                InterfaceController();
            }
            //catch (Exception)
            //{
            //    Console.WriteLine("Invalid Input..");
            //    InterfaceController();
            //}
        }
    }
}
