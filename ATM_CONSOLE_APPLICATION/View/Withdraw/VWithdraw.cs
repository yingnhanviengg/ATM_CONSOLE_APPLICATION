using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string passcard = InputisValid.InputPassCard();
            if (controllerCard.checkCardExistence(card, passcard))
            {
                double amount = InputisValid.InputAmount();
                if (controllerTransaction.Withdraw(card, amount))
                {
                    Common.PrintMessage_Console(AbstractLanguage.Withdraw_Success, true);
                }
                else { Common.PrintMessage_Console(AbstractLanguage.Error_insufficientBalance, false); }
            }
            else { Common.PrintMessage_Console(AbstractLanguage.CardNotExistOrLock, false); }
        }
    }
}
