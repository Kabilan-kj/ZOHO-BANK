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
       private GetDetailedTransactionsResponse _detailedTransactionsresponse ;
       private GetTransactionsDBHandler _dbHandler ;
       public  GetDetailedTransactionDataManager()
       {
            _detailedTransactionsresponse = new GetDetailedTransactionsResponse();
            _dbHandler = new GetTransactionsDBHandler();
       }

        public void GetDetailedTransaction(GetDetailedTransactionsRequest request, ICallBack<GetDetailedTransactionsResponse> callBack)
        {

            _detailedTransactionsresponse.Transaction = _dbHandler.GetDetailedTransaction(request.TransactionId);

            if (_detailedTransactionsresponse.Transaction != null)
            {
                callBack.OnSuccess(_detailedTransactionsresponse);

            }
            else
            {
                callBack.OnFailure();
            }
        }
    }
}
