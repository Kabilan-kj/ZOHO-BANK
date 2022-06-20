using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;

namespace ZBMS.PresentationLayer
{
    public interface IPresenterCallBack
    {
        Task OnSuccess(GetTransactionsResponse response);
        Task OnFailure();
    }
}
