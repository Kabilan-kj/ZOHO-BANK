using System;
using System.Collections.Generic;
using System.Text;

namespace DataModule.AccountDetails
{
    public class LoanAccountData : AccountData
    {

        public double InterestRate = 0.10;
        public int Tenure { get; set; }
        public double PrincipalAmount { get; set; }
        public int MonthsCompleted { get; set; }

        public LoanAccountData(int _id, string _customerID, string _bankCode, double _loanAmount, int _tenure) : base(_customerID, _bankCode)
        {
            autoIncrementId = _id;
            AccountNumber = "LNACC" + (1000 + ++autoIncrementId);
            Type = AccountType.LOAN_ACCOUNT;
            TypeofAccount = AccountType.LOAN_ACCOUNT.ToString();
            Tenure = _tenure;
            PrincipalAmount = _loanAmount;
            Balance = (Tenure * PrincipalAmount * (InterestRate / 12)) + PrincipalAmount;

        }


        public LoanAccountData()
        {

        }
    }
}
