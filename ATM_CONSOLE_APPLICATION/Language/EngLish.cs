using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Language
{
    public class English : AbstractLanguage
    {
        public override void ChangeLanguage()
        {
            Current_Language = "English";
            // Menu actor người dùng
            Login = "Login";
            Register = "Register";
            Card_Management = "Card Management";
            Check_Account_Information = "Check Account Information";
            Withdraw_Money = "Withdraw Money";
            Recharge = "Recharge";
            Tranfer_Money = "Transfer Money";
            Bank_Deposit = "Bank Deposit";
            Transaction_History = "Check Transaction History";
            Change_Language = "Switch Language";
            // Menu actor Admin
            Check_Account_Information_Admin = "Check Account Information";
            Transaction_History_Admin = "Check Transaction History";
            Transaction_Statistics = "Transaction statistics";
            //Choose
            Input_choose = "Enter account: ";
            Exception_choose = "Only numbers are allowed";
            Exception_choose_switch = "Enter the wrong choice";
            // Login
            Input_User = "Enter account: ";
            Input_Pass = "Enter password: ";
            Notification_Login_True = "Logged in successfully";
            Notification_Login_Fasle = "Logged in unsuccessfully";
            // Register
            Input_Fullname = "Enter your first and last name: ";
            Input_DateOfBirth = "Enter your date/month/year of birth: ";
            Input_Address = "Enter your address: ";
            Input_Email = "Enter your email: ";
            Input_Phone = "Enter your phone number: ";
            Input_Gender = "Enter gender (Male/Female): ";
            Input_CMND_CCCD = "Enter your identity card number or citizen's identity card: ";
            Error_Input_Gender = "Enter invalid gende";
            Error_Input_CMND = "Enter invalid identity card number or citizen's identity card";
            Error_Input_Email = "Enter invalid email";
            Error_Input_Phone = "Enter invalid phone number \\Phone number need to start with 0 and have between 9 and 11 numbers";
            Error_Input_Pass = "Password must have at least 8 characters";
            Register_Success = "Register successfully";
            Registration_Failed = "Register unsuccessfully";
            Error_Invalid_DateOfBirth = "Enter the wrong DateOfBirth format";
            Error_Email_Already_Exists = "This email is registered before";
            Error_Phone_Already_Exists = "This phone number is registered before";
            Error_User_Already_Exists = "Account name is registered before";
            Error_CNMD_CCCD_Already_Exists = "Identity card number or Citizen's identity card is registered before";
            Error_Limit_User_8_char = "Account name must have at least 8 characters and special characters are not allowed";
            Error_Re_register = "Entered incorrectly too many times, please re-register!";
        }
    }
}
