using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ATM_CONSOLE_APPLICATION.Model;
using MySql.Data.MySqlClient;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllerUser
    {
        public static List<ModelUser> ListUsers { get; set; } = new List<ModelUser>();
        public ControllerUser() { ModelUser.GetListUser(); }
        public int IsRegister(string fullname, DateTime DateOfBirth, string Address, string user, string pass, string email, string phone)
        {
            foreach (var item in ListUsers)
            {
                if (item.Username.Equals(user)) // tài khoản đã tồn tại
                {
                    return -1;
                }
                else if (item.Email.Equals(email)) // email đã tồn tại
                {
                    return -2;
                }
                else if (item.Phone.Equals(phone)) // sdt đã tồn tại
                {
                    return -3;
                }
            }
            string code = SendMail.GenerateRandomCode();
            SendMail.SendMailCode(code);
            if (ModelUser.IsRegister(fullname, DateOfBirth, Address, user, pass, email, phone))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        public bool IsLoggedIn(string user, string pass)
        {
            foreach (var item in ListUsers)
            {
                if (user.Equals(item.Username) && pass.Equals(item.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
