using System;
using System.Collections.Generic;
using System.Text;

namespace DataModule.AccountDetails
{
    public enum AccountType
    {
        CURRENT_ACCOUNT = 1, SAVINGS_ACCOUNT, RECURRING_ACCOUNT, FIXED_DEPOSIT_ACCOUNT, LOAN_ACCOUNT
    }

    public class AccountData
    {

        public int autoIncrementId { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerId { get; set; }
        public string BranchCode { get; set; }
        public double Balance { get; set; }
        public string TypeofAccount { get; set; }

        public AccountType Type { get; set; }

        public double MinimumBalance;

        public AccountData(string _customerID, string _bankCode)
        {
            CustomerId = _customerID;
            BranchCode = _bankCode;

        }


        public AccountData()
        {

        }


    }
}
