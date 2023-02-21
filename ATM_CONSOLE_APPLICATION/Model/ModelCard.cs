using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelCard 
    {
        public int ID_Card { get; set; }
        public string Number_Card { get; set; }
        public string Pass_Card { get; set; }
        public DateTime Expiration_Date { get; set; }
        public string Status_Card { get; set; }
        public DateTime Created_at_Card { get; set; }
        public ModelBank_Account UserBank { get; set; }
        private static ModelCard? _Card = null;
        public static ModelCard Card
        {
            get
            {
                if (_Card == null)
                {
                    _Card = new ModelCard();
                }
                return _Card;
            }
            set { _Card = value; }
        }
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
        public ModelCard()
        {

        }
        public ModelCard(ModelBank_Account bank_Account, string number_card, string pass_card, DateTime expiration_date)
        {
            this.UserBank = bank_Account;
            this.Number_Card = number_card;
            this.Pass_Card = pass_card;
            this.Expiration_Date = expiration_date;
        }
        public ModelCard(int id_card, string number_card, string pass_card, DateTime expiration_Date, string status, DateTime created_at_card, ModelBank_Account bank_Account)
        {
            this.ID_Card = id_card;
            this.Number_Card = number_card;
            this.Pass_Card = pass_card;
            this.Expiration_Date = expiration_Date;
            this.Status_Card = status;
            this.Created_at_Card = created_at_card;
            this.UserBank = bank_Account;
        }
        public bool CreateCard(ModelCard modelCard)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO card(id_bank_account, number_card, pass_card, expiration_date) VALUES (@id_bank, @number_card, @pass_card, @expiration_date);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@id_bank", modelCard.UserBank.ID_Bank);
                mySqlCommand.Parameters.AddWithValue("@number_card", modelCard.Number_Card);
                mySqlCommand.Parameters.AddWithValue("@pass_card", modelCard.Pass_Card);
                mySqlCommand.Parameters.AddWithValue("@expiration_date", modelCard.Expiration_Date);
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
                GetListCard();
                DBHelper.Close();
            }
        }   
        public void GetListCard()
        {
            ListCards.Clear();
            string query = "SELECT card.*, user.full_name, user.cmnd_cccd, user.email FROM bank_account INNER JOIN user ON bank_account.id_user = user.id_user INNER JOIN card ON card.id_bank_account = bank_account.id_bank_account WHERE status_card = 'normal' OR status_card = 'lock';";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    ListCards.Add(GetListCard(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public void GetCard(ModelCard card)
        {
            Card = new ModelCard(card.ID_Card, card.Number_Card, card.Pass_Card, card.Expiration_Date, card.Status_Card, card.Created_at_Card, card.UserBank);
        }

        public ModelCard GetListCard(MySqlDataReader reader)
        {
            ModelCard card = new ModelCard(
                reader.GetInt32("id_card"),
                reader.GetString("number_card"),
                reader.GetString("pass_card"),
                reader.GetDateTime("expiration_date"),
                reader.GetString("status_card"),
                reader.GetDateTime("created_at_card"),
                new ModelBank_Account(reader.GetInt32("id_bank_account"), new ModelUser(reader.GetString("full_name"), reader.GetString("cmnd_cccd"), reader.GetString("email")))
                );
            return card;
        }
    }
}

