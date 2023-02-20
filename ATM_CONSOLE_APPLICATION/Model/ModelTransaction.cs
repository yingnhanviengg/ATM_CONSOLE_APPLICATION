using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelTransaction : ModelBank_Account
    {
        public int ID_Transaction { get; set; }
        public string Type_Tracsaction { get; set; }
        public double amount { get; set; }
        public DateTime created_at_transaction { get; set; }
        public string status_transaction { get; set; }
        public ModelTransaction()
        {

        }
        public ModelTransaction(int id_transaction, int id_bank ,string type, double amount, DateTime created_at_tracsaction, string status_transaction)
        {
            this.ID_Transaction = id_transaction;
            this.ID_Bank = id_bank;
            this.Type_Tracsaction = type;
            this.amount = amount;
            this.created_at_transaction = created_at_tracsaction;
            this.status_transaction = status_transaction;
        }
        public ModelTransaction(int id_bank, string type, double amount, string status_transaction)
        {
            this.ID_Bank = id_bank;
            this.Type_Tracsaction = type;
            this.amount = amount;
            this.status_transaction = status_transaction;
        }
        public bool Hitory_Rechager(ModelTransaction Rechager)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO transaction(id_bank_account, type, amount, status_transaction) VALUES (@id_bank, @type, @amount, @status_transaction);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_bank", Rechager.ID_Bank);
                mySqlCommand.Parameters.AddWithValue("@type", Rechager.Type_Tracsaction);
                mySqlCommand.Parameters.AddWithValue("@amount", Rechager.amount);
                mySqlCommand.Parameters.AddWithValue("@status_transaction", Rechager.status_transaction);
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
    }
}
