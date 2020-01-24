using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StockInventry
{
    class InterfaceHandler : DataBase
    {
        private string UserName1, Password1;

        public void ToLogin()
        {
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string query = "User_Procedure_Login";                
                SqlCommand sqlCommand = new SqlCommand(query, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine(" User Name :");
                UserName1 = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@UserName1", UserName1);
                Console.WriteLine("Password :");
                Password1 = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Password1", Password1);
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (UserName1 == userName && Password1 == password)
                {
                    GetConnection();
                }
               if (dataTable.Rows.Count == 1)
                {
                    CustomerFunction();

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
