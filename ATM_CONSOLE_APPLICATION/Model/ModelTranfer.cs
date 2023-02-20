using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelTranfer : ModelTransaction
    {
        public int ID_Tranfer { get; set; }
        public DateTime created_at_tranfer { get; set; }
        public ModelTranfer()
        {

        }
        public ModelTranfer(int id_tranfer, int id_bank_recipient, int id_bank_sender, double amount, DateTime created_at_tranfer)
        {
            this.ID_Tranfer = id_tranfer;
            this.ID_Bank = id_bank_recipient;
            this.ID_Bank = id_bank_sender;
            this.amount = amount;
            this.created_at_tranfer = created_at_tranfer;
        }
    }
}
