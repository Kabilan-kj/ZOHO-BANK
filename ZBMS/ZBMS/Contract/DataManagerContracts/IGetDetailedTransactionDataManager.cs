using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.GetDetailedTransactionsDomainLayer;

namespace ZBMS.Contract.DataManagerContracts
{
    public interface IGetDetailedTransactionDataManager
    {
        void GetDetailedTransaction(GetDetailedTransactionsRequest request, ICallBack<GetDetailedTransactionsResponse> callBack);
    }
}
