using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Language
{
    public class VietNamese : AbstractLanguage
    {
        public override void ChangeLanguage()
        {
            Current_Language = "Vietnamese";
            Enter_Code = "Nhập mã xác minh: ";
            Error_Code = "Mã xác minh không chính xác";
            Error_Code_Limit_3 = "Số lần nhập lại ";
            // Menu actor người dùng
            Login = "Đăng Nhập";
            Register = "Đăng Ký";
            Check_Account_Information = "Kiểm tra thông tin tài khoản";
            Change_Language = "Chuyển ngôn ngữ";

            // Chosse
            Input_choose = "Nhập lựa chọn: ";
            Exception_choose = "Chỉ được nhập số";
            Exception_choose_switch = "Nhập sai lựa chọn";
            // Login
            Input_User = "Nhập tài khoản: ";
            Input_Pass = "Nhập mật khẩu: ";
            Notification_Login_True = "Đăng nhập thành công";
            Notification_Login_Fasle = "Đăng nhập ko thành công";
            Account_Is_Locked = "Tài khoản bị khóa, liên hệ quản trị viên để được hỗ trợ";
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
            Error_Email_Already_Exists = "Email này đã được sử dụng trước";
            Error_Phone_Already_Exists = "Số điện thoại này đã được sử dụng trước";
            Error_User_Already_Exists = "Tên tài khoản đã được sử dụng trước";
            Error_CNMD_CCCD_Already_Exists = "CMND hoặc CCCD đã được sử dụng trước";
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
            Name_Current = "Họ và tên hiện tại: ";
            DateOfBirth_Current = "Ngày/Tháng/Năm sinh hiện tại: ";
            Gender_Current = "Giới tính hiện tại: ";
            CMND_CCCD_Current = "CMND/CCCD hiện tại: ";
            Address_Current = "Địa chỉ hiện tại: ";
            Email_Current = "Email hiện tại: ";
            SDT_Current = "Số điện thoại hiện tại: ";
            Update_Information_Success = "Cập nhật thông tin tài khoản thành công";
            Update_Information_Error = "Cập nhật thông tin tài khoản thất bại";
            Input_IDUser = "Nhập ID khách hàng: ";
            //
            Lock_account = "Tạm khóa tài khoản khách hàng";
            unLock_account = "Mở khóa tài khoản khách hàng";
            Lock_Account_Success = "Khóa tài khoản thành công";
            NotFind_ID = "Không tìm thấy ID khách hàng";
        }
    }
}
