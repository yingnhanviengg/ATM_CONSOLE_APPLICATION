using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using System.Collections.Specialized;

namespace ATM_CONSOLE_APPLICATION.View.Withdraw
{
    public class VWithdraw
    {
        private static VWithdraw? _withdraw;
        private VWithdraw() { }
        public static VWithdraw _Withdraw
        {
            get
            {
                if (_withdraw == null)
                {
                    _withdraw = new VWithdraw();
                }
                return _withdraw;
            }
        }
        private ControllerCard controllerCard = ControllerCard.controllerCard;
        private ControllerTransaction controllerTransaction = ControllerTransaction._ControllerTransaction;
        public void Withdraw()
        {
            string card = InputisValid.InputNumberCarb();           
            if (controllerCard.checkNumberCardExistence(card))
            {
                int count = 3;
                do
                {
                    string passcard = InputisValid.InputPassCard();
                    Console.Clear();
                    if (controllerCard.CheckCardExistence(card, passcard))
                    {
                        double amount = InputisValid.InputAmount();
                        if (controllerTransaction.Withdraw(card, amount))
                        {
                            Common.PrintMessage_Console(AbstractLanguage.Withdraw_Success, true);
                            break;
                        }
                        else { Common.PrintMessage_Console(AbstractLanguage.Error_insufficientBalance, false); }
                    }
                    else
                    {
                        count--; 
                        Common.PrintMessage_Console(AbstractLanguage.IncorretPassCard, false);
                        Common.PrintMessage_Console(count.ToString() + " " + Language.AbstractLanguage.LimitReached_Lock, false);
                    }
                } while (count != 0);
                if (count == 0)
                {
                    controllerCard.LockCard(card);
                    Common.PrintMessage_Console(Language.AbstractLanguage.Card_HasLocked, false);
                }
            }
            else { Common.PrintMessage_Console(AbstractLanguage.CardNotExistOrLock, false); }
        }
    }
}
