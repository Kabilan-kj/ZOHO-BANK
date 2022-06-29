using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;
using ZBMS.Models;

namespace ZBMS.PresentationLayer
{
    public class PresenterCallBack : IPresenterCallBack
    {
        private GetTransactionsViewModel viewModel;

        public PresenterCallBack(GetTransactionsViewModel _viewModel)
        {
            viewModel = _viewModel; 
        }


        public async Task OnFailure()
        {
            await viewModel.page.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
              
                viewModel.page.UpdateErrorMessage();
            });
        }

        public async Task OnSuccess(GetTransactionsResponse response)
        {
            await viewModel.page.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                viewModel.SetTransactions(response.transactions);
               
            });
        }
    }
}
