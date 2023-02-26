using MySql.Data.MySqlClient;

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
        public ModelCard() { }
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
        public bool UnLockCard(ModelCard card)
        {
            try
            {
                string query1 = "UPDATE card SET status_card = 'normal' WHERE id_bank_account = @id_bank_account;";
                using MySqlCommand cm1 = new MySqlCommand(query1, DBHelper.Open());
                cm1.Parameters.AddWithValue("@id_bank_account", card.UserBank.ID_Bank);
                if (cm1.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
        }
        public bool LockCard(ModelCard card)
        {
            try
            {
                string query1 = "UPDATE card SET status_card = 'lock' WHERE id_bank_account = @id_bank_account;";
                using MySqlCommand cm1 = new MySqlCommand(query1, DBHelper.Open());
                cm1.Parameters.AddWithValue("@id_bank_account", card.UserBank.ID_Bank);
                if (cm1.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { DBHelper.Close(); }
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
                else { return false; }
            }
            catch (Exception) { throw; }
            finally { GetListCard(); DBHelper.Close(); }
        }
        public void GetListCard()
        {
            ListCards.Clear();
            string query = "SELECT card.* FROM card WHERE status_card = 'normal' OR status_card = 'lock';";
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
            Card = card;
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
                ModelBank_Account._ListBank_User.FirstOrDefault(x => x.ID_Bank.Equals(reader.GetInt32("id_bank_account")))
                );
            return card;
        }
    }
}

