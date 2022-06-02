using System;
using System.Collections.Generic;
using System.Text;

namespace DataModule.AccountDetails
{

    public class SavingsAccountData : AccountData
    {

        public double InterestRate = 0.05;
        public SavingsAccountData(int _id, string _customerID, string _bankCode, double _balance) : base(_customerID, _bankCode)
        {
            autoIncrementId = _id;
            AccountNumber = "SVACC" + (1000 + ++autoIncrementId);
            Balance = _balance;
            MinimumBalance = 2500;
            Type = AccountType.SAVINGS_ACCOUNT;
            TypeofAccount = AccountType.SAVINGS_ACCOUNT.ToString();

        }


        public SavingsAccountData()
        {

        }


    }
}
