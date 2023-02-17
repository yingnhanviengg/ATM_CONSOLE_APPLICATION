using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_CONSOLE_APPLICATION.View;
using static Google.Apis.Requests.RequestError;

namespace ATM_CONSOLE_APPLICATION
{
    public class Language
    {
        public static string Change_Language { get; set; }
        public static string Current_Language { get; set; }
        public static string Enter_Code { get; set; }
        public static string Error_Code { get; set; }
        public static string Error_Code_Limit_3 { get; set; }
        public static string Login { get; set; }
        public static string Register { get; set; }
        // Menu actor người dùng
        public static string Card_Management { get; set; }
        public static string Check_Account_Information { get; set; }
        public static string Withdraw_Money { get; set; }
        public static string Recharge { get; set; }
        public static string Tranfer_Money { get; set; }
        public static string Bank_Deposit { get; set; }
        public static string Transaction_History { get; set; }    
        // Menu actor Admin
        public static string Check_Account_Information_Admin { get; set; }
        public static string Transaction_History_Admin { get; set; }
        public static string Transaction_Statistics { get; set; }
        //Chosse
        public static string Input_choose { get; set; }
        public static string Exception_choose { get; set; }
        public static string Exception_choose_switch { get; set; }
        // Login
        public static string Input_User { get; set; }
        public static string Input_Pass { get; set; }
        public static string Notification_Login_True { get; set; }
        public static string Notification_Login_Fasle { get; set; }
        // Register
        public static string Input_Fullname { get; set; }
        public static string Input_DateOfBirth { get; set; }
        public static string Input_Address { get; set; }
        public static string Input_Email { get; set; }
        public static string Error_Input_Email { get; set; }
        public static string Input_Phone { get; set; }
        public static string Input_Gender { get; set; }
        public static string Input_CMND_CCCD { get; set; }
        public static string Error_Input_Gender { get; set; }
        public static string Error_Input_CMND { get; set; }
        public static string Error_Input_Phone { get; set; }
        public static string Error_Input_Pass { get; set; }
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
        public static string Input_Card_Type { get; set; }
        public static string Created_Card_Success { get; set; }
        public static string Error_Create_Card { get; set; }
        public static string No_CardYet { get; set; }
        public static string Update_Information { get; set; }
        public static string IsY_or_N { get; set; }
        public static string IsUpdate { get; set; }
        public static string Name_Current { get; set; }
        public static string DateOfBirth_Current { get; set; }
        public static string Gender_Current { get; set; }
        public static string CMND_CCCD_Current { get; set; }
        public static string Address_Current { get; set; }
        public static string Email_Current { get; set; }
        public static string SDT_Current { get; set; }
        public static string Update_Information_Success { get; set; }
        public static string Update_Information_Error { get; set; }

        public static void Vietnamese()
        {
            Current_Language = "Vietnamese";
            Enter_Code = "Nhập mã xác minh: ";
            Error_Code = "Mã xác minh không chính xác";
            Error_Code_Limit_3 = "Số lần nhập lại ";          
            // Menu actor người dùng
            Login = "Đăng Nhập";
            Register = "Đăng Ký";
            Card_Management = "Quản lý thẻ";
            Check_Account_Information = "Kiểm tra thông tin tài khoản";
            Withdraw_Money = "Rút tiền";
            Recharge = "Nạp tiền";
            Tranfer_Money = "Chuyển khoản";
            Bank_Deposit = "Gửi tiết kiệm";
            Transaction_History = "Kiểm tra lịch sử giao dịch";
            Change_Language = "Chuyển ngôn ngữ";
            // Menu actor Admin
            Check_Account_Information_Admin = "Kiểm tra thông tin tài khoản";
            Transaction_History_Admin = "Kiểm tra lịch sử giao dịch";
            Transaction_Statistics = "Thống kê giao dịch";
            // Chosse
            Input_choose = "Nhập lựa chọn: ";
            Exception_choose = "Chỉ được nhập số";
            Exception_choose_switch = "Nhập sai lựa chọn";
            // Login
            Input_User = "Nhập tài khoản: ";
            Input_Pass = "Nhập mật khẩu: ";
            Notification_Login_True = "Đăng nhập thành công";
            Notification_Login_Fasle = "Đăng nhập ko thành công";
            // Register
            Input_Fullname = "Nhập họ và tên: ";
            Input_DateOfBirth = "Nhập ngày/tháng/năm sinh: ";
            Input_Address = "Nhập địa chỉ: ";
            Input_Email = "Nhập email: ";
            Input_Phone = "Nhập số điện thoại: ";
            Input_Gender = "Nhập giới tính (Nam/Nữ): ";
            Input_CMND_CCCD = "Nhập số CMND hoặc CCCD: ";
            Error_Input_Gender = "Nhập giới tính không hợp lệ";
            Error_Input_CMND = "Nhập CMND hoặc CCCD không hợp lệ";
            Error_Input_Email = "Nhập email không hợp lệ";
            Error_Input_Phone = "Nhập số điện thoại không hợp lệ \nSố điện thoại bắt đầu bằng số 0 và có từ 9 đến 11 số";
            Error_Input_Pass = "Mật khẩu có tối thiểu 8 ký tự";
            Register_Success = "Đăng ký thành công";
            Registration_Failed = "Đăng ký thất bại";
            Error_Invalid_DateOfBirth = "Nhập sai định dạng ngày tháng năm";
            Error_Email_Already_Exists = "Email này đã được đăng ký trước";
            Error_Phone_Already_Exists = "Số điện thoại này đã được đăng ký trước";
            Error_User_Already_Exists = "Tên tài khoản đã được đăng ký trước";
            Error_CNMD_CCCD_Already_Exists = "CMND hoặc CCCD đã được đăng ký trước";
            Error_Limit_User_8_char = "Tên tài khoản phải có tối thiểu 8 chữ số, không được phép có ký tự đặc biệt";
            Error_Re_register = "Nhập sai quá nhiều lần, vui lòng đăng ký lại";
            // Card
            Input_Card_Type = "Nhập loại thẻ muốn đăng ký (Napas - Visa - Mastercard): ";
            Created_Card_Success = "Tạo thẻ thành công";
            Error_Create_Card = "Tạo thẻ thất bại";
            No_CardYet = "Bạn chưa tạo thẻ ngân hàng.\nCó muốn tạo thẻ ngân hàng ngay không? (Y/N)";
            Update_Information = "Cập nhật thông tin tài khoản ";
            IsY_or_N = "Chỉ được nhập Y hoặc N";
            IsUpdate = "Có muốn sửa giá trị này không? (Y hoặc N)";
            Name_Current = "Họ và tên hiện tại: " ;
            DateOfBirth_Current = "Ngày/Tháng/Năm sinh hiện tại: ";
            Gender_Current = "Giới tính hiện tại: ";
            CMND_CCCD_Current = "CMND/CCCD hiện tại: ";
            Address_Current = "Địa chỉ hiện tại: ";
            Email_Current = "Email hiện tại: ";
            SDT_Current = "Số điện thoại hiện tại: ";
            Update_Information_Success = "Cập nhật thông tin tài khoản thành công";
            Update_Information_Error = "Cập nhật thông tin tài khoản thất bại";
        }
        public static void English()
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
        public static void _Change_Language()
        {
            while (true)
            {
                int x;
                Console.WriteLine("1: English");
                Console.WriteLine("2: Vietnamese");
                switch (x = Common.Choose())
                {
                    case 1:
                        Language.English();
                        break;
                    case 2:
                        Language.Vietnamese();
                        break;
                    default:
                        Common.PrintMessage_Console(Language.Exception_choose_switch, false);
                        break;
                }
                if (x == 1 || x == 2)
                {
                    break;
                }
            }
        }
    }
}
