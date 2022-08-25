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
        public TransactionFilterType TransactionId { get; set; }
        public RecentTransactionFilterOption FilterOption { get; set; }

        public GetTransactionsRequest(string id,RecentTransactionFilterOption filterOption)
        {
            Id = id;
            TransactionId = TransactionFilterType.CustomerID;
            FilterOption = filterOption;   
        }

        public GetTransactionsRequest(string id, TransactionFilterType transactionId)
        {
            Id = id;
            TransactionId = transactionId;
        }

        public GetTransactionsRequest(string id)
        {
            Id = id;
        }

    }


    public enum TransactionFilterType
    {
        CustomerID, SenderID
    }

    public enum RecentTransactionFilterOption
    {
        Today,LastTwoDays,LastSevenDays
    }
}
