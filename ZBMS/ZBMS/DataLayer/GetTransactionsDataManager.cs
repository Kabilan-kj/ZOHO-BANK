using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;

namespace ZBMS.DataLayer
{
    public class GetTransactionsDataManager
    {
        private GetTransactionsDBHandler dbHandler = new GetTransactionsDBHandler();
        private GetTransactionsResponse response = new GetTransactionsResponse();

        public void GetData(IUseCaseCallBack callBack, GetTransactionsRequest request)
        {
            if(request.transactionId==TransactionID.CustomerID)
            {
               // response.transactions = dbHandler.GetTransactionsByCustomerID(request.Id);
            }
            else
            {
                response.transactions = dbHandler.GetTransactionsBySenderID(request.Id);
            }
            if (response.transactions != null)
            {
                if (response.transactions.Count != 0)
                {
                    callBack.OnSuccess(response);

                }
                else
                {
                    callBack.OnFailure();
                }
            }
            else
            {
                callBack.OnFailure();
            }
        }

    }
}
