using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Card
{
    public abstract class AbstractCard
    {
        public abstract void Card_Management();
        public abstract void TableCard();
        public abstract string DateOfBirthToString(DateTime item);
    }
}
