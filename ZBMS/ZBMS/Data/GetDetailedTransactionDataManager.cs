using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract.DataManagerContracts;
using ZBMS.DataLayer;
using ZBMS.GetDetailedTransactionsDomainLayer;

namespace ZBMS.Data
{
    public class GetDetailedTransactionDataManager : IGetDetailedTransactionDataManager
    {
        private GetDetailedTransactionsResponse detailedTransactionsresponse ;
        private GetTransactionsDBHandler dbHandler ;
       public  GetDetailedTransactionDataManager()
       {
            detailedTransactionsresponse = new GetDetailedTransactionsResponse();
            dbHandler = new GetTransactionsDBHandler();
       }

        public void GetDetailedTransaction(GetDetailedTransactionsRequest request, ICallBack<GetDetailedTransactionsResponse> callBack)
        {

            detailedTransactionsresponse.Transaction = dbHandler.GetDetailedTransaction(request.TransactionId);

            if (detailedTransactionsresponse.Transaction != null)
            {
                callBack.OnSuccess(detailedTransactionsresponse);

            }
            else
            {
                callBack.OnFailure();
            }
        }
    }
}
