using DatabaseHandler;
using DataModule;
using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS
{
    public class CustomerAccountPage
    {

        private CustomerAccountPageDBHandler dbHandler = new CustomerAccountPageDBHandler();

        public async Task<AccountData> CreateAccount(DBAccountData dbAccount)
        {
            AccountData account = new AccountData();

            switch (dbAccount.TypeofAccount)
            {
                case "CURRENT_ACCOUNT":
                    account = new CurrentAccountData(dbHandler.GetAccountId(dbAccount.TypeofAccount), dbAccount.CustomerId, dbAccount.BranchCode, dbAccount.Balance);
                    break;
                case "SAVINGS_ACCOUNT":
                    account = new SavingsAccountData(dbHandler.GetAccountId(dbAccount.TypeofAccount), dbAccount.CustomerId, dbAccount.BranchCode, dbAccount.Balance);
                    break;
                case "RECURRING_ACCOUNT":
                    account = new RecurringAccountData(dbHandler.GetAccountId(dbAccount.TypeofAccount), dbAccount.CustomerId, dbAccount.BranchCode, dbAccount.SourceAccountNumber, dbAccount.Balance);
                    break;
                case "FIXED_DEPOSIT_ACCOUNT":
                    account = new FixedDepositAccountData(dbHandler.GetAccountId(dbAccount.TypeofAccount), dbAccount.CustomerId, dbAccount.BranchCode, dbAccount.Balance);
                    break;
                case "LOAN_ACCOUNT":
                    account = new LoanAccountData(dbHandler.GetAccountId(dbAccount.TypeofAccount), dbAccount.CustomerId, dbAccount.BranchCode, dbAccount.Balance, dbAccount.Tenure);
                    break;
            }
            if ( await Task.Run(()=> dbHandler.CreateAccount(account)) == 0)
            {
                return null;
            }
            return account;
        }

        public  List<AccountData> GetUserAccounts(string id)
        {
             return dbHandler.GetUserAccounts(id); 
        }

        public async Task<List<AccountData>> GetUserPaymentAccounts(string id)
        {
            return await Task.Run(() => { return dbHandler.GetUserPaymentAccounts(id); });
        }

        public async Task<List<AccountData>> GetUserLoanAccounts(string id)
        {
            return await Task.Run(() => { return dbHandler.GetUserLoanAccounts(id); });
        }

        public async Task<int> UpdateAccount(AccountData receiverAccount)
        {

            return await Task.Run(() => { return dbHandler.UpdateAccount(receiverAccount); });
        }
        public async Task<int> UpdateLoanAccount(AccountData receiverAccount)
        {

            return await Task.Run(() => { return dbHandler.UpdateLoanAccount(receiverAccount); });
        }

        public async Task<List<string>> GetBranchCode()
        {
            return await Task.Run(() =>
            {
                return dbHandler.GetBranchCode();
            });
        }

        public async Task<List<AccountData>> GetAllPaymentAccounts()
        {
            return await Task.Run(() =>
            {
                return dbHandler.GetAllPaymentAccounts();
            });
        }

        public async Task<string> GetAddress(string branchCode)
        {
            return await Task.Run(() =>
            {
                return dbHandler.GetAddress(branchCode);
            });
        }

    }
}
