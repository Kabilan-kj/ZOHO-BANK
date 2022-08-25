using DataModule;
using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.ZBMSUtils
{
    public class UserDetails
    {
        public static CustomerData Customer { get; set; }
        public static List<AccountData> UserAccounts { get; set; }
        public static List<string> UserAccountNumbers { get; set; }
        private static Dictionary<string, string> _accountTypeList = new Dictionary<string, string>();

        public static Dictionary<string, string> GetAccountTypeList ()
        {
           if(_accountTypeList.Count == 0)
           {
                PopulateAccountTypeList();
           }
            return _accountTypeList;
        }
        private static void PopulateAccountTypeList()
        {
            _accountTypeList.Add(AccountType.CURRENT_ACCOUNT.ToString(), "Current account");
            _accountTypeList.Add(AccountType.SAVINGS_ACCOUNT.ToString(), "Savings account");
            _accountTypeList.Add(AccountType.FIXED_DEPOSIT_ACCOUNT.ToString(), "Fixed deposit account");
            _accountTypeList.Add(AccountType.RECURRING_ACCOUNT.ToString(), "Recurring account");
            _accountTypeList.Add(AccountType.LOAN_ACCOUNT.ToString(), "Loan account");
        }
    }
}
