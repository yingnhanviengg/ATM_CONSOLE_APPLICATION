using ATM_CONSOLE_APPLICATION.Controller.email;
using ATM_CONSOLE_APPLICATION.Model;
using ATM_CONSOLE_APPLICATION.View;

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
            get { return ModelBank_Account.UserBank; }
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
        public bool Unlock_Account(int id)
        {
            var item = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.User.status_user.Equals(id));
            if (item == default && item.User.status_user.Equals("lock"))
            {
                if (item.UnLock_Account(item))
                {
                    item.User.status_user = "normal";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool Lock_Account(int id)
        {
            var item = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.User.status_user.Equals(id));
            if (item == default && item.User.status_user.Equals("normal"))
            {
                if (item.Lock_Account(item))
                {
                    item.User.status_user = "lock";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool Upate_Information(int iduser, string fullname, DateTime dateofbirth, string gender, string cmnd_cccd, string address, string email, string phone)
        {
            var user = new Model.ModelUser(iduser, fullname, dateofbirth, gender, cmnd_cccd, address, email, phone);
            var update = new Model.ModelBank_Account(user);
            if (update.Update_Information(update))
            {
                if (UserBank.User.role.Equals("customer") && update.User.ID_User.Equals(UserBank.User.ID_User))
                {
                    Update_User(update);
                }
                UpdateList_User(update);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int IsValidUpdate(int iduser, string cmnd_cccd, string email, string phone)
        {
            var index = ListBank_User.FindIndex(x => x.User.ID_User.Equals(iduser));
            var valid = ListBank_User[index];
            if (!cmnd_cccd.Equals(valid.User.CMND_CCCD))
            {
                if (FindCMND_CCCD(cmnd_cccd))
                {
                    return -4;
                }
            }
            if (!phone.Equals(valid.User.Phone))
            {
                if (FindPhone(phone))
                {
                    return -3;
                }
            }
            if (!email.Equals(valid.User.Email))
            {
                if (FindEmail(email))
                {
                    return -2;
                }
            }
            return 1;
        }
        public bool FindUser(string user)
        {
            if (ListBank_User.Any(u => u.User.Username == user))
            {
                return true; // tài khoản đã tồn tại
            }
            return false;
        }
        public bool FindEmail(string email)
        {
            if (ListBank_User.Any(u => u.User.Email == email))
            {
                return true; // email đã tồn tại
            }
            return false;
        }
        public bool FindPhone(string phone)
        {
            if (ListBank_User.Any(u => u.User.Phone == phone))
            {
                return true; // sdt đã tồn tại
            }
            return false;
        }
        public bool FindCMND_CCCD(string cmnd_cccd)
        {
            if (ListBank_User.Any(u => u.User.CMND_CCCD == cmnd_cccd))
            {
                return true; // CMND_CCCD đã tồn tại
            }
            return false;
        }
        public int IsRegister(string cmnd_cccd, string username, string email, string phone)
        {
            if (FindUser(username))
            {
                return -1; // tài khoản đã tồn tại
            }
            if (FindEmail(email))
            {
                return -2; // email đã tồn tại
            }
            if (FindPhone(phone))
            {
                return -3; // sdt đã tồn tại
            }
            if (FindCMND_CCCD(cmnd_cccd))
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
        public bool Register(string fullname, DateTime dateofbirth, string gender, string cmnd_cccd, string address, string username, string password, string email, string phone)
        {
            var user = new Model.ModelUser(fullname, dateofbirth, gender, cmnd_cccd, address, username, password, email, phone);
            var register = new Model.ModelBank_Account(user, number_bank: string.Empty);
            bool result = false;
            Email templateMail;
            templateMail = new TemplateMailRegister_Code();
            templateMail.Mail(register);
            int cout = 3;
            do
            {
                if (Email.code == InputisValid.InputCode())
                {
                    bool isUserRegistered = register.IsRegister(register);
                    bool isBankAccountCreated = register.Create_Bank_Account(register.Select_ID_User(register.User), (register.Number_Bank = GenerateRandomNumberBank()));
                    register.GetList_All_Bank_User();
                    templateMail = new TempMailRegister_Success();
                    bool isMailSent = templateMail.Mail(register);
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

        public string GenerateRandomNumberBank()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public int IsLoggedIn(string user, string pass)
        {
            var item = ListBank_User.FirstOrDefault(u => u.User.Username == user && u.User.Password == pass);
            if (item != null && item.User.status_user.Equals("normal"))
            {
                item.GetBank_User(item);
                return 1;
            }
            else if (item != null && item.User.status_user.Equals("lock"))
            {
                return -1;
            }
            else { return 0; }
        }
    }
}
