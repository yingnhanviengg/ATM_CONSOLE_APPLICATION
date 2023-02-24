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
        public bool IsRechaerge(ModelBank_Account user)
        {
            var index = ControllerBank_User.ListBank_User.FindIndex(x => x.User.ID_User.Equals(user.User.ID_User));
            if (index != -1)
            {
                var valid = ControllerBank_User.ListBank_User[index];
                ControllerBank_User.ListBank_User[index].Balance = user.Balance;
            }
            ControllerBank_User.UserBank.Balance = user.Balance;
            return true;
        }
        public bool RequireReachaerge(double amount)
        {
            var rechager = new Model.ModelTransaction(ControllerBank_User.UserBank, type: "recharge", amount, status_transaction: "processing");
            return rechager.RequireReachaerge(rechager);
        }
        public bool Confirm_Reccharge(ModelTransaction user)
        {
            if (user.status_transaction.Equals("processing"))
            {
                var indexbank = ControllerBank_User.ListBank_User.FindIndex(x => x.ID_Bank.Equals(user.Bank_Account.ID_Bank));
                var itembank = ControllerBank_User.ListBank_User[indexbank];
                var indexTransaction = List_Transactions.FindIndex(x => x.ID_Transaction.Equals(user.ID_Transaction));
                var itemTransaction = List_Transactions[indexTransaction];
                if (itembank != null && itemTransaction != null && user.Confirm_Reccharge(user))
                {
                    foreach (var item in List_Transactions)
                    {
                        if (item.Bank_Account.ID_Bank.Equals(itembank.ID_Bank))
                        {
                            item.Bank_Account.Balance += user.amount;
                        }
                    }
                    itembank.Balance += user.amount;
                    itemTransaction.status_transaction = "complete";
                    email.Email email = new email.TemplateMailRecharge();
                    email.Mail(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
