using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelTranferMoney
    {
        public int ID_Tranfer { get; set;}
        public double amount { get; set;}
        public DateTime created_at_tranfer { get; set;}
        public ModelBank_Account Bank_Sender { get; set;}
        public ModelBank_Account Bank_Recipient { get; set;}
        private static ModelTranferMoney _tranferMoney;
        public static ModelTranferMoney TranferMoney
        {
            get
            {
                if (_tranferMoney == null)
                {
                    _tranferMoney = new ModelTranferMoney();
                }
                return _tranferMoney;
            }
            set { _tranferMoney = value; }
        }
        private static List<ModelTranferMoney> _list_TranferMoney;
        public static List<ModelTranferMoney> List_TranferMoney
        {
            get
            {
                if (_list_TranferMoney == null)
                {
                    _list_TranferMoney = new List<ModelTranferMoney>();
                }
                return _list_TranferMoney;
            }
            set { _list_TranferMoney = value; }
        }
        public ModelTranferMoney()
        {

        }
        public ModelTranferMoney(int iD_Tranfer, double amount, DateTime created_at_tranfer, ModelBank_Account bank_Sender, ModelBank_Account bank_Recipient)
        {
            this.ID_Tranfer = iD_Tranfer;
            this.amount = amount;
            this.created_at_tranfer = created_at_tranfer;
            this.Bank_Sender = bank_Sender;
            this.Bank_Recipient = bank_Recipient;
        }
        public void GetListTranfer()
        {
            List_TranferMoney.Clear();
            string query = "SELECT history_tranfer.*, bank_account.number_bank, bank_account.balance, bank_account.status_bank, user.full_name, user.cmnd_cccd, user.email, user.number_phone, bank_account.id_bank_account FROM history_tranfer INNER JOIN bank_account ON history_tranfer.id_bank_recipient = bank_account.id_bank_account INNER JOIN user ON bank_account.id_user = user.id_user WHERE status_bank = 'normal' AND status_bank = 'lock'";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    List_TranferMoney.Add(GetTranfer(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public ModelTranferMoney GetTranfer(MySqlDataReader reader)
        {
            ModelTranferMoney tranferMoney = new ModelTranferMoney(
                reader.GetInt32("id_tranfer"),
                reader.GetDouble("amount"),
                reader.GetDateTime("created_at_tranfer"),
                new ModelBank_Account(reader.GetInt32("id_bank_account"), reader.GetString("number_bank"), reader.GetDouble("balance"), reader.GetString("status_bank"), new ModelUser(reader.GetString("fullname"), reader.GetString("cmnd_cccd"), reader.GetString("email"), reader.GetString("number_phone"))),
                new ModelBank_Account(reader.GetInt32("id_bank_account"), reader.GetString("number_bank"), reader.GetDouble("balance"), reader.GetString("status_bank"), new ModelUser(reader.GetString("fullname"), reader.GetString("cmnd_cccd"), reader.GetString("email"), reader.GetString("number_phone")))
                );
            return tranferMoney;
        }
    }
}
