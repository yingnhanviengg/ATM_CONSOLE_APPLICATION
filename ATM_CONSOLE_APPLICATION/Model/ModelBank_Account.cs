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
        public static void GetListBank_User()
        {
            Controller.ControllerBank_User.ListBank_User.Clear();
            string query = "SELECT user.*, bank_account.id_bank_account, bank_account.number_bank, bank_account.balance, bank_account.created_at_bank_account, bank_account.status_bank FROM bank_account INNER JOIN user ON bank_account.id_user = user.id_user";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    Controller.ControllerBank_User.ListBank_User.Add(GetBank_User(mySqlDataReader));
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
