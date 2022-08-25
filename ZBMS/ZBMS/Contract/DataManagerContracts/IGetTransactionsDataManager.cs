using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;

namespace ZBMS.Contract.DataManagerContracts
{
    public interface IGetTransactionsDataManager
    {
        void GetData( GetTransactionsRequest request , ICallBack<GetTransactionsResponse> callBack);
    }
}
