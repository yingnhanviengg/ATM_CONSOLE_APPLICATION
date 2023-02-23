using MySql.Data.MySqlClient;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelTranferMoney
    {
        public int ID_Tranfer { get; set; }
        public double amount { get; set; }
        public DateTime created_at_tranfer { get; set; }
        public ModelBank_Account Bank_Sender { get; set; }
        public ModelBank_Account Bank_Recipient { get; set; }
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
        public ModelTranferMoney(double amount, ModelBank_Account bank_Sender, ModelBank_Account bank_Recipient)
        {
            this.amount = amount;
            this.Bank_Sender = bank_Sender;
            this.Bank_Recipient = bank_Recipient;
        }
        public bool Tranfer(ModelTranferMoney tranfer)
        {

            try
            {
                string query1 = "UPDATE bank_account SET balance = @balance - @amount WHERE id_bank_account = @id_bank_account;";
                using MySqlCommand cm1 = new MySqlCommand(query1, DBHelper.Open());
                cm1.Parameters.AddWithValue("@balance", tranfer.Bank_Sender.Balance);
                cm1.Parameters.AddWithValue("@amount", tranfer.amount);
                cm1.Parameters.AddWithValue("@id_bank_account", tranfer.Bank_Sender.ID_Bank);
                string query2 = "UPDATE bank_account SET balance = @balance + @amount WHERE id_bank_account = @id_bank_account;";
                using MySqlCommand cm2 = new MySqlCommand(query2, DBHelper.Open());
                cm2.Parameters.AddWithValue("@balance", tranfer.Bank_Recipient.Balance);
                cm2.Parameters.AddWithValue("@amount", tranfer.amount);
                cm2.Parameters.AddWithValue("@id_bank_account", tranfer.Bank_Recipient.ID_Bank);
                string query3 = "INSERT HIGH_PRIORITY INTO history_tranfer(id_bank_recipient, id_bank_sender, amount) VALUES (@id_bank_recipient, @id_bank_sender, @amount);;";
                using MySqlCommand cm3 = new MySqlCommand(query3, DBHelper.Open());
                cm3.Parameters.AddWithValue("@id_bank_recipient", tranfer.Bank_Recipient.ID_Bank);
                cm3.Parameters.AddWithValue("@id_bank_sender", tranfer.Bank_Sender.ID_Bank);
                cm3.Parameters.AddWithValue("@amount", tranfer.amount);
                if (cm1.ExecuteNonQuery() != 0 && cm2.ExecuteNonQuery() != 0 && cm3.ExecuteNonQuery() != 0)
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
