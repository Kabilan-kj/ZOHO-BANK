using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DatabaseHandler
{
    [Table("AccountData")]
    public class DBAccountData
    {
        public int autoIncrementId { get; set; }
        [PrimaryKey]
        public string AccountNumber { get; set; }
        public string CustomerId { get; set; }
        public string BranchCode { get; set; }
        public double Balance { get; set; }
        public string TypeofAccount { get; set; }
        public double MinimumBalance { get; set; }
        public double InterestRate { get; set; }
        public string SourceAccountNumber { get; set; }
        public int Tenure { get; set; }
        public int MonthsCompleted { get; set; }
        public double PrincipalAmount { get; set; }
        public bool IsTriggered { get; set; }

    }
}
