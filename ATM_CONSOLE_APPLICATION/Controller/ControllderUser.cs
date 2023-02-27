using ATM_CONSOLE_APPLICATION.Controller.email;
using ATM_CONSOLE_APPLICATION.Model;
using ATM_CONSOLE_APPLICATION.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllderUser
    {
        public ControllderUser() { User.GetListUser(); }
        public static List<ModelUser> List_User
        {
            get { return ModelUser._ListUser; }
        }
        public static ModelUser User
        {
            get { return ModelUser.User; }
        }
        private static ControllderUser _ControllerUser;
        public static ControllderUser __ControllerUser
        {
            get
            {
                if (_ControllerUser == null)
                {
                    _ControllerUser = new ControllderUser();
                }
                return _ControllerUser;
            }
        }
        public bool Unlock_Account(int id)
        {
            var item = List_User.FirstOrDefault(x => x.status_user.Equals(id));
            if (item != default && item.status_user.Equals("lock"))
            {
                if (item.UnLock_Account(item))
                {
                    item.status_user = "normal";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool LockAcountLimitLogin(string user)
        {
            var item = List_User.FirstOrDefault(x => x.Username.Equals(user));
            if (item != default && item.status_user.Equals("normal"))
            {
                if (item.Lock_Account(item))
                {
                    item.status_user = "lock";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool Lock_Account(int id)
        {
            var item = List_User.FirstOrDefault(x => x.ID_User.Equals(id));
            if (item != default && item.status_user.Equals("normal"))
            {
                if (item.Lock_Account(item))
                {
                    item.status_user = "lock";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public int IsValidUpdate(int iduser, string cmnd_cccd, string email, string phone)
        {
            var index = List_User.FindIndex(x => x.ID_User.Equals(iduser));
            var valid = List_User[index];
            if (!cmnd_cccd.Equals(valid.CMND_CCCD))
            {
                if (FindCMND_CCCD(cmnd_cccd)) { return -4; }
            }
            if (!phone.Equals(valid.Phone))
            {
                if (FindPhone(phone)) { return -3; }
            }
            if (!email.Equals(valid.Email))
            {
                if (FindEmail(email)) { return -2; }
            }
            return 1;
        }
        public bool Upate_Information(int iduser, string fullname, DateTime dateofbirth, string gender, string cmnd_cccd, string address, string email, string phone)
        {
            var user = new Model.ModelUser(iduser, fullname, dateofbirth, gender, cmnd_cccd, address, email, phone);
            if (user.Update_Information(user))
            {
                if (User.role.Equals("customer"))
                {
                    Update_User(user);
                }
                UpdateList_User(user);
                return true;
            }
            else { return false; }
        }
        public void UpdateList_User(ModelUser userupdate)
        {
            var userindex = List_User.FindIndex(x => x.ID_User.Equals(userupdate.ID_User));
            if (userindex != -1)
            {
                var user = List_User[userindex];
                if (user != null)
                {
                    user.FullName = userupdate.FullName;
                    user.DateOfBirth = userupdate.DateOfBirth;
                    user.Gender = userupdate.Gender;
                    user.CMND_CCCD = userupdate.CMND_CCCD;
                    user.Address = userupdate.Address;
                    user.Email = userupdate.Email;
                    user.Password = userupdate.Password;
                }
            }
        }
        public void Update_User(ModelUser userupdate)
        {
            User.FullName = userupdate.FullName;
            User.DateOfBirth = userupdate.DateOfBirth;
            User.Gender = userupdate.Gender;
            User.CMND_CCCD = userupdate.CMND_CCCD;
            User.Address = userupdate.Address;
            User.Email = userupdate.Email;
            User.Phone = userupdate.Phone;
        }
        public bool Register(string fullname, DateTime dateofbirth, string gender, string cmnd_cccd, string address, string username, string password, string email, string phone)
        {
            var userRegister = new Model.ModelUser(fullname, dateofbirth, gender, cmnd_cccd, address, username, password, email, phone);          
            bool result = false;
            Email templateMail;
            templateMail = new TemplateMailRegister_Code();
            templateMail.SendMail(userRegister);
            int cout = 3;
            do
            {
                if (Email.code == InputisValid.InputCode())
                {
                    bool isUserRegistered = userRegister.IsRegister(userRegister);
                    userRegister.GetListUser();
                    var UserNew = List_User.FirstOrDefault(x => x.CMND_CCCD.Equals(cmnd_cccd));
                    var created_bank = new Model.ModelBank_Account(UserNew, number_bank: GenerateRandomNumberBank());
                    bool isBankAccountCreated = created_bank.Create_Bank_Account(created_bank);
                    created_bank.GetListBank_User();
                    templateMail = new TempMailRegister_Success();
                    bool isMailSent = templateMail.SendMail(created_bank);
                    result = isUserRegistered && isBankAccountCreated && isMailSent;
                    break;
                }
                else
                {
                    cout--;
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Code, false);
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Code_Limit_3 + cout.ToString(), false);
                }
            } while (cout != 0);
            return result;
        }
        public bool FindUser(string user)
        {
            if (List_User.Any(u => u.Username == user)) { return true; } // tài khoản đã tồn tại
            return false;
        }
        public bool FindEmail(string email)
        {
            if (List_User.Any(u => u.Email == email)) { return true; } // email đã tồn tại
            return false;
        }
        public bool FindPhone(string phone)
        {
            if (List_User.Any(u => u.Phone == phone)) { return true; } // sdt đã tồn tại
            return false;
        }
        public bool FindCMND_CCCD(string cmnd_cccd)
        {
            if (List_User.Any(u => u.CMND_CCCD == cmnd_cccd)) { return true; } //cmnd_cccd đã tồn tại
            return false;
        }
        public int IsRegister(string cmnd_cccd, string username, string email, string phone)
        {
            if (FindUser(username)) { return -1; }
            if (FindEmail(email)) { return -2; }
            if (FindPhone(phone)) { return -3; }
            if (FindCMND_CCCD(cmnd_cccd)) { return -4; }
            return 1;
        }
        public string GenerateRandomNumberBank()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public int IsLoggedIn(string user, string pass)
        {
            var item = List_User.FirstOrDefault(u => u.Username == user && u.Password == pass);
            if (item != null && item.status_user.Equals("normal")) { item.GetBank_User(item); return 1; }
            else if (item != null && item.status_user.Equals("lock")) { return -1; }
            else { return 0; }
        }
    }
}
