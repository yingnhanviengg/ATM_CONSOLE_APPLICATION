using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllerCard
    {
        public ControllerCard() { Card.GetListCard(); }
        private static ControllerCard _ControllerCard;
        public static ControllerCard controllerCard
        {
            get
            {
                if (_ControllerCard == null)
                {
                    _ControllerCard = new ControllerCard();
                }
                return _ControllerCard;
            }
        }
        public static List<ModelCard> ListCard
        {
            get { return ModelCard.ListCards; }
        }
        public static ModelCard Card
        {
            get { return ModelCard.Card; }
        }
        public bool UnLockCard(string card)
        {
            var item = ControllerCard.ListCard.FirstOrDefault(x => x.Number_Card.Equals(card));
            if (item != default && item.Status_Card.Equals("lock"))
            {
                if (item.UnLockCard(item))
                {
                    item.Status_Card = "normal";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool LockCard(string card)
        {
            var item = ControllerCard.ListCard.FirstOrDefault(x => x.Number_Card.Equals(card));
            if (item != default && item.Status_Card.Equals("normal"))
            {
                if (item.LockCard(item))
                {
                    item.Status_Card = "lock";
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool CreateCard()
        {
            return Card.CreateCard(new ModelCard(ModelBank_Account.UserBank, GenerateRandomNumberCard(), GenerateRandomNumberPass(), Expiration_Date()));
        }
        public string GenerateRandomNumberCard()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string GenerateRandomNumberPass()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public DateTime Expiration_Date()
        {
            DateTime Expiration_Date = DateTime.Now;
            return Expiration_Date.AddYears(5);
        }
        public bool GetCard()
        {
            var item = ListCard.FirstOrDefault(x => x.UserBank.ID_Bank.Equals(ControllerBank_User.UserBank.ID_Bank));
            if (item != null)
            {
                Card.GetCard(item);
                return true;
            }
            return false;
        }
    }
}
