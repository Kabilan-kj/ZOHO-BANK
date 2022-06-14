using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.Transactions
{
    public class TransactionsDBHandler
    {
        private TransactionDBAdapter _dbAdapter;
        public void GetTransactions()
        {
            _dbAdapter.GetTransactionDetails("");
        }
    }
}
