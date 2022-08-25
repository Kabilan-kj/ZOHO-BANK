using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DataModule
{

    public class TransactionDetails
    {
       
        public int TransactionCount { get; set; }
        public string TransactionId { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public DateTime TransactionTime { get; set; }
        public double Amount { get; set; }
        public string Time { get; set; }
                
        public TransactionDetails(double amount, string from, string to,
                                  int count)
        {
            TransactionCount = count;
            TransactionId = "TID" + (1000 + ++TransactionCount);
            TransactionTime = DateTime.Now;
            Amount = amount;
            SenderAccountNumber = from;
            ReceiverAccountNumber = to;
        }

        public TransactionDetails()
        {

        }

    }
}
