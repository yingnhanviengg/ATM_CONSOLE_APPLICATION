using MySql.Data.MySqlClient;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelBank_Account
    {
        public int ID_Bank { get; set; }
        public string Number_Bank { get; set; }
        public double Balance { get; set; }
        public DateTime created_at_bank { get; set; }
        public string status_bank { get; set; }
        public ModelUser User { get; set; }
        private static ModelBank_Account? _UserBank;
        public static ModelBank_Account UserBank
        {
            get
            {
                if (_UserBank == null)
                {
                    _UserBank = new ModelBank_Account();
                }
                return _UserBank;
            }
            set
            {
                _UserBank = value;
            }
        }
        private static List<ModelBank_Account> _listBank_User;
        public static List<ModelBank_Account> _ListBank_User
        {
            get
            {
                if (_listBank_User == null)
                {
                    _listBank_User = new List<ModelBank_Account>();
                }
                return _listBank_User;
            }
            set
            {
                _listBank_User = value;
            }
        }
        public ModelBank_Account()
        {

        }
        public ModelBank_Account(int id_bank, ModelUser user)
        {
            this.ID_Bank = id_bank;
            this.User = user;
        }
        public ModelBank_Account(ModelUser user, string number_bank)
        {
            this.User = user;
            this.Number_Bank = number_bank;
        }
        public ModelBank_Account(int id_bank, string number_bank, double balance, DateTime created_at_bank, string status_bank, ModelUser user)
        {
            this.ID_Bank = id_bank;
            this.Number_Bank = number_bank;
            this.Balance = balance;
            this.created_at_bank = created_at_bank;
            this.status_bank = status_bank;
            this.User = user;
        }
        public ModelBank_Account(ModelUser user)
        {
            this.User = user;
        }
        public ModelBank_Account(int id_bank, string number_bank, double balance)
        {
            this.ID_Bank = id_bank;
            this.Number_Bank = number_bank;
            this.Balance = balance;
        }
        public ModelBank_Account(int id_bank, string number_bank, double balance, string status_bank, ModelUser user)
        {
            this.ID_Bank = id_bank;
            this.Number_Bank = number_bank;
            this.Balance = balance;
            this.status_bank = status_bank;
            this.User = user;
        }

        public ModelBank_Account(int id_bank)
        {
            this.ID_Bank = id_bank;
        }
        public ModelBank_Account(string number_bank)
        {
            this.Number_Bank = number_bank;
        }
        public bool UnLock_Account(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "UPDATE user SET status_user = 'normal' WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", modelBank_Account.User.ID_User);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public bool Lock_Account(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "UPDATE user SET status_user = 'lock' WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", modelBank_Account.User.ID_User);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public bool IsRegister(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO user(full_name, Date_Of_Birth, gender, cmnd_cccd, Address, username, password, email, number_phone) VALUES (@fullname, @dateofbirth, @gender, @cmnd_cccd, @address, @username, @password, @email, @numberphone);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@fullname", modelBank_Account.User.FullName);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", modelBank_Account.User.DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", modelBank_Account.User.Gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", modelBank_Account.User.CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", modelBank_Account.User.Address);
                mySqlCommand.Parameters.AddWithValue("@username", modelBank_Account.User.Username);
                mySqlCommand.Parameters.AddWithValue("@password", modelBank_Account.User.Password);
                mySqlCommand.Parameters.AddWithValue("@email", modelBank_Account.User.Email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", modelBank_Account.User.Phone);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public bool Update_Information(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "UPDATE user SET full_name = @fullname, Date_Of_Birth = @dateofbirth, gender = @gender, cmnd_cccd = @cmnd_cccd, Address = @address, email = @email, number_phone = @numberphone WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", modelBank_Account.User.ID_User);
                mySqlCommand.Parameters.AddWithValue("@fullname", modelBank_Account.User.FullName);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", modelBank_Account.User.DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", modelBank_Account.User.Gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", modelBank_Account.User.CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", modelBank_Account.User.Address);
                mySqlCommand.Parameters.AddWithValue("@email", modelBank_Account.User.Email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", modelBank_Account.User.Phone);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public bool Rechager(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "UPDATE bank_account SET balance = @balance WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", modelBank_Account.User.ID_User);
                mySqlCommand.Parameters.AddWithValue("@balance", modelBank_Account.Balance);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }

        public bool Create_Bank_Account(int id_user, string number_bank)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO bank_account(id_user, number_bank) VALUES (@id_user, @number_bank);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_user", id_user);
                mySqlCommand.Parameters.AddWithValue("@number_bank", number_bank);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public void GetList_All_Bank_User()
        {
            _ListBank_User.Clear();
            string query = "SELECT user.*, bank_account.id_bank_account, bank_account.number_bank, bank_account.balance, bank_account.created_at_bank_account, bank_account.status_bank FROM bank_account INNER JOIN user ON bank_account.id_user = user.id_user WHERE status_user = 'normal' OR status_user = 'lock' ";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    _ListBank_User.Add(GetBank_UserMysql(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public int Select_ID_User(ModelUser modelBank_Account)
        {
            try
            {
                string query = "SELECT user.id_user FROM user WHERE user.username = @username AND user.email = @email AND user.cmnd_cccd = @cmnd_cccd";
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                command.Parameters.AddWithValue("@username", modelBank_Account.Username);
                command.Parameters.AddWithValue("@email", modelBank_Account.Email);
                command.Parameters.AddWithValue("@cmnd_cccd", modelBank_Account.CMND_CCCD);
                using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        return mySqlDataReader.GetInt32("id_user");
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public void GetBank_User(ModelBank_Account user)
        {
            UserBank = new ModelBank_Account(user.ID_Bank, user.Number_Bank, user.Balance, user.created_at_bank, user.status_bank, user.User);
        }

        public ModelBank_Account GetBank_UserMysql(MySqlDataReader reader)
        {
            ModelBank_Account bank = new ModelBank_Account(
                reader.GetInt32("id_bank_account"),
                reader.GetString("number_bank"),
                reader.GetDouble("balance"),
                reader.GetDateTime("created_at_bank_account"),
                reader.GetString("status_bank"),
                new ModelUser(
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
                    )
                );
            return bank;
        }
    }
}
