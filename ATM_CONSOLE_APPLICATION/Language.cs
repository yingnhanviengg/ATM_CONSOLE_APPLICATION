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
        public static string Enter_Code { get; set; }
        public static string Error_Code { get; set; }
        public static string Error_Code_Limit_3 { get; set; }
        public static string Current_Language { get; set; }
        public static string Login { get; set; }
        public static string Register { get; set; }
        // Menu actor người dùng
        public static string Check_Bank_Balance { get; set; }
        public static string Check_Account_Information { get; set; }
        public static string Withdraw_Money { get; set; }
        public static string Recharge { get; set; }
        public static string Tranfer_Money { get; set; }
        public static string Bank_Deposit { get; set; }
        public static string Transaction_History { get; set; }
        public static string Languege { get; set; }
        // Menu actor Admin
        public static string Check_Account_Information_Admin { get; set; }
        public static string Transaction_History_Admin { get; set; }
        public static string Transaction_Statistics { get; set; }
        //Chosse
        public static string Input_choose { get; set; }
        public static string Exception_choose { get; set; }
        public static string Exception_choose_switch { get; set; } = "Nhập sai lựa chọn";
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
        public static string Register_Success { get; set; }
        public static string Registration_Failed { get; set; }
        public static string Error_Email_Already_Exists { get; set; }
        public static string Error_Invalid_BateOfBirth { get; set; }
        public static string Error_Phone_Already_Exists { get; set; }
        public static string Error_CNMD_CCCD_Already_Exists { get; set; }
        public static string Error_User_Already_Exists { get; set; }
        public static string Error_Limit_User_8_char { get; set; }
        public static void Vietnamese()
        {
            Enter_Code = "Nhập mã xác minh: ";
            Error_Code = "Mã xác minh không chính xác";
            Error_Code_Limit_3 = "Số lần nhập lại ";
            Current_Language = "Vietnamese";
            // Menu actor người dùng
            Login = "Đăng Nhập";
            Register = "Đăng Ký";
            Check_Bank_Balance = "Kiểm tra số dư tài khoản";
            Check_Account_Information = "Kiểm tra thông tin tài khoản";
            Withdraw_Money = "Rút tiền";
            Recharge = "Nạp tiền";
            Tranfer_Money = "Chuyển khoản";
            Bank_Deposit = "Gửi tiết kiệm";
            Transaction_History = "Kiểm tra lịch sử giao dịch";
            Languege = "Chuyển ngôn ngữ";
            // Menu actor Admin
            Check_Account_Information_Admin = "Kiểm tra thông tin tài khoản";
            Transaction_History_Admin = "Kiểm tra lịch sử giao dịch";
            Transaction_Statistics = "Thống kê giao dịch";
            // Chosse
            Input_choose = "Nhập lựa chọn: ";
            Exception_choose = "Chỉ được nhập số";
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
            Register_Success = "Đăng ký thành công";
            Registration_Failed = "Đăng ký thất bại";
            Error_Invalid_BateOfBirth = "Nhập sai định dạng ngày tháng năm";
            Error_Email_Already_Exists = "Email này đã được đăng ký trước";
            Error_Phone_Already_Exists = "Số điện thoại này đã được đăng ký trước";
            Error_User_Already_Exists = "Tên tài khoản đã được đăng ký trước";
            Error_CNMD_CCCD_Already_Exists = "CMND hoặc CCCD đã được đăng ký trước";
            Error_Limit_User_8_char = "Tên tài khoản phải có tối thiểu 8 chữ số, không được phép có ký tự đặc biệt";
        }
        public static void English()
        {
            Current_Language = "English";
            // Menu actor người dùng
            Login = "Login";
            Register = "Register";
            Check_Bank_Balance = "Kiểm tra số dư tài khoản";
            Check_Account_Information = "Kiểm tra thông tin tài khoản";
            Withdraw_Money = "Rút tiền";
            Recharge = "Nạp tiền";
            Tranfer_Money = "Chuyển khoản";
            Bank_Deposit = "Gửi tiết kiệm";
            Transaction_History = "Kiểm tra lịch sử giao dịch";
            Languege = "Chuyển ngôn ngữ";
            // Menu actor Admin
            Check_Account_Information_Admin = "Kiểm tra thông tin tài khoản";
            Transaction_History_Admin = "Kiểm tra lịch sử giao dịch";
            Transaction_Statistics = "Thống kê giao dịch";
            //
            Input_choose = "Nhập lựa chọn: ";
            Exception_choose = "Chỉ được nhập số";
        }
    }
}
