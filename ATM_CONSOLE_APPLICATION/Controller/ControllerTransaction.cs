using ATM_CONSOLE_APPLICATION.Controller.email;
using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllerTransaction
    {
        public ControllerTransaction()
        {
            Transaction.GetListTransaction();
        }
        private static ControllerTransaction _controllerTransaction;
        public static ControllerTransaction _ControllerTransaction
        {
            get
            {
                if (_controllerTransaction == null)
                {
                    _controllerTransaction = new ControllerTransaction();
                }
                return _controllerTransaction;
            }
        }
        public static List<ModelTransaction> List_Transactions
        {
            get { return ModelTransaction.List_Transactions; }
        }
        public static ModelTransaction Transaction
        {
            get { return ModelTransaction.Transaction; }
        }
        public static List<ModelTransaction> ListRequireRecharge
        {
            get { return ModelTransaction.ListRequireRecharge; }
        }
        public static List<ModelTransaction> ListHistoryRecharge_Withdraw_User
        {
            get { return ModelTransaction.ListHistoryRecharge_Withdraw_User; }
        }
        public bool Withdraw(string card, double amount)
        {
            bool result;
            var itemcard = ControllerCard.ListCard.FirstOrDefault(x => x.Number_Card.Equals(card));
            var itembank = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.ID_Bank.Equals(itemcard.UserBank.ID_Bank));
            if (itembank != null && itembank.Balance >= amount)
            {
                var whithdraw = new ModelTransaction(itembank, type: "withdraw", amount, status_transaction: "complete");
                var itemtransaction = List_Transactions.FirstOrDefault(x => x.Bank_Account.ID_Bank.Equals(itembank.ID_Bank));
                itembank.Balance -= amount;
                if (whithdraw.SendTransaction(whithdraw) && itembank.Withdraw(itembank))
                {
                    Email email = new TemplateMailWithdraw();
                    email.SendMail(whithdraw);
                    result = true;
                }
                else { result = false; }
            }
            else { result = false; }
            return result;
        }
        public bool RequireReachaerge(double amount)
        {
            var rechager = new Model.ModelTransaction(ControllerBank_User.UserBank, type: "recharge", amount, status_transaction: "processing");
            return rechager.SendTransaction(rechager);
        }
        public bool Confirm_Reccharge(int id_transaction)
        {
            var itemTransacton = ControllerTransaction.List_Transactions.FirstOrDefault(x => x.ID_Transaction.Equals(id_transaction));
            if (itemTransacton != default && itemTransacton.status_transaction.Equals("processing"))
            {
                if (itemTransacton.Confirm_Reccharge(itemTransacton))
                {
                    itemTransacton.Bank_Account.Balance += itemTransacton.amount;
                    itemTransacton.status_transaction = "complete";
                    email.Email email = new email.TemplateMailRecharge();
                    email.SendMail(itemTransacton);
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
