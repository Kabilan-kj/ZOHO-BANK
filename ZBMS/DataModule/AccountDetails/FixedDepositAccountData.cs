using System;
using System.Collections.Generic;
using System.Text;

namespace DataModule.AccountDetails
{

    public class FixedDepositAccountData : AccountData
    {

        public double InterestRate { get; set; }
        public double PrincipalAmount { get; set; }
        public int Tenure { get; set; }
        public int MonthsCompleted { get; set; }
        public FixedDepositAccountData(int _id, string _customerID, string _bankCode, double _balance) : base(_customerID, _bankCode)
        {
            AccountCount = _id;
            AccountNumber = "FDACC" + (1000 + ++AccountCount);
            PrincipalAmount = _balance;
            Balance = (PrincipalAmount * Tenure * InterestRate / 12) + PrincipalAmount;
            Type = AccountType.FIXED_DEPOSIT_ACCOUNT;
            TypeofAccount = AccountType.FIXED_DEPOSIT_ACCOUNT.ToString();
            MinimumBalance = 10000.00;

        }

        public FixedDepositAccountData()
        {

        }
    }
}
