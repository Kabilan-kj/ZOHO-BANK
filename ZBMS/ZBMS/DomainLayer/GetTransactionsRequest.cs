using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.DomainLayer
{
    public class GetTransactionsRequest
    {
        public string Id { get; set; }
        public TransactionID transactionId { get; set; }
        public RecentTransactionFilterOption filterOption { get; set; }

        public GetTransactionsRequest(string id,RecentTransactionFilterOption _filterOption)
        {
            Id = id;
            transactionId = TransactionID.CustomerID;
            filterOption = _filterOption;   
        }

        public GetTransactionsRequest(string id, TransactionID _transactionId)
        {
            Id = id;
            transactionId = _transactionId;
        }

        public GetTransactionsRequest(string id)
        {
            Id = id;

        }

    }


    public enum TransactionID
    {
        CustomerID, SenderID
    }

    public enum RecentTransactionFilterOption
    {
        Today,LastTwoDays,LastSevenDays
    }
}
