using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.Transactions
{
    public delegate void CallBackDelegate(Object obj);  
    public class TransactionsUseCase : UseCaseBase
    {
        private TransactionsDataManager transactionsDM;
        public override void Action()
        {
            Task.Run(() => transactionsDM.GetTransactions() );
        }

        public override void Execute()
        {
            Action();
        }

        public void GetTransactionDetails()
        {
            Execute();
        }



    }
}
