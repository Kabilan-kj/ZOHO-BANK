using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using ZBMS.Contract.ViewModelBase;

namespace ZBMS.Contract
{
    public interface ICustomerDashBoardView
    {
       // CustomerDashboardViewModelBase viewModel { get; set; }
        CoreDispatcher Dispatcher { get; }  
        void UpdateErrorMessage();
        void UpdateRecentTransactionErrorMessage();
    }
}
