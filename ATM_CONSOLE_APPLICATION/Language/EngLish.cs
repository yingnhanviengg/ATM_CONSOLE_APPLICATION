using Org.BouncyCastle.Asn1.Ocsp;
using Spectre.Console;
using System.Transactions;

namespace ATM_CONSOLE_APPLICATION.Language
{
    public class English : AbstractLanguage
    {
        public override void ChangeLanguage()
        {
            LogOut = "Log Out";
            Current_Language = "English";
            Enter_Code = "Enter verification code: ";
            Error_Code = "Verification code is incorrect";
            Error_Code_Limit_3 = "Number of re-enters ";
            // Menu login
            Login = "Login";
            Register = "Register";
            Change_Language = "Switch language";
            // menu admin
            Card_Manager_Admin = "ATM card management ";
            Information_Manager_Admin = "Customer Information Management";
            Recharge_Manager_Admin = "Check deposit request";
            Transaction_History_Manager_Admin = "Check transaction history";
            BackMenu = "Back";
            // menu customer
            Card_Customer = "Check ATM card";
            Information_Customer = "Check account information";
            Withdraw_Money_Customer = "Withdraw money";
            Recharge_Customer = "Recharge";
            Tranfer_Money_Customer = "Transfer";
            Transaction_History_Customer = "Check transaction history";
            History_Tranfer = "Money transfer history";
            History_Withdraw_Recharge = "Deposit/withdrawal history";
            // information
            Check_Account_Information = "Check account information";
            Update_Information_Success = "Successfully updated account information";
            Update_Information_Error = "Account information update failed";
            Update_Information = "Update account information ";
            Name_Current = "Current first and last name: ";
            DateOfBirth_Current = "Current date/month/year of birth: ";
            Gender_Current = "Current gender: ";
            CMND_CCCD_Current = "Current ID/CCCD: ";
            Address_Current = "Current address: ";
            Email_Current = "Current email: ";
            SDT_Current = "Current phone number: ";
            IsUpdate = "Do you want to update this value? (Y or N)";
            // Login
            Input_User = "Enter username: ";
            Input_Pass = "Enter password: ";
            Notification_Login_True = "Login successful";
            Notification_Login_Fasle = "Login failed, incorrect password. Please try again.";
            Account_Is_Locked = "Account is locked. Please contact the administrator for assistance";
            UserNotExist = "Username does not exist";
            LimitReached_Lock = "incorrect entries will result in temporary lockout";
            Account_HasLocked = "Entered incorrect password multiple times. Account has been locked. Please contact the administrator for assistance";
            // Input
            Input_Fullname = "Enter full name: ";
            Input_DateOfBirth = "Enter date/month/year of birth: ";
            Input_Address = "Enter address: ";
            Input_Email = "Enter email: ";
            Input_Phone = "Enter phone number: ";
            Input_Gender = "Enter gender (Male/Female): ";
            Input_CMND_CCCD = "Enter ID/CCCD number: ";
            Input_IDUser = "Enter customer ID: ";
            Input_ID_Transaction = "Enter transaction ID: ";
            Input_Card = "Enter card number: ";
            Input_Card_Error = "Card number must be 16 digits and not contain special characters";
            Exception_choose = "Only number keys are allowed";
            Input_PassCard = "Enter card password: ";
            Input_PassCard_Error = "Card password must be 4 digits and not contain special characters";
            // Register
            Error_Input_Gender = "Invalid gender input";
            Error_Input_CMND = "Invalid ID/CCCD input";
            Error_Input_Email = "Invalid email input";
            Error_Input_Phone = "Invalid phone number input \nPhone number must start with 0 and have 9-11 digits";
            Error_Input_Pass = "Password must have at least 8 characters";
            Register_Success = "Registration successful";
            Registration_Failed = "Registration failed";
            Error_Invalid_DateOfBirth = "Incorrect date of birth format";
            Error_Email_Already_Exists = "This email has already been used";
            Error_Phone_Already_Exists = "This phone number has already been used";
            Error_User_Already_Exists = "This username has already been used";
            Error_CNMD_CCCD_Already_Exists = "This ID card or passport has already been used";
            Error_Limit_User_8_char = "Username must have at least 8 characters and not contain special characters";
            Error_Re_register = "Incorrect input too many times, please register again";
            // Card
            Created_Card_Success = "Card created successfully";
            Error_Create_Card = "Card creation failed";
            No_CardYet = "You haven't created a bank card yet. \nDo you want to create a bank card now? (Y/N)";
            IsY_or_N = "Only allowed to enter Y or N";
            Show_All_Card = "Display all ATM cards";
            Lock_Card = "Temporary lock ATM card";
            UnLock_Card = "Unlock ATM card";
            Lock_Card_Success = "Card locked successfully";
            Lock_Card_Error = "Card lock failed, check the card number and try again";
            UnLock_Card_Success = "Card unlocked successfully";
            UnLock_Card_Error = "Card unlocking failed";
            //
            Lock_account = "Temporarily lock customer account";
            unLock_account = "Unlock customer account";
            Lock_Account_Success = "Account locked successfully";
            NotFind_ID = "ID not found";
            Unlock_Account_Success = "Account unlocked successfully";
            // Recharge
            Input_Amount = "Enter the amount: ";
            SendRequire_Racharge_Success = "Send recharge request successfully \nPlease wait for administrator approval";
            SendRequire_Racharge_Error = "Send recharge request failed";
            NotFind_Transaction = "Transaction not found";
            Confirm_Reacharge_Success = "Confirm recharge successfully, balance updated";
            IsConfirm_Recharge = "Do you agree to confirm this transaction (Y/N)?";
            // Transfer
            Input_NumberBank_Recipient = "Enter recipient's account number: ";
            Input_NumberBank_Recipient_Error = "Invalid account number, the account number must have 10 digits and no special characters";
            NumberBank_NotExist = "Recipient's account number does not exist";
            NumberBank_Lock = "Recipient's account is locked";
            Tranfer_Success = "Transfer successful";
            Tranfer_Error = "Transfer failed";
            // Withdraw
            CardNotExistOrLock = "Incorrect card number or the card is temporarily locked. Please contact the administrator for support";
            IncorretPassCard = "Incorrect card password";
            Withdraw_Success = "Withdrawal successful";
            Error_insufficientBalance = "Insufficient balance to perform the transaction";
            Card_HasLocked = "Incorrect password entered too many times, the card has been locked. Please contact the administrator for support";
            //Table
            FullName = "Full Name";
            Birth = "Date of Birth";
            Gender = "Gender";
            Bankaccountnumber = "Bank Account Number";
            Balance = "Balance";
            Address = "Address";
            PhoneNumber = "Phone Number";
            status = "Status";
            IDcustomer = "ID Customer";
            Show = "Show";
            Customer = "Customer";
            page = "Page";
            EnterPage = "Enter the page number: ";
            ErrorFormat = "Enter the wrong format";
            Nodataavailable = "No data available";
            Invalidpagenumber = "Invalid page number";
            ATMCardNumber = "ATM Card Number";
            CardPassword = "Card Password";
            CardCreationDate = "Card Creation Date";
            CardExpirationDate = "Expiration date";
            CardStatus = "Card Status";
            Card = "card";
            request = "request";
            TransactionID = "Transaction ID";
            DepositAmount = "Deposit Amount";
            RequestStatus = "Request Status";
            TimeRequired = "Time Required";
            Transactiontype = "Transaction Type";
            Transactionamount = "Transaction amount";
            TransactionStatus = "Transaction Status";
            TimeTransaction = "Time Transaction";
            Transaction = "transaction";
            FullNameSender = "Full Name Sender";
            transferamount = "Transfer Amount";
            FullNamerecipients = "Full Name Recipients";
            transfertime = "Transfer Time";
        }
    }
}
