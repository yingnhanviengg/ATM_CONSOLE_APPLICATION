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
        public bool Upate_Information(ModelBank_Account modelBank_Account)
        {         
            if (ModelUser.Update_Information(modelBank_Account))
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
        public void UpdateList_User(ModelBank_Account modelBank_Account)
        {
            var userindex = SearchUserIndexByID(modelBank_Account.ID_User);
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
        public int IsRegister(ModelBank_Account modelBank_Account)
        {
            foreach (var item in ListBank_User)
            {
                if (item.Username.Equals(modelBank_Account.Username)) // tài khoản đã tồn tại
                {
                    return -1;
                }
                else if (item.Email.Equals(modelBank_Account.Email)) // email đã tồn tại
                {
                    return -2;
                }
                else if (item.Phone.Equals(modelBank_Account.Phone)) // sdt đã tồn tại
                {
                    return -3;
                }
                else if (item.CMND_CCCD.Equals(modelBank_Account.CMND_CCCD)) // CMND_CCCD đã tồn tại
                {
                    return -4;
                }
            }
            return 1;
        }
        public bool Register(string code, ModelBank_Account modelBank_Account)
        {
            if (Email.code == null || !Email.code.Equals(code))
            {
                return false;
            }           
            bool isUserRegistered = ModelUser.IsRegister(modelBank_Account);
            bool isBankAccountCreated = modelBank_Account.Create_Bank_Account(ModelUser.Select_ID_User(modelBank_Account), (modelBank_Account.Number_Bank = GenerateRandomNumberBank()));
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
        public bool IsLoggedIn(ModelBank_Account modelBank_Account)
        {
            bool result = false;
            foreach (var item in ListBank_User)
            {
                if (item.Username.Equals(modelBank_Account.Username) && item.Password.Equals(modelBank_Account.Password))
                {
                    modelBank_Account.GetBank_User(item);
                    return result = true;
                }
            }
            return result;
        }
    }
}
