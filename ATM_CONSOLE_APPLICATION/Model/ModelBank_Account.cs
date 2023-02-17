using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelBank_Account : ModelUser
    {
        public int ID_Bank { get; set; }
        public string Number_Bank { get; set; }
        public double Balance { get; set; }
        public DateTime created_at_bank { get; set; }
        public string status_bank { get; set; }
        public static ModelBank_Account _User { get; set; }

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
        public ModelBank_Account(
            int id_user, string fullname, DateTime dateofbirth, 
            string gender, string CMND_CCCD, string address, string user, 
            string password, string email, string phone, DateTime created_at, string role, string status_user, 
            int id_bank, string number_bank, double balance, DateTime created_at_bank, string status_bank
            )
        : base(id_user, fullname, dateofbirth, gender, CMND_CCCD, address, user, password, email, phone, created_at, role, status_user)
        {
            this.ID_Bank = id_bank;
            this.Number_Bank = number_bank;
            this.Balance = balance;
            this.created_at_bank = created_at_bank;
            this.status_bank = status_bank;
        }
        public static bool Create_Bank_Account(int id_user, string number_bank)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO bank_account(id_user, number_bank) VALUES (@id_user, @number_bank);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_user", id_user);
                mySqlCommand.Parameters.AddWithValue("@number_bank",number_bank);
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
        public static bool IsLoggedIn(string user, string pass)
        {
            try
            {
                string query = "SELECT user.*, bank_account.id_bank_account, bank_account.number_bank, bank_account.balance, bank_account.created_at_bank_account, bank_account.status_bank FROM bank_account INNER JOIN user ON bank_account.id_user = user.id_user WHERE user.username = @user AND user.password = @pass;";
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                command.Parameters.AddWithValue("@user",user);
                command.Parameters.AddWithValue("@pass",pass);
                using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        _User = GetBank_User(mySqlDataReader);
                        return true;
                    }
                    else
                    {
                        return false;
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
        public static void GetList_All_Bank_User()
        {
            _ListBank_User.Clear();
            string query = "SELECT user.*, bank_account.id_bank_account, bank_account.number_bank, bank_account.balance, bank_account.created_at_bank_account, bank_account.status_bank FROM bank_account INNER JOIN user ON bank_account.id_user = user.id_user";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    _ListBank_User.Add(GetBank_User(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public static ModelBank_Account GetBank_User(MySqlDataReader reader)
        {
            ModelBank_Account bank = new ModelBank_Account(
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
                reader.GetString("status_user"),
                reader.GetInt32("id_bank_account"),
                reader.GetString("number_bank"),
                reader.GetDouble("balance"),
                reader.GetDateTime("created_at_bank_account"),
                reader.GetString("status_bank")
                );
            return bank;
        }
    }
}
