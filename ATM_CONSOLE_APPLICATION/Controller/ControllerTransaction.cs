using ATM_CONSOLE_APPLICATION.Model;
using Mysqlx.Crud;

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
        public bool IsRechaerge(ModelBank_Account user)
        {
            var index = ControllerBank_User.ListBank_User.FindIndex(x => x.User.ID_User.Equals(user.User.ID_User));
            if (index != -1)
            {
                var valid = ControllerBank_User.ListBank_User[index];
                ControllerBank_User.ListBank_User[index].Balance = user.Balance;
                ControllerBank_User.UserBank.Balance = user.Balance;
            }           
            return true;
        }
        public bool RequireReachaerge(double amount)
        {
            var rechager = new Model.ModelTransaction(ControllerBank_User.UserBank, type: "recharge", amount, status_transaction: "processing");
            return rechager.RequireReachaerge(rechager);
        }
        public bool Confirm_Reccharge(int id_transaction)
        {
            var itemTransacton = ControllerTransaction.List_Transactions.FirstOrDefault(x => x.ID_Transaction.Equals(id_transaction));
            if (itemTransacton != default && itemTransacton.status_transaction.Equals("processing"))
            {
                var indexbank = ControllerBank_User.ListBank_User.FindIndex(x => x.ID_Bank.Equals(itemTransacton.Bank_Account.ID_Bank));
                var itembank = ControllerBank_User.ListBank_User[indexbank];              
                if (itembank != null && itemTransacton.Confirm_Reccharge(itemTransacton))
                {
                    itemTransacton.Bank_Account.Balance += itemTransacton.amount;                   
                    itembank.Balance += itemTransacton.amount;
                    itemTransacton.status_transaction = "complete";
                    email.Email email = new email.TemplateMailRecharge();
                    email.Mail(itemTransacton);
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
