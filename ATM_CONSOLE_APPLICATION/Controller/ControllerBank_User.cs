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
            var userindex = ListBank_User.FindIndex(x => x.User.ID_User.Equals(modelBank_Account.User.ID_User));
            if (userindex != -1)
            {
                var user = ListBank_User[userindex];
                user.User.status_user = modelBank_Account.User.status_user;
                return modelBank_Account.UnLock_Account(user);
            }
            else
            {
                return false;
            }
        }
        public bool Lock_Account(ModelBank_Account modelBank_Account)
        {
            var userindex = ListBank_User.FindIndex(x => x.User.ID_User.Equals(modelBank_Account.User.ID_User));
            if (userindex != -1)
            {
                var user = ListBank_User[userindex].User.status_user = "lock";
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
                if (UserBank.User.role.Equals("customer") && modelBank_Account.User.ID_User.Equals(UserBank.User.ID_User))
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
            var index = ListBank_User.FindIndex(x => x.User.ID_User.Equals(modelBank_Account.User.ID_User));
            var valid = ListBank_User[index];
            if (!modelBank_Account.User.CMND_CCCD.Equals(valid.User.CMND_CCCD))
            {
                if (FindCMND_CCCD(modelBank_Account))
                {
                    return -4;
                }
            }
            if (!modelBank_Account.User.ID_User.Equals(valid.User.ID_User))
            {
                if (FindPhone(modelBank_Account))
                {
                    return -3;
                }
            }
            if (!modelBank_Account.User.ID_User.Equals(valid.User.ID_User))
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
            if (ListBank_User.Any(u => u.User.ID_User == modelBank_Account.User.ID_User))
            {
                return true; // tài khoản đã tồn tại
            }
            return false;
        }
        public bool FindEmail(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.User.Email == modelBank_Account.User.Email))
            {
                return true; // email đã tồn tại
            }
            return false;
        }
        public bool FindPhone(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.User.Phone == modelBank_Account.User.Phone))
            {
                return true; // sdt đã tồn tại
            }
            return false;
        }
        public bool FindCMND_CCCD(ModelBank_Account modelBank_Account)
        {
            if (ListBank_User.Any(u => u.User.CMND_CCCD == modelBank_Account.User.CMND_CCCD))
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
            var userindex = ListBank_User.FindIndex(x => x.User.ID_User.Equals(modelBank_Account.User.ID_User));
            if (userindex != -1)
            {
                var user = ListBank_User[userindex];
                if (user != null)
                {
                    user.User.FullName = modelBank_Account.User.FullName;
                    user.User.DateOfBirth = modelBank_Account.User.DateOfBirth;
                    user.User.Gender = modelBank_Account.User.Gender;
                    user.User.CMND_CCCD = modelBank_Account.User.CMND_CCCD;
                    user.User.Address = modelBank_Account.User.Address;
                    user.User.Email = modelBank_Account.User.Email;
                    user.User.Password = modelBank_Account.User.Password;
                }    
            }    
        }
        public void Update_User(ModelBank_Account modelBank_Account)
        {
            UserBank.User.FullName = modelBank_Account.User.FullName;
            UserBank.User.DateOfBirth = modelBank_Account.User.DateOfBirth;
            UserBank.User.Gender = modelBank_Account.User.Gender;
            UserBank.User.CMND_CCCD = modelBank_Account.User.CMND_CCCD;
            UserBank.User.Address = modelBank_Account.User.Address;
            UserBank.User.Email = modelBank_Account.User.Email;
            UserBank.User.Phone = modelBank_Account.User.Phone;
        }
        public int SearchUserIndexByID(int id)
        {
            int minIndex = 0;
            int maxIndex = ListBank_User.Count - 1;
            while (minIndex <= maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;
                var item = ListBank_User[midIndex];

                if (item.User.ID_User < id)
                {
                    minIndex = midIndex + 1;
                }
                else if (item.User.ID_User > id)
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
            bool isBankAccountCreated = modelBank_Account.Create_Bank_Account(modelBank_Account.Select_ID_User(modelBank_Account.User), (modelBank_Account.Number_Bank = GenerateRandomNumberBank()));
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
        public int IsLoggedIn(ModelUser user)
        {
            var item = ListBank_User.FirstOrDefault(u => u.User.Username == user.Username && u.User.Password == user.Password);
            if (item != null && item.User.status_user.Equals("normal"))
            {
                item.GetBank_User(item);
                return 1;
            }
            else if (item != null && item.User.status_user.Equals("lock"))
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
