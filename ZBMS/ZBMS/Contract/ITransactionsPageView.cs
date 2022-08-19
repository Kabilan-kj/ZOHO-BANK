using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ZBMS.Contract
{
    public interface ITransactionsPageView
    {
        CoreDispatcher Dispatcher { get; }
        void UpdateErrorMessage();
    }
}
