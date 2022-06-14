using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.Transactions
{
    public  class TransactionsDataManager
    {
        public delegate void CallBackDelegate(Object obj);
        private TransactionsDBHandler dBHandler;
        public void GetTransactions()
        {
            dBHandler.GetTransactions();
        }
        
    }
}
