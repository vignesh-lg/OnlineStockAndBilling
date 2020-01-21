using System;
using System.Collections.Generic;


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
}



