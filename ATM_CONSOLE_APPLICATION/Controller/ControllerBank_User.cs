using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ATM_CONSOLE_APPLICATION.Model;
using MySql.Data.MySqlClient;
using ATM_CONSOLE_APPLICATION.Controller.email;
using Microsoft.Win32;
using Org.BouncyCastle.Math.Field;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllerBank_User
    {
        private ControllerBank_User() { UserBank.GetList_All_Bank_User(); }     
        public static List<ModelBank_Account> ListBank_User
        {
            get { return ModelBank_Account._ListBank_User; }
        }
        public static ModelBank_Account UserBank
        {
            get { return ModelBank_Account.UserBank;}
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
        public bool Unlock_Account(ModelBank_Account modelBank_Account)
        {
            var userindex = ListBank_User.FindIndex(x => x.ID_User.Equals(modelBank_Account.ID_User));
            if (userindex != -1)
            {
                var user = ListBank_User[userindex];
                user.status_user = modelBank_Account.status_user;
                return modelBank_Account.UnLock_Account(user);
            }
            else
            {
                return false;
            }
        }
        public bool Lock_Account(ModelBank_Account modelBank_Account)
        {
            var userindex = ListBank_User.FindIndex(x => x.ID_User.Equals(modelBank_Account.ID_User));
            if (userindex != -1)
            {
                var user = ListBank_User[userindex];
                user.status_user = modelBank_Account.status_user;
                return modelBank_Account.Lock_Account(modelBank_Account);
            }
            else
            {
                return false;
            }
        }
        public bool Upate_Information(ModelBank_Account modelBank_Account)
        {
            if (modelBank_Account.Update_Information(modelBank_Account))
            {
                if (UserBank.role.Equals("customer") || modelBank_Account.ID_User.Equals(UserBank.ID_User))
                {
                    Update_User(modelBank_Account);
                }
                UpdateList_User(modelBank_Account);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int IsValidUpdate(ModelBank_Account modelBank_Account)
        {
            var index = ListBank_User.FindIndex(x => x.ID_User.Equals(modelBank_Account.ID_User));
            var valid = ListBank_User[index];
            if (!modelBank_Account.CMND_CCCD.Equals(valid.CMND_CCCD))
            {
                if (FindCMND_CCCD(modelBank_Account))
                {
                    return -4;
                }
            }
            if (!modelBank_Account.Phone.Equals(valid.Phone))
            {
                if (FindPhone(modelBank_Account))
                {
                    return -3;
                }
            }
            if (!modelBank_Account.Email.Equals(valid.Email))
            {
                if (FindEmail(modelBank_Account))
                {
                    return -2;
                }
            }
            return 1;
        }
        public bool FindUser(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.Username == modelBank_Account.Username))
            {
                return true; // tài khoản đã tồn tại
            }
            return false;
        }
        public bool FindEmail(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.Email == modelBank_Account.Email))
            {
                return true; // email đã tồn tại
            }
            return false;
        }
        public bool FindPhone(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.Phone == modelBank_Account.Phone))
            {
                return true; // sdt đã tồn tại
            }
            return false;
        }
        public bool FindCMND_CCCD(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.CMND_CCCD == modelBank_Account.CMND_CCCD))
            {
                return true; // CMND_CCCD đã tồn tại
            }
            return false;
        }
        public int IsRegister(ModelBank_Account modelBank_Account)
        {
            if (FindUser(modelBank_Account))
            {
                return -1; // tài khoản đã tồn tại
            }
            if (FindEmail(modelBank_Account))
            {
                return -2; // email đã tồn tại
            }
            if (FindPhone(modelBank_Account))
            {
                return -3; // sdt đã tồn tại
            }
            if (FindCMND_CCCD(modelBank_Account))
            {
                return -4; // CMND_CCCD đã tồn tại
            }
            return 1;
        }
        public void UpdateList_User(ModelBank_Account modelBank_Account)
        {
            var userindex = ListBank_User.FindIndex(x => x.ID_User.Equals(modelBank_Account.ID_User));
            if (userindex != -1)
            {
                var user = ListBank_User[userindex];
                if (user != null)
                {
                    user.FullName = modelBank_Account.FullName;
                    user.DateOfBirth = modelBank_Account.DateOfBirth;
                    user.Gender = modelBank_Account.Gender;
                    user.CMND_CCCD = modelBank_Account.CMND_CCCD;
                    user.Address = modelBank_Account.Address;
                    user.Email = modelBank_Account.Email;
                    user.Password = modelBank_Account.Password;
                }    
            }    
        }
        public void Update_User(ModelBank_Account modelBank_Account)
        {
            UserBank.FullName = modelBank_Account.FullName;
            UserBank.DateOfBirth = modelBank_Account.DateOfBirth;
            UserBank.Gender = modelBank_Account.Gender;
            UserBank.CMND_CCCD = modelBank_Account.CMND_CCCD;
            UserBank.Address = modelBank_Account.Address;
            UserBank.Email = modelBank_Account.Email;
            UserBank.Phone = modelBank_Account.Phone;
        }
        public int SearchUserIndexByID(int id)
        {
            int minIndex = 0;
            int maxIndex = ListBank_User.Count - 1;
            while (minIndex <= maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;
                var item = ListBank_User[midIndex];

                if (item.ID_User < id)
                {
                    minIndex = midIndex + 1;
                }
                else if (item.ID_User > id)
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    return midIndex;
                }
            }
            return -1;
        }
        public bool Register(string code, ModelBank_Account modelBank_Account)
        {
            if (Email.code == null || !Email.code.Equals(code))
            {
                return false;
            }           
            bool isUserRegistered = modelBank_Account.IsRegister(modelBank_Account);
            bool isBankAccountCreated = modelBank_Account.Create_Bank_Account(modelBank_Account.Select_ID_User(modelBank_Account), (modelBank_Account.Number_Bank = GenerateRandomNumberBank()));
            modelBank_Account.GetList_All_Bank_User();
            Email templateMail = new TempMailRegister_Success();
            bool isMailSent = templateMail.Mail(modelBank_Account);
            return isUserRegistered && isBankAccountCreated && isMailSent;
        }

        public string GenerateRandomNumberBank()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public int IsLoggedIn(ModelBank_Account modelBank_Account)
        {
            var item = ListBank_User.FirstOrDefault(u => u.Username == modelBank_Account.Username && u.Password == modelBank_Account.Password);
            if (item != null && item.status_user.Equals("normal"))
            {
                modelBank_Account.GetBank_User(item);
                return 1;
            }
            else if (item != null && item.status_user.Equals("lock"))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
