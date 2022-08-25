using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.GetDetailedTransactionsDomainLayer
{
    public class GetDetailedTransactionsRequest
    {
        public string TransactionId;

        public GetDetailedTransactionsRequest (string transactionID)
        {
            TransactionId = transactionID; 
        }

    }
}
