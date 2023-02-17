using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelCard : ModelBank_Account
    {
        public int ID_Card { get; set; }
        public string Number_Card { get; set; }
        public string Card_Type { get; set; }
        public string CVV { get; set; }
        public DateTime Expiration_Date { get; set; }
        public string Status_Card { get; set; }
        public DateTime Created_at_Card { get; set; }
        public static ModelCard Card { get; set; }
        private static List<ModelCard> _ListCards;
        public static List<ModelCard> ListCards
        {
            get
            {
                if (_ListCards == null)
                {
                    _ListCards = new List<ModelCard>();
                }
                return _ListCards;
            }
            set { _ListCards = value; }
        }
        public ModelCard(int id_card, int id_bank, string number_card, string card_type, string cvv, DateTime expiration_Date, string status, DateTime created_at_card)
        {
            this.ID_Card = id_card;
            this.ID_Bank = id_bank;
            this.Number_Card = number_card;
            this.Card_Type = card_type;
            this.CVV = cvv;
            this.Expiration_Date = expiration_Date;
            this.Status_Card = status;
            this.Created_at_Card = created_at_card;
        }
        public static bool CreateCard(int id_bank, string number_card, string cardtype, string cvv, DateTime expiration_date)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO card(id_bank_account, number_card, card_type, cvv, expiration_date) VALUES (@id_bank, @number_card, @cardtype, @cvv, @expiration_date);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_bank", id_bank);
                mySqlCommand.Parameters.AddWithValue("@number_card", number_card);
                mySqlCommand.Parameters.AddWithValue("@cardtype", cardtype);
                mySqlCommand.Parameters.AddWithValue("@cvv", cvv);
                mySqlCommand.Parameters.AddWithValue("@expiration_date", expiration_date);
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
        public static void GetCard(int id_bank)
        {
            string query = "SELECT card.* FROM card WHERE id_bank_account = @id_bank;";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            command.Parameters.AddWithValue("@id_bank", id_bank);
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    Card = (ObjectCard(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public static void GetListCard()
        {
            ListCards.Clear();
            string query = "SELECT card.* FROM card;";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    ListCards.Add(ObjectCard(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public static ModelCard ObjectCard(MySqlDataReader reader)
        {
            ModelCard card = new ModelCard(
                reader.GetInt32("id_card"),
                reader.GetInt32("id_bank_account"),
                reader.GetString("number_card"),
                reader.GetString("card_type"),
                reader.GetString("cvv"),
                reader.GetDateTime("expiration_date"),
                reader.GetString("status"),
                reader.GetDateTime("created_at_card")             
                );
            return card;
        }
    }
}

