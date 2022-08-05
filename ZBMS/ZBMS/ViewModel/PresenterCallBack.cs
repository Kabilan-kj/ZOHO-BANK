using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;
using ZBMS.Models;

namespace ZBMS.PresentationLayer
{
    public class PresenterCallBack : ICallBack<GetTransactionsResponse>
    {
        private GetTransactionsViewModel viewModel;

        public PresenterCallBack(GetTransactionsViewModel _viewModel)
        {
            viewModel = _viewModel; 
        }

        public void OnError()
        {
            throw new NotImplementedException();
        }

        public async void OnFailure()
        {
            await viewModel.dashboardPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
              
                viewModel.dashboardPage.UpdateErrorMessage();
            });
        }

        public async void OnSuccess(GetTransactionsResponse response)
        {
            await viewModel.dashboardPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                viewModel.SetRecentTransactions(response.transactions);
               
            });
        }

        
    }
}
