using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.FilterTransactionsUseCase.DomainLayer;

namespace ZBMS.FilterTransactionsUseCase.DataLayer
{
    public class FilterTransactionsDataManager : IFilterTransactionsDataManager
    {
        private FilterTransactionsResponse _response = new FilterTransactionsResponse();
        private GetTransactionsDBHandler _dbHandler;

        public void GetData(FilterTransactionsRequest request, ICallBack<FilterTransactionsResponse> callBack)
        {
            _dbHandler= new GetTransactionsDBHandler();

            _response.Transactions = _dbHandler.GetFilteredTransactions(request.CustomerId,request.StartDate,request.EndDate);

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
