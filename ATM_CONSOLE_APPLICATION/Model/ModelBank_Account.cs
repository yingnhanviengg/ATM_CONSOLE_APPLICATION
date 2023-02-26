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
        public ModelBank_Account() { }
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
        public bool Withdraw(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "UPDATE bank_account SET balance = @balance WHERE id_bank_account = @id_bank_account;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_bank_account", modelBank_Account.ID_Bank);
                mySqlCommand.Parameters.AddWithValue("@balance", modelBank_Account.Balance);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }     
        public bool Create_Bank_Account(ModelBank_Account bank)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO bank_account(id_user, number_bank) VALUES (@id_user, @number_bank);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_user", bank.User.ID_User);
                mySqlCommand.Parameters.AddWithValue("@number_bank", bank.Number_Bank);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public void GetListBank_User()
        {
            _ListBank_User.Clear();
            string query = "SELECT bank_account.* FROM bank_account ";
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
        public ModelBank_Account GetBank_UserMysql(MySqlDataReader reader)
        {
            ModelBank_Account bank = new ModelBank_Account(
                reader.GetInt32("id_bank_account"),
                reader.GetString("number_bank"),
                reader.GetDouble("balance"),
                reader.GetDateTime("created_at_bank_account"),
                reader.GetString("status_bank"),
                ModelUser._ListUser.FirstOrDefault(x => x.ID_User.Equals(reader.GetInt32("id_user")))
                );
            return bank;
        }
    }
}
