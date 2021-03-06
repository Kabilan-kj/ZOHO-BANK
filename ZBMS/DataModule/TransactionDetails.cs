using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DataModule
{
    public enum TransactionType
    {
        DEBITED = 0, CREDITED = 1
    }
    public enum TransactionStatus
    {
        FAILED = 0, SUCCESSFUL = 1
    }

    [Table("TransactionDetails")]
    public class TransactionDetails
    {
        [PrimaryKey, AutoIncrement]
        public int autoIncrement { get; set; }

        public string TransactionId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public DateTime TransactionTime { get; set; }
        public double Amount { get; set; }
        public string Time { get; set; }    
          
        public string Type { get; set; }
        public string Status { get; set; }
     

        public TransactionDetails(double _amount, string _from, string _to, TransactionType _type,
                                 TransactionStatus _status, int _autoIncrement)
        {
            autoIncrement = _autoIncrement;
            TransactionId = "TID" + (1000 + ++autoIncrement);
            TransactionTime = DateTime.Now;
            Amount = _amount;
            SenderId = _from;
            ReceiverId = _to;
            Type = _type.ToString();
            Status = _status.ToString();

        }
        public TransactionDetails()
        {

        }

    }
}
