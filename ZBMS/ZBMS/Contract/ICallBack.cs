using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS
{
    public interface ICallBack<T>
    {
        void OnSuccess(T response);
        void OnError();
        void OnFailure();

    }
}
