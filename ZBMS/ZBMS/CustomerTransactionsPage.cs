using DataModule;
using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS
{
    public class CustomerTransactionsPage
    {
        private CustomerTransactionsPageDBHandler dbHandler = new CustomerTransactionsPageDBHandler();

        public async Task<string> MakeTransaction(AccountData senderAccount, double amount, string receiverAccountNumber)
        {

            TransactionDetails transaction = new TransactionDetails(amount, senderAccount.AccountNumber, receiverAccountNumber,
                       TransactionType.DEBITED, TransactionStatus.SUCCESSFUL,
                       senderAccount.CustomerId, senderAccount.BranchCode, dbHandler.GetTransactionId());

            if ( await Task.Run(() => dbHandler.AddTransaction(transaction)) > 0)
            {
                return transaction.TransactionId;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<TransactionDetails>> GetTransactions()
        {
           return await Task.Run(()=> { return dbHandler.GetTransactions(); });
        }

        public async Task< List<TransactionDetails>> GetTransactions(string id)
        {
            return await Task.Run(() => { return dbHandler.GetTransactions(id); });
        }

    }
}
