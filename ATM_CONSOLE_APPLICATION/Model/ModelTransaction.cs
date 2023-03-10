using ATM_CONSOLE_APPLICATION.Controller;
using MySql.Data.MySqlClient;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelTransaction
    {
        public int ID_Transaction { get; set; }
        public string Type_Tracsaction { get; set; }
        public double amount { get; set; }
        public DateTime created_at_transaction { get; set; }
        public string status_transaction { get; set; }
        public ModelBank_Account Bank_Account { get; set; }
        private static ModelTransaction _transaction;
        public static ModelTransaction Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = new ModelTransaction();
                }
                return _transaction;
            }
            set { _transaction = value; }
        }
        private static List<ModelTransaction> _list_transactions;
        public static List<ModelTransaction> List_Transactions
        {
            get
            {
                if (_list_transactions == null)
                {
                    _list_transactions = new List<ModelTransaction>();
                }
                return _list_transactions;
            }
            set { _list_transactions = value; }
        }
        private static List<ModelTransaction> _listRequireRecharge;
        public static List<ModelTransaction> ListRequireRecharge
        {
            get
            {
                if (_listRequireRecharge == null)
                {
                    _listRequireRecharge = List_Transactions.Where(item => item.Type_Tracsaction.Equals("recharge") && item.status_transaction.Equals("processing")).ToList();
                }
                return _listRequireRecharge;
            }
            set { _listRequireRecharge = value; }
        }
        private static List<ModelTransaction> _listHistoryRecharge_Withdraw_User;
        public static List<ModelTransaction> ListHistoryRecharge_Withdraw_User
        {
            get
            {
                if (_listHistoryRecharge_Withdraw_User == null)
                {
                    _listHistoryRecharge_Withdraw_User = List_Transactions.Where(item => item.Bank_Account.ID_Bank.Equals(ControllerBank_User.UserBank.ID_Bank)).ToList();
                }
                return _listHistoryRecharge_Withdraw_User;
            }
            set { _listHistoryRecharge_Withdraw_User = value; }
        }

        public ModelTransaction() { }
        public ModelTransaction(ModelBank_Account Bank_Account, int id_transaction, string type, double amount, DateTime created_at_tracsaction, string status_transaction)
        {
            this.Bank_Account = Bank_Account;
            this.ID_Transaction = id_transaction;
            this.Type_Tracsaction = type;
            this.amount = amount;
            this.created_at_transaction = created_at_tracsaction;
            this.status_transaction = status_transaction;
        }
        public ModelTransaction(ModelBank_Account Bank_Account, string type, double amount, string status_transaction)
        {
            this.Bank_Account = Bank_Account;
            this.Type_Tracsaction = type;
            this.amount = amount;
            this.status_transaction = status_transaction;
        }
        public bool Confirm_Reccharge(ModelTransaction Rechager)
        {
            try
            {
                string query1 = "UPDATE transaction SET status_transaction = 'complete' WHERE id_transaction = @id_transaction;";
                using MySqlCommand cm1 = new MySqlCommand(query1, DBHelper.Open());
                cm1.Parameters.AddWithValue("@id_transaction", Rechager.ID_Transaction);
                string query2 = "UPDATE bank_account SET balance = @balance + @amount WHERE id_bank_account = @id_bank_account;";
                using MySqlCommand cm2 = new MySqlCommand(query2, DBHelper.Open());
                cm2.Parameters.AddWithValue("@balance", Rechager.Bank_Account.Balance);
                cm2.Parameters.AddWithValue("@amount", Rechager.amount);
                cm2.Parameters.AddWithValue("@id_bank_account", Rechager.Bank_Account.ID_Bank);
                if (cm1.ExecuteNonQuery() != 0 && cm2.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public bool SendTransaction(ModelTransaction transaction)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO transaction(id_bank_account, type, amount, status_transaction) VALUES (@id_bank, @type, @amount, @status_transaction);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_bank", transaction.Bank_Account.ID_Bank);
                mySqlCommand.Parameters.AddWithValue("@type", transaction.Type_Tracsaction);
                mySqlCommand.Parameters.AddWithValue("@amount", transaction.amount);
                mySqlCommand.Parameters.AddWithValue("@status_transaction", transaction.status_transaction);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public bool RequireReachaerge(ModelTransaction Rechager)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO transaction(id_bank_account, type, amount, status_transaction) VALUES (@id_bank, @type, @amount, @status_transaction);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_bank", Rechager.Bank_Account.ID_Bank);
                mySqlCommand.Parameters.AddWithValue("@type", Rechager.Type_Tracsaction);
                mySqlCommand.Parameters.AddWithValue("@amount", Rechager.amount);
                mySqlCommand.Parameters.AddWithValue("@status_transaction", Rechager.status_transaction);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public void GetListTransaction()
        {
            try
            {
                string query = "SELECT transaction.* FROM transaction;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        List_Transactions.Add(GetTransaction(mySqlDataReader));
                    }
                }
                DBHelper.Close();
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public ModelTransaction GetTransaction(MySqlDataReader reader)
        {
            ModelTransaction transaction = new ModelTransaction(
                ModelBank_Account._ListBank_User.FirstOrDefault(x => x.ID_Bank.Equals(reader.GetInt32("id_bank_account"))),
                reader.GetInt32("id_transaction"),
                reader.GetString("type"),
                reader.GetDouble("amount"),
                reader.GetDateTime("created_at_transaction"),
                reader.GetString("status_transaction")
                );
            return transaction;
        }
    }
}
