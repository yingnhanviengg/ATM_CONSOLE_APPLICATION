using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool UnLockCard(ModelCard card)
        {
            if (card.Status_Card.Equals("lock") && card.UnLockCard(card))
            {
                card.Status_Card = "normal";
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LockCard(ModelCard card)
        {
            if (card.LockCard(card) && card.Status_Card.Equals("normal"))
            {
                card.Status_Card = "lock";
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateCard()
        {
            if (Card.CreateCard(new ModelCard(ModelBank_Account.UserBank, GenerateRandomNumberCard(), GenerateRandomNumberPass(), Expiration_Date())))
            {
                return true;
            }
            else
            {
                return false;
            }
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
