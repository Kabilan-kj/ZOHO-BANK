using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.FilterTransactionsUseCase.DomainLayer;

namespace ZBMS.FilterTransactionsUseCase.DataLayer
{
    public  interface IFilterTransactionsDataManager
    {
        void GetData(FilterTransactionsRequest request, ICallBack<FilterTransactionsResponse> useCallBack);
    }
}
