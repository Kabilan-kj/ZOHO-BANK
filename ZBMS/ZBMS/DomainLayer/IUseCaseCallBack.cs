using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.DomainLayer
{
    public interface IUseCaseCallBack
    {
        void OnSuccess(GetTransactionsResponse response);
        void OnFailure();

    }
}
