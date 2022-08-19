using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.Events
{
    public delegate void SetAccountNumber(string accountNumber);

    public  class SelectAccountEventClass
    {
        public static event SetAccountNumber SetAccountNumberEvent;

        public static void InvokeSetAccountNumberEvent(string accountNumber)
        {
            SetAccountNumberEvent?.Invoke(accountNumber);
        }
    }
}
