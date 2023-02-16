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
    public class ControllerBank_User
    {
        public static List<ModelUser> ListUsers { get; set; } = new List<ModelUser>();
        public static List<ModelBank_Account> ListBank_User { get; set; } = new List<ModelBank_Account>();
        public static ModelUser User { get; set; }
        public ControllerBank_User() { ModelBank_Account.GetListBank_User(); }
        public int IsRegister(string CMND_CCCD, string user, string mail, string phone)
        {
            foreach (var item in ListBank_User)
            {
                if (item.Username.Equals(user)) // tài khoản đã tồn tại
                {
                    return -1;
                }
                else if (item.Email.Equals(mail)) // email đã tồn tại
                {
                    return -2;
                }
                else if (item.Phone.Equals(phone)) // sdt đã tồn tại
                {
                    return -3;
                }
                else if (item.CMND_CCCD.Equals(CMND_CCCD)) // CMND_CCCD đã tồn tại
                {
                    return -4;
                }
            }
            return 1;
        }       

        public bool Register(string code, string fullname, string gender, DateTime DateOfBirth, string Address, string CMND_CCCD, string user, string pass, string mail, string phone)
        {
            if (Email.code.Equals(code))
            {
                if (ModelUser.IsRegister(fullname, gender, DateOfBirth, Address, CMND_CCCD, user, pass, mail, phone))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }          
        }
        public bool IsLoggedIn(string user, string pass)
        {
            foreach (var item in ListBank_User)
            {
                if (user.Equals(item.Username) && pass.Equals(item.Password))
                {
                    User = new ModelUser(item.ID_User, item.FullName, item.DateOfBirth, item.Gender, item.CMND_CCCD, item.Address, item.Username, item.Password, item.Email, item.Phone, item.created_at, item.role, item.status_user);
                    return true;
                }
            }
            return false;
        }
    }
}
