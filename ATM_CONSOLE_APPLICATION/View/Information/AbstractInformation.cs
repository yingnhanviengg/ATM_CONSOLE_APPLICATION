using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Information
{
    public abstract class AbstractInformation
    {
        public abstract void Table_Informatio();
        public abstract string DateOfBirthToString(DateTime item);
    }
}
