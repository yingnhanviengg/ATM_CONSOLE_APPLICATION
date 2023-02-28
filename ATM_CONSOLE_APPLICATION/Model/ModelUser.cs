using MySql.Data.MySqlClient;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelUser
    {
        public int ID_User { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CMND_CCCD { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime created_at { get; set; }
        public string role { get; set; }
        public string status_user { get; set; }
        private static ModelUser? _user;
        public static ModelUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new ModelUser();
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }
        private static List<ModelUser> _listUser;
        public static List<ModelUser> _ListUser
        {
            get
            {
                if (_listUser == null)
                {
                    _listUser = new List<ModelUser>();
                }
                return _listUser;
            }
            set
            {
                _listUser = value;
            }
        }
        public ModelUser() { }
        public ModelUser(int id_user, string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string email, string phone)
        {
            this.ID_User = id_user;
            this.FullName = fullname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.CMND_CCCD = CMND_CCCD;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }
        public ModelUser(string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string user, string password, string email, string phone)
        {
            this.FullName = fullname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.CMND_CCCD = CMND_CCCD;
            this.Address = address;
            this.Username = user;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
        }
        public ModelUser(int id_user, string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string user, string password, string email, string phone, DateTime created_at, string role, string status_user)
        {
            this.ID_User = id_user;
            this.FullName = fullname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.CMND_CCCD = CMND_CCCD;
            this.Address = address;
            this.Username = user;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
            this.created_at = created_at;
            this.role = role;
            this.status_user = status_user;
        }
        public bool UnLock_Account(ModelUser user)
        {
            try
            {
                string query = "UPDATE user SET status_user = 'normal' WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", user.ID_User);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public bool Lock_Account(ModelUser user)
        {
            try
            {
                string query = "UPDATE user SET status_user = 'lock' WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", user.ID_User);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public void GetBank_User(ModelUser user)
        {
            User = user;
            ModelBank_Account.UserBank = ModelBank_Account._ListBank_User.FirstOrDefault(x => x.User.ID_User.Equals(user.ID_User));
        }
        public bool Update_Information(ModelUser user)
        {
            try
            {
                string query = "UPDATE user SET full_name = @fullname, Date_Of_Birth = @dateofbirth, gender = @gender, cmnd_cccd = @cmnd_cccd, Address = @address, email = @email, number_phone = @numberphone WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", user.ID_User);
                mySqlCommand.Parameters.AddWithValue("@fullname", user.FullName);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", user.DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", user.Gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", user.CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", user.Address);
                mySqlCommand.Parameters.AddWithValue("@email", user.Email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", user.Phone);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public bool IsRegister(ModelUser user)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO user(full_name, Date_Of_Birth, gender, cmnd_cccd, Address, username, password, email, number_phone) VALUES (@fullname, @dateofbirth, @gender, @cmnd_cccd, @address, @username, @password, @email, @numberphone);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@fullname", user.FullName);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", user.DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", user.Gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", user.CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", user.Address);
                mySqlCommand.Parameters.AddWithValue("@username", user.Username);
                mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                mySqlCommand.Parameters.AddWithValue("@email", user.Email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", user.Phone);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error");
                throw;
            }
            finally { DBHelper.Close(); }
        }
        public void GetListUser()
        {
            _ListUser.Clear();
            string query = "SELECT user.* FROM user WHERE status_user = 'normal' OR status_user = 'lock' ";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    _ListUser.Add(GetUser(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public ModelUser GetUser(MySqlDataReader reader)
        {
            ModelUser uss = new ModelUser(
                reader.GetInt32("id_user"),
                reader.GetString("full_name"),
                reader.GetDateTime("Date_Of_Birth"),
                reader.GetString("gender"),
                reader.GetString("cmnd_cccd"),
                reader.GetString("Address"),
                reader.GetString("username"),
                reader.GetString("password"),
                reader.GetString("email"),
                reader.GetString("number_phone"),
                reader.GetDateTime("created_at"),
                reader.GetString("role"),
                reader.GetString("status_user")
                );
            return uss;
        }
    }
}
