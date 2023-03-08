using System.Security.Principal;

namespace ATM_CONSOLE_APPLICATION.Language
{
    public abstract class AbstractLanguage
    {
        public abstract void ChangeLanguage();
        public static string LogOut { get; set; }
        public static string Change_Language { get; set; }
        public static string Current_Language { get; set; }
        public static string Enter_Code { get; set; }
        public static string Error_Code { get; set; }
        public static string Error_Code_Limit_3 { get; set; }
        public static string Login { get; set; }
        public static string Register { get; set; }
        // Menu customer
        public static string Card_Customer { get; set; }
        public static string Information_Customer { get; set; }
        public static string Withdraw_Money_Customer { get; set; }
        public static string Recharge_Customer { get; set; }
        public static string Tranfer_Money_Customer { get; set; }
        public static string Transaction_History_Customer { get; set; }
        public static string History_Tranfer { get; set; }
        public static string History_Withdraw_Recharge { get; set; }
        //Menu Admin
        public static string Card_Manager_Admin { get; set; }
        public static string Information_Manager_Admin { get; set; }
        public static string Recharge_Manager_Admin { get; set; }
        public static string Transaction_History_Manager_Admin { get; set; }
        public static string BackMenu { get; set; }
        // information
        public static string Check_Account_Information { get; set; }
        public static string Update_Information { get; set; }
        public static string Update_Information_Success { get; set; }
        public static string Update_Information_Error { get; set; }
        public static string Name_Current { get; set; }
        public static string DateOfBirth_Current { get; set; }
        public static string Gender_Current { get; set; }
        public static string CMND_CCCD_Current { get; set; }
        public static string Address_Current { get; set; }
        public static string Email_Current { get; set; }
        public static string SDT_Current { get; set; }
        public static string IsUpdate { get; set; }
        // Login
        public static string Input_User { get; set; }
        public static string Input_Pass { get; set; }
        public static string Notification_Login_True { get; set; }
        public static string Notification_Login_Fasle { get; set; }
        public static string Account_Is_Locked { get; set; }
        public static string UserNotExist { get; set; }
        public static string LimitReached_Lock { get; set; }
        public static string Account_HasLocked { get; set; }
        // Input
        public static string Input_Fullname { get; set; }
        public static string Input_DateOfBirth { get; set; }
        public static string Input_Address { get; set; }
        public static string Input_Email { get; set; }
        public static string Error_Input_Email { get; set; }
        public static string Input_Phone { get; set; }
        public static string Input_Gender { get; set; }
        public static string Input_CMND_CCCD { get; set; }
        public static string Input_ID_Transaction { get; set; }
        public static string Input_Card { get; set; }
        public static string Input_Card_Error { get; set; }
        public static string Exception_choose { get; set; }
        public static string Input_Amount { get; set; }
        public static string Input_PassCard { get; set; }
        public static string Input_PassCard_Error { get; set; }
        // Register
        public static string Error_Input_Gender { get; set; }
        public static string Error_Input_CMND { get; set; }
        public static string Error_Input_Phone { get; set; }
        public static string Error_Input_Pass { get; set; }
        public static string Input_IDUser { get; set; }
        public static string Register_Success { get; set; }
        public static string Registration_Failed { get; set; }
        public static string Error_Email_Already_Exists { get; set; }
        public static string Error_Invalid_DateOfBirth { get; set; }
        public static string Error_Phone_Already_Exists { get; set; }
        public static string Error_CNMD_CCCD_Already_Exists { get; set; }
        public static string Error_User_Already_Exists { get; set; }
        public static string Error_Limit_User_8_char { get; set; }
        public static string Error_Re_register { get; set; }
        // Card
        public static string Created_Card_Success { get; set; }
        public static string Error_Create_Card { get; set; }
        public static string No_CardYet { get; set; }
        public static string IsY_or_N { get; set; }
        public static string Show_All_Card { get; set; }
        public static string Lock_Card { get; set; }
        public static string UnLock_Card { get; set; }
        public static string Lock_Card_Success { get; set; }
        public static string Lock_Card_Error { get; set; }
        public static string UnLock_Card_Success { get; set; }
        public static string UnLock_Card_Error { get; set; }

        //
        public static string Lock_account { get; set; }
        public static string unLock_account { get; set; }
        public static string Lock_Account_Success { get; set; }
        public static string NotFind_ID { get; set; }
        public static string Unlock_Account_Success { get; set; }
        // Reacharge      
        public static string SendRequire_Racharge_Success { get; set; }
        public static string SendRequire_Racharge_Error { get; set; }
        public static string NotFind_Transaction { get; set; }
        public static string Confirm_Reacharge_Success { get; set; }
        public static string IsConfirm_Recharge { get; set; }
        // Tranfer Money
        public static string Input_NumberBank_Recipient { get; set; }
        public static string Input_NumberBank_Recipient_Error { get; set; }
        public static string NumberBank_NotExist { get; set; }
        public static string NumberBank_Lock { get; set; }
        public static string Tranfer_Success { get; set; }
        public static string Tranfer_Error { get; set; }
        // Withdraw
        public static string CardNotExistOrLock { get; set; }
        public static string IncorretPassCard { get; set; }
        public static string Withdraw_Success { get; set; }
        public static string Error_insufficientBalance { get; set; }
        public static string Card_HasLocked { get; set; }
        //Table
        public static string FullName { get; set; }
        public static string Birth { get; set; }
        public static string Gender { get; set; }
        public static string Bankaccountnumber { get; set;}
        public static string Balance { get; set; }
        public static string Address { get; set; }
        public static string PhoneNumber { get; set; }
        public static string status { get; set; }
        public static string IDcustomer { get; set; }
        public static string Show { get; set; }
        public static string Customer { get; set; }
        public static string page { get; set; }
        public static string EnterPage { get; set; }
        public static string ErrorFormat { get; set; }
        public static string Nodataavailable { get; set; }
        public static string Invalidpagenumber { get; set; }
        public static string ATMCardNumber { get; set; }
        public static string CardPassword { get; set; }
        public static string CardCreationDate { get; set; }
        public static string CardExpirationDate { get; set; }
        public static string CardStatus { get; set; }
        public static string Card { get; set; }
        public static string request { get; set; }
        public static string TransactionID { get; set; }
        public static string DepositAmount { get; set; }
        public static string RequestStatus { get; set; }
        public static string TimeRequired { get; set; }
        public static string Transactiontype { get; set; }
        public static string Transactionamount { get; set; }
        public static string TransactionStatus { get; set; }
        public static string TimeTransaction { get; set; }
        public static string Transaction { get; set; }
        public static string FullNameSender { get; set; }
        public static string transferamount { get; set; }
        public static string FullNamerecipients { get; set; }
        public static string transfertime { get; set; }
    }
}
