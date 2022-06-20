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
            response.transactions = dbHandler.GetTransactions(request.Id);
            if (response.transactions.Count != 0)
            {
                callBack.OnSuccess(response);

            }
            else
            {
                callBack.OnFailure();
            }
        }

    }
}
