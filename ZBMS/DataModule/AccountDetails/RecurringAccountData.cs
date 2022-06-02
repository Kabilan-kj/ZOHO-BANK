using System;
using System.Collections.Generic;
using System.Text;

namespace DataModule.AccountDetails
{
    public class RecurringAccountData : AccountData
    {

        public string SourceAccountNumber { get; set; }
        public int Tenure { get; set; }
        public double PrincipalAmount { get; set; }
        public double InterestRate { get; set; }
        public int MonthsCompleted { get; set; }
        public bool IsTriggered { get; set; }
        public RecurringAccountData(int _id, string _customerID, string _bankCode, string _savingsAccountNumber, double _amount) : base(_customerID, _bankCode)
        {
            autoIncrementId = _id;
            AccountNumber = "RCACC" + (1000 + ++autoIncrementId);
            PrincipalAmount = _amount;
            Balance = (PrincipalAmount * Tenure * InterestRate / 12) + PrincipalAmount;
            Type = AccountType.RECURRING_ACCOUNT;
            TypeofAccount = AccountType.RECURRING_ACCOUNT.ToString();
            SourceAccountNumber = _savingsAccountNumber;


        }

        public RecurringAccountData()
        {

        }
    }
}
