using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace StockInventry
{
    public class UserData
    {
        private string CustomerFirstName { get; set; }
        private string CustomerSecondName { get; set; }
        private string State { get; set; }
        private string City { get; set; }
        private string Address { get; set; }
        private long CellNumber { get; set; }
        private string Email { get; set; }
        private string DateOfBirth { get; set; }
        private string RegistrationNumber { get; set; }
        private int PinCode { get; set; }
        internal string Password { get; set; }
        private string ConfirmPassword { get; set; }
        internal string UserName { get; set; }
 
        public UserData(string UserName,string CustomerFirstName, string CustomerSecondName, string State, string City, string Address, int PinCode, long CellNumber, string Email, string DateOfBirth, string RegistrationNumber, string Password, string ConfirmPassword)
        {
            this.UserName = UserName;
            this.CustomerFirstName = CustomerFirstName;
            this.CustomerSecondName =CustomerSecondName;
            this.State = State;
            this.City = City;
            this.Address = Address;
            this.PinCode = PinCode;
            this.CellNumber = CellNumber;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.RegistrationNumber = RegistrationNumber;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
        }
        public UserData() { }
    }
    public class User : DataBase
    {
        public void DisplayCustomer(SqlConnection myConnection,int action)
        {
            string sql = "User_Procedure";
            SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Action", action));
            Console.WriteLine("Enter the User User Name you want to See");
            UserName = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@UserName", UserName));
            sqlDataAdapter.SelectCommand = sqlCommand;
            if (action == 3)
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "UserData");
                foreach (DataRow row in dataSet.Tables["UserData"].Rows)
                {
                    Console.WriteLine(row["UserName"] + "\n" + row["CustomerFirstName"] + "\n" + row["CustomerSecondName"] + "\n" + row["States"] + "\n" + row["City"] + "\n" + row["PermenantAddress"] + "\n" + row["PinCode"] + "\n" + row["CellNumber"] + "\n" + row["Email"] + "\n" + row["DateOfBirth"] + "\n" + row["RegistrationNumber"] + "\n" + row["Passwords"]);
                    Console.WriteLine();
                }
            }
            else if(action==4)
            {
                int retRows =sqlCommand.ExecuteNonQuery();

                if (retRows >= 1)
                {
                    Console.WriteLine("Customer Deleted...");
                }
                else
                {
                    Console.WriteLine("Customer Does not Deleted ...");
                }
            }
        }
        private bool AddCustomer(UserData user)
        {
            customerList.Add(user);
            return true;
        }
        public void GetCustomerDetails(SqlConnection myConnection,int action)
        {
           
            string sql = "UserData_Procedure";
            SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Action", action));
            if (action == 1)
            {
                CustomerFirstName = ValidCustomerFirstName();
                sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", CustomerFirstName));
                UserName = GenereteUserName();
                sqlCommand.Parameters.Add(new SqlParameter("@UserName", UserName));
            }
            else if(action ==2)
            {
                Console.WriteLine("Enter the User User Name you want to change");
                UserName = Console.ReadLine();
                sqlCommand.Parameters.Add(new SqlParameter("@UserName", UserName));
                CustomerFirstName = ValidCustomerFirstName();
                sqlCommand.Parameters.AddWithValue("@CustomerFirstName", CustomerFirstName);
            }
           
            CustomerSecondName = ValidateCustomerSecondName();
            sqlCommand.Parameters.AddWithValue("@CustomerSecondName", CustomerSecondName);
            State = ValidateState();
            sqlCommand.Parameters.AddWithValue("@State", State);
            City = ValidateCity();
            sqlCommand.Parameters.AddWithValue("@City", City);
            PermenantAddress = ValidateAddress();
            sqlCommand.Parameters.AddWithValue("@PermenantAddress", PermenantAddress);
            PinCode = ValidatePinCode();
            sqlCommand.Parameters.AddWithValue("@PinCode", PinCode);
            CellNumber = ValidateCellNumber();
            sqlCommand.Parameters.AddWithValue("@CellNumber", CellNumber);
            Email = ValidateMail();
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            DateOfBirth = ValidateDateOfBirth();
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            RegistrationNumber = GenerateRegistrationNumber();
            sqlCommand.Parameters.AddWithValue("@RegistrationNumber", RegistrationNumber);
            Password = ValidatePassword();
            sqlCommand.Parameters.AddWithValue("@Password", Password);
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
            bool status = AddCustomer(userData);
            int limit = sqlCommand.ExecuteNonQuery();
            
            if (status == true && limit >= 1)
            {

                Console.WriteLine("Details Added Successfully");
            }
        }
        //public void UpdateCustomerDetails(SqlConnection myConnection)
        //{
        //    string sql = "";
        //    SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
            
        //    sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", CustomerFirstName));
        //    CustomerSecondName = ValidateCustomerSecondName();
        //    sqlCommand.Parameters.Add(new SqlParameter("@CustomerSecondName", CustomerSecondName));
        //    State = ValidateState();
        //    sqlCommand.Parameters.Add(new SqlParameter("@State", State));
        //    City = ValidateCity();
        //    sqlCommand.Parameters.Add(new SqlParameter("@City", City));
        //    PermenantAddress = ValidateAddress();
        //    sqlCommand.Parameters.Add(new SqlParameter("@PermenantAddress", PermenantAddress));
        //    PinCode = ValidatePinCode();
        //    sqlCommand.Parameters.Add(new SqlParameter("@PinCode", PinCode));
        //    CellNumber = ValidateCellNumber();
        //    sqlCommand.Parameters.Add(new SqlParameter("@CellNumber", CellNumber));
        //    Email = ValidateMail();
        //    sqlCommand.Parameters.Add(new SqlParameter("@Email", Email));
        //    DateOfBirth = ValidateDateOfBirth();
        //    sqlCommand.Parameters.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
        //    RegistrationNumber = GenerateRegistrationNumber();
        //    sqlCommand.Parameters.Add(new SqlParameter("@RegistrationNumber", RegistrationNumber));
        //    Password = ValidatePassword();
        //    sqlCommand.Parameters.Add(new SqlParameter("@Password", Password));
        //    do
        //    {
        //        Console.WriteLine("Confirm Password : ");
        //        ConfirmPassword = Console.ReadLine();
        //        if (Password != ConfirmPassword)
        //        {
        //            Console.WriteLine("Password doesn't Match\nRe-Enter the Password : ");
        //        }
        //    }
        //    while (ConfirmPassword != Password);
        //    int limit = sqlCommand.ExecuteNonQuery();
        //    if (limit >= 1)
        //    {

        //        Console.WriteLine("Details Added Successfully");
        //    }
        //}
    }
}



