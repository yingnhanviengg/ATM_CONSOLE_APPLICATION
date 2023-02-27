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
            // Menu login
            Login = "Đăng Nhập";
            Register = "Đăng Ký";
            Change_Language = "Chuyển ngôn ngữ";
            // menu admin
            Card_Manager_Admin = "Quản lý thẻ ATM ";
            Information_Manager_Admin = "Quản lý thông tin khách hàng";
            Recharge_Manager_Admin = "Kiểm tra yêu cầu nạp tiền";
            Transaction_History_Manager_Admin = "Kiểm tra lịch sử giao dịch";
            BackMenu = "Quay trở về";
            // menu customer
            Card_Customer = "Kiểm tra thẻ ATM";
            Information_Customer = "Kiểm tra thông tin tài khoản";
            Withdraw_Money_Customer = "Rút tiền";
            Recharge_Customer = "Nạp tiền";
            Tranfer_Money_Customer = "Chuyển khoản";
            Transaction_History_Customer = "Kiểm tra lịch sử giao dịch";
            History_Tranfer = "Lịch sử chuyển tiền";
            History_Withdraw_Recharge = "Lịch sử nạp tiền / rút tiền";
            // information
            Check_Account_Information = "Kiểm tra thông tin tài khoản";
            Update_Information_Success = "Cập nhật thông tin tài khoản thành công";
            Update_Information_Error = "Cập nhật thông tin tài khoản thất bại";
            Update_Information = "Cập nhật thông tin tài khoản ";
            Name_Current = "Họ và tên hiện tại: ";
            DateOfBirth_Current = "Ngày/Tháng/Năm sinh hiện tại: ";
            Gender_Current = "Giới tính hiện tại: ";
            CMND_CCCD_Current = "CMND/CCCD hiện tại: ";
            Address_Current = "Địa chỉ hiện tại: ";
            Email_Current = "Email hiện tại: ";
            SDT_Current = "Số điện thoại hiện tại: ";
            IsUpdate = "Có muốn sửa giá trị này không? (Y hoặc N)";
            // Login
            Input_User = "Nhập tài khoản: ";
            Input_Pass = "Nhập mật khẩu: ";
            Notification_Login_True = "Đăng nhập thành công";
            Notification_Login_Fasle = "Đăng nhập thất bại, sai mật khẩu vui lòng nhập lại";
            Account_Is_Locked = "Tài khoản bị khóa, liên hệ quản trị viên để được hỗ trợ";
            UserNotExist = "Tài khoản không tồn tại";
            LimitReached_Lock = "nhập sai sẽ bị khóa tài khoản tạm thời";
            Account_HasLocked = "Nhập sai mật khẩu nhiều lần, tài khoản đã bị khóa vui lòng liên hệ quản trị viên để được hỗ trợ";
            // Input
            Input_Fullname = "Nhập họ và tên: ";
            Input_DateOfBirth = "Nhập ngày/tháng/năm sinh: ";
            Input_Address = "Nhập địa chỉ: ";
            Input_Email = "Nhập email: ";
            Input_Phone = "Nhập số điện thoại: ";
            Input_Gender = "Nhập giới tính (Nam/Nữ): ";
            Input_CMND_CCCD = "Nhập số CMND hoặc CCCD: ";
            Input_IDUser = "Nhập ID khách hàng: ";
            Input_ID_Transaction = "Nhập ID giao dịch: ";
            Input_Card = "Nhập số thẻ: ";
            Input_Card_Error = "Sô thẻ có 16 chữ số và không chứa ký tự đặc biệt";
            Exception_choose = "Chỉ được nhấp số";
            Input_PassCard = "Nhập mật khẩu thẻ: ";
            Input_PassCard_Error = "Mật khẩu thẻ là 4 số tự nhiên, không có ký tự đặc biệt";
            // Register
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
            Created_Card_Success = "Tạo thẻ thành công";
            Error_Create_Card = "Tạo thẻ thất bại";
            No_CardYet = "Bạn chưa tạo thẻ ngân hàng.\nCó muốn tạo thẻ ngân hàng ngay không? (Y/N)";
            IsY_or_N = "Chỉ được nhập Y hoặc N";
            Show_All_Card = "Hiển thị tất cả thẻ ATM";
            Lock_Card = "Tạm khóa thẻ ATM";
            UnLock_Card = "Mở khóa thẻ ATM";
            Lock_Card_Success = "Khóa thẻ thành công";
            Lock_Card_Error = "Khóa thẻ thất bại kiểm tra nhập lại số thẻ";
            UnLock_Card_Success = "Mở khóa thẻ thành công";
            UnLock_Card_Error = "Mở khóa thẻ thất bại";
            //
            Lock_account = "Tạm khóa tài khoản khách hàng";
            unLock_account = "Mở khóa tài khoản khách hàng";
            Lock_Account_Success = "Khóa tài khoản thành công";
            NotFind_ID = "Không tìm thấy ID khách hàng";
            Unlock_Account_Success = "Mở khóa tài khoản thành công";
            // Reacharge
            Input_Amount = "Nhập số tiền: ";
            SendRequire_Racharge_Success = "Gửi yêu cầu nạp tiền thành công\nVui lòng đợi quản trị viên phê duyệt";
            SendRequire_Racharge_Error = "Gửi yêu nạp tiền thất bại";
            NotFind_Transaction = "Không tìm thấy giao dịch";
            Confirm_Reacharge_Success = "Xác nhận nạp tiền, cập nhật số dư thành công";
            IsConfirm_Recharge = "Có đồng ý xác nhận giao dịch này không (Y/N)?";
            // tranfer
            Input_NumberBank_Recipient = "Nhập số tài khoản người nhận: ";
            Input_NumberBank_Recipient_Error = "Số tài khoản không hợp lệ, số tài khoản có 10 chữ số và không có ký tự đặc biệt";
            NumberBank_NotExist = "Số tài khoản người nhận không tồn tại";
            NumberBank_Lock = "Tài khoản người nhận đang bị khóa";
            Tranfer_Success = "Chuyển khoản thành công";
            Tranfer_Error = "Chuyển khoản thất bại";
            // Withdraw
            CardNotExistOrLock = "Sai mã số thẻ và mật khẩu hoặc thẻ đang bị tạm khóa vui lòng liên hệ quản trị viên để được hỗ trợ";
            Withdraw_Success = "Rút tiền thành công";
            Error_insufficientBalance = "Số dư không đủ để thực hiện giao dịch";
        }
    }
}
