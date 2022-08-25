using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract.DataManagerContracts;
using ZBMS.DomainLayer;
using ZBMS.GetDetailedTransactionsDomainLayer;

namespace ZBMS.DataLayer
{
    public class GetTransactionsDataManager : IGetTransactionsDataManager 
    {
        private GetTransactionsDBHandler _dbHandler = new GetTransactionsDBHandler();
        private GetTransactionsResponse _response= new GetTransactionsResponse();
       

        public void GetData( GetTransactionsRequest request , ICallBack<GetTransactionsResponse> callBack)
        {
            if(request.TransactionId== TransactionFilterType.CustomerID)
            {
                _response.Transactions = _dbHandler.GetTransactionsByCustomerID(request.Id);
            }
            else
            {
                _response.Transactions = _dbHandler.GetTransactionsBySenderID(request.Id);
            }
            if (_response.Transactions != null)
            {
                if (_response.Transactions.Count != 0)
                {
                    callBack.OnSuccess(_response);

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
