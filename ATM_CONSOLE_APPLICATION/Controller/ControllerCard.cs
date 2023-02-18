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
        public ControllerCard() { }
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
        public static bool CreateCard(string cardtype)
        {
            if (ModelCard.CreateCard(ModelBank_Account.UserBank.ID_Bank, GenerateRandomNumberCard(), cardtype, GenerateRandomNumberCVV(), Expiration_Date()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GenerateRandomNumberCard()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateRandomNumberCVV()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static DateTime Expiration_Date()
        {
            DateTime Expiration_Date = DateTime.Now;
            return Expiration_Date.AddYears(5);
        }
    }
}
