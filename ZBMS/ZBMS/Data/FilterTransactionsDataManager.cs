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
        private FilterTransactionsResponse response = new FilterTransactionsResponse();
        private GetTransactionsDBHandler dbHandler;

        public FilterTransactionsResponse GetData(FilterTransactionsRequest request, ICallBack<FilterTransactionsResponse> callBack)
        {
            dbHandler= new GetTransactionsDBHandler();
            
            response.transactions = dbHandler.GetFilteredTransactions(request.CustomerId,request.StartDate,request.EndDate);

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
            return response;
        }
    }
}
