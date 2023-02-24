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
            try
            {
                List_TranferMoney.Clear();
                string query = "SELECT history_tranfer.* FROM history_tranfer";
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
            catch (Exception)
            {

                throw;
            }
            finally { UpdateData(); }
        }
        public void UpdateData()
        {
            foreach (var item in List_TranferMoney)
            {
                GetSender(item);
                GetRecipient(item);
            }
        }

        public void GetSender(ModelTranferMoney tranferMoney)
        {
            try
            {
                string query = "SELECT  history_tranfer.id_tranfer,  history_tranfer.id_bank_sender, bank_account.number_bank, bank_account.balance,  bank_account.status_bank, user.full_name, user.cmnd_cccd,  user.email, user.number_phone FROM history_tranfer  INNER JOIN bank_account   ON history_tranfer.id_bank_sender = bank_account.id_bank_account INNER JOIN user  ON bank_account.id_user = user.id_user AND history_tranfer.id_tranfer = @id_tranfer;";
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                command.Parameters.AddWithValue("@id_tranfer", tranferMoney.ID_Tranfer);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //var item = List_TranferMoney.FirstOrDefault(x => x.ID_Tranfer.Equals(reader.GetInt32("id_tranfer")));
                        tranferMoney.Bank_Sender.ID_Bank = reader.GetInt32("id_bank_sender");
                        tranferMoney.Bank_Sender.Number_Bank = reader.GetString("number_bank");
                        tranferMoney.Bank_Sender.Balance = reader.GetDouble("balance");
                        tranferMoney.Bank_Sender.status_bank = reader.GetString("status_bank");
                        tranferMoney.Bank_Sender.User.FullName = reader.GetString("full_name");
                        tranferMoney.Bank_Sender.User.CMND_CCCD = reader.GetString("cmnd_cccd");
                        tranferMoney.Bank_Sender.User.Email = reader.GetString("email");
                        tranferMoney.Bank_Sender.User.Phone = reader.GetString("number_phone");
                    }
                    else
                    {
                        throw new Exception("Cannot find sender information.");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { DBHelper.Close(); }
        }
        public void GetRecipient(ModelTranferMoney tranferMoney)
        {
            try
            {
                string query = "SELECT bank_account.number_bank, bank_account.balance,  bank_account.status_bank, user.full_name,  user.cmnd_cccd,  user.email,  user.number_phone,  history_tranfer.id_bank_recipient, history_tranfer.id_tranfer FROM history_tranfer INNER JOIN bank_account  ON history_tranfer.id_bank_recipient = bank_account.id_bank_account INNER JOIN user  ON bank_account.id_user = user.id_user WHERE history_tranfer.id_tranfer = @id_tranfer";
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                command.Parameters.AddWithValue("@id_tranfer", tranferMoney.ID_Tranfer);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //var item = List_TranferMoney.FirstOrDefault(x => x.ID_Tranfer.Equals(reader.GetInt32("id_tranfer")));
                        tranferMoney.Bank_Recipient.ID_Bank = reader.GetInt32("id_bank_recipient");
                        tranferMoney.Bank_Recipient.Number_Bank = reader.GetString("number_bank");
                        tranferMoney.Bank_Recipient.Balance = reader.GetDouble("balance");
                        tranferMoney.Bank_Recipient.status_bank = reader.GetString("status_bank");
                        tranferMoney.Bank_Recipient.User.FullName = reader.GetString("full_name");
                        tranferMoney.Bank_Recipient.User.CMND_CCCD = reader.GetString("cmnd_cccd");
                        tranferMoney.Bank_Recipient.User.Email = reader.GetString("email");
                        tranferMoney.Bank_Recipient.User.Phone = reader.GetString("number_phone");
                    }    
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { DBHelper.Close(); }
        }
        public ModelTranferMoney GetTranfer(MySqlDataReader reader)
        {

            ModelTranferMoney tranferMoney = new ModelTranferMoney(
                reader.GetInt32("id_tranfer"),
                reader.GetDouble("amount"),
                reader.GetDateTime("created_at_tranfer"),
                new ModelBank_Account(reader.GetInt32("id_bank_sender"), number_bank: string.Empty , balance: 0, status_bank: string.Empty, new ModelUser(fullname: string.Empty, cmnd_cccd: string.Empty, email: string.Empty, phone: string.Empty)),
                new ModelBank_Account(reader.GetInt32("id_bank_recipient"), number_bank: string.Empty, balance: 0, status_bank: string.Empty, new ModelUser(fullname: string.Empty, cmnd_cccd: string.Empty, email: string.Empty, phone: string.Empty))
                );
            return tranferMoney;
        }
    }
}
