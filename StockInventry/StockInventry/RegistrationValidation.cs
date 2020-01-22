using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace StockInventry
{
    public class RegistrationValidation 
    {
        internal string UserName, CustomerFirstName, CustomerSecondName, State, City, PermenantAddress, Email, Password, ConfirmPassword, RegistrationNumber;
        internal long CellNumber;
        internal string DateOfBirth;
        protected DateTime DOB;
        internal int PinCode;
        internal string GenereteUserName()//Method to Generate the Unique UserName
        {
            Random random = new Random();
            UserName = CustomerFirstName + random.Next(100);//Creates a random of object from 1-100
            Console.WriteLine("User Name : " + UserName);
            return UserName;//return the username
        }
        internal string ValidCustomerFirstName()//Validate the User FirstName
        {
            Console.WriteLine("FirstName : ");
            CustomerFirstName = Console.ReadLine();

            if (CustomerFirstName.Length < 2 && CustomerFirstName.Length > 20)//Checks for the customer name length 
            {
                Console.WriteLine("The name is not valid try again..");
                CustomerFirstName = ValidCustomerFirstName();
            }
            Regex check = new Regex(@"([A-Z][a-z-A-Z])");
            bool valid = check.IsMatch(CustomerFirstName);
            Regex check1 = new Regex(@"([0-9])");
            if (check1.IsMatch(CustomerFirstName) == true)
            {
                valid = false;
            }
            char[] charName = CustomerFirstName.ToCharArray();
            for (int i = 0; i < charName.Length - 2; i++)
            {
                if ((charName[i] == charName[i + 1]) && (charName[i + 1] == charName[i + 2]))
                {
                    valid = false;
                    break;
                }
            }
            if ((valid == false))
            {
                Console.WriteLine("Name is Invalid..");
                CustomerFirstName = ValidCustomerFirstName();
            }
            return CustomerFirstName;
        }
        internal string ValidateCustomerSecondName()
        {
            Console.WriteLine("SecondName : ");
            CustomerSecondName = Console.ReadLine();

            if (CustomerSecondName.Length < 2 && CustomerSecondName.Length > 20)
            {
                Console.WriteLine("The name is not valid..");
                CustomerSecondName = ValidateCustomerSecondName();
            }
            Regex check = new Regex(@"([A-Z][a-z-A-Z])");
            bool valid = check.IsMatch(CustomerSecondName);
            Regex check1 = new Regex(@"([0-9])");
            if (check1.IsMatch(CustomerSecondName) == true)
            {
                valid = false;
            }
            char[] charName = CustomerSecondName.ToCharArray();
            for (int i = 0; i < charName.Length - 2; i++)
            {
                if ((charName[i] == charName[i + 1]) && (charName[i + 1] == charName[i + 2]))
                {
                    valid = false;
                    break;
                }
            }
            if ((valid == false))
            {
                Console.WriteLine("Name is Invalid..");
                CustomerSecondName = ValidateCustomerSecondName();
            }
            return CustomerSecondName;
        }
        internal string ValidateState()
        {
            Console.WriteLine("State : ");
            State = Console.ReadLine();

            if (State.Length < 2 && State.Length > 20)
            {
                Console.WriteLine("State is not valid..");
                State = ValidateState();
            }
            Regex check = new Regex(@"([A-Z][a-z-A-Z])");
            bool valid = check.IsMatch(State);
            Regex check1 = new Regex(@"([0-9])");
            if (check1.IsMatch(State) == true)
            {
                valid = false;
            }
            char[] charName = State.ToCharArray();
            for (int i = 0; i < charName.Length - 2; i++)
            {
                if ((charName[i] == charName[i + 1]) && (charName[i + 1] == charName[i + 2]))
                {
                    valid = false;
                    break;
                }
            }
            if ((valid == false))
            {
                Console.WriteLine("State is Invalid..");
                CustomerSecondName = ValidateState();
            }
            return State;
        }
        internal string ValidateCity()
        {
            Console.WriteLine("City : ");
            City = Console.ReadLine();

            if (City.Length < 2 && City.Length > 20)
            {
                Console.WriteLine("City is not valid..");
                City = ValidateCity();
            }
            Regex check = new Regex(@"([A-Z][a-z-A-Z])");
            bool valid = check.IsMatch(City);
            Regex check1 = new Regex(@"([0-9])");
            if (check1.IsMatch(City) == true)
            {
                valid = false;
            }
            char[] charName = City.ToCharArray();
            for (int i = 0; i < charName.Length - 2; i++)
            {
                if ((charName[i] == charName[i + 1]) && (charName[i + 1] == charName[i + 2]))
                {
                    valid = false;
                    break;
                }
            }
            if ((valid == false))
            {
                Console.WriteLine("City is Invalid..");
                City = ValidateCity();
            }
            return City;
        }
        internal string ValidateAddress()
        {
            Console.WriteLine("Address : ");
            PermenantAddress = Console.ReadLine();
            if (PermenantAddress =="" && PermenantAddress.Length<2 && PermenantAddress.Length>20)
            {
                Console.WriteLine("Address is not valid..");
                PermenantAddress = ValidateAddress();
            }
            char[] charName = PermenantAddress.ToCharArray();
            for (int i = 0; i < charName.Length - 2; i++)
            {
                if ((charName[i] == charName[i + 1]) && (charName[i + 1] == charName[i + 2]))
                {
                    Console.WriteLine("Incorrect Address");
                    PermenantAddress=ValidateAddress();
                }
            }  
            return PermenantAddress;
        }
        internal long ValidateCellNumber()
        {
            Console.WriteLine("Cell Number : ");
            try
            {
                CellNumber = Convert.ToInt64(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid MobileNumber..");
                ValidateCellNumber();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid MobileNumber..");
                ValidateCellNumber();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid MobileNumber..");
                ValidateCellNumber();
            }
            if ( CellNumber > 6000000000 && CellNumber < 9999999999)
            {
                return CellNumber;
            }
            else
            {
                Console.WriteLine("Cell Number is Invalid..");
                ValidateCellNumber();
            }
            return CellNumber;
        }
        internal int ValidatePinCode()
        {
            Console.WriteLine("Pin Code : ");
            try
            {
                PinCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid Pincode..");
                ValidatePinCode();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Pincode..");
                ValidatePinCode();
            }
            catch (Exception)
            {
                Console.WriteLine( "Invalid Pincode..");
                ValidatePinCode();
            }
            Regex check = new Regex(@"^[0-9]");
            bool valid = check.IsMatch(PinCode.ToString());
            if ((PinCode.ToString().Length == 6) && (valid == true) && PinCode > 100000 && PinCode < 999999)
            {
                return PinCode;
            }
            else
            {
                Console.WriteLine("Pincode is Invalid..");
                ValidatePinCode();
            }
            return PinCode;
        }
        internal string ValidateDateOfBirth()
        {
            Console.WriteLine("Date Of Birth : ");
             DateOfBirth = Console.ReadLine();
            try
            {
                 DOB = DateTime.Parse(DateOfBirth);
                //date = Convert.ToDateTime(DateOfBirth);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Date of birth..");
                ValidateDateOfBirth();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Date of birth..");
                ValidateDateOfBirth();
            }
            DateTime dateTime = DateTime.Today;
            int age = dateTime.Year - DOB.Year;
            if (age < 18 || age > 80)
            {
                Console.WriteLine("Invalid Date of birth..");
                ValidateDateOfBirth();
            }
            return DateOfBirth;
        }
        internal string ValidateMail()
        {
            Console.WriteLine("E-mail : ");
            Email = Console.ReadLine();
            Regex check = new Regex(@"([^a-z-0-9-@.])");
            bool valid = check.IsMatch(Email);
            if ((valid == true))
            {
                Console.WriteLine("Mail is Invalid..");
                ValidateMail();
            }
            try
            {
                MailAddress mailid = new MailAddress(Email);
                return Email;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Mail Id");
                ValidateMail();
            }
            return Email;
        }
        internal string GenerateRegistrationNumber()
        {
            Random random = new Random();
            RegistrationNumber = "OIA" + random.Next(1000);
            Console.WriteLine("Registration Number " + RegistrationNumber);
            return RegistrationNumber;
        }
        internal string GenerateProductNumber()
        {
            Random random = new Random();
            string productNumber = "IAP" + random.Next(1000);
            Console.WriteLine("Product Number " + productNumber);
            return productNumber;
        }
        internal string ValidatePassword()
        {
            Console.WriteLine("Password : ");
            Password = Console.ReadLine();
            var regex= new Regex(@"([0-9-A-Z-a-z-!@#$%^&*()_+=\[{\]};:<>|./?,-].{8,15})");
            if(!regex.IsMatch(Password))
            {
                Console.WriteLine("Password must contain a number,special character,uppercase, lowercase\nRe-Enter the Password : ");
                ValidatePassword();
            }
            return Password;
        }
    }
}