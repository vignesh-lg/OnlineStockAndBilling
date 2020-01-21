using System;
using System.Data.SqlClient;
using System.Configuration;
namespace StockInventry
{
    class InterfaceHandler : DataBase
    {
        
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
            catch(OverflowException)
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
