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
        private ControllerBank_User() { }
        public static List<ModelUser> ListUsers { get; set; } = new List<ModelUser>();
        public static List<ModelBank_Account> ListBank_User
        {
            get { return ModelBank_Account._ListBank_User; }
        }
        public static ModelBank_Account User
        {
            get { return ModelBank_Account._User;}
        }
        private static ControllerBank_User _ControllerUser;      
        public static ControllerBank_User ControllerUser
        {
            get
            {
                if (_ControllerUser == null)
                {
                    _ControllerUser = new ControllerBank_User();
                }
                return _ControllerUser;
            }
        }      
        public int IsRegister(string CMND_CCCD, string user, string mail, string phone)
        {
            try
            {
                //ListBank_User = new List<ModelBank_Account>();
                ModelBank_Account.GetList_All_Bank_User();
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
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ListBank_User.Clear();
            }
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
            if (ModelBank_Account.IsLoggedIn(user, pass))
            {             
                if (User.role.Equals("admin"))
                {
                    //ListBank_User = new List<ModelBank_Account>();
                    ModelBank_Account.GetList_All_Bank_User();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
