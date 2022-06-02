using System;
using System.Collections.Generic;
using System.Text;

namespace DataModule.AccountDetails
{

    public class CurrentAccountData : AccountData
    {


        public CurrentAccountData(int _id, string _customerID, string _bankCode, double _balance) : base(_customerID, _bankCode)
        {
            autoIncrementId = _id;
            AccountNumber = "CTACC" + (1000 + ++autoIncrementId);
            CustomerId = _customerID;
            BranchCode = _bankCode;
            Balance = _balance;
            Type = AccountType.CURRENT_ACCOUNT;
            TypeofAccount = AccountType.CURRENT_ACCOUNT.ToString();
            MinimumBalance = 5000;

        }
        public CurrentAccountData()
        {

        }
    }
}
