using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;
using ZBMS.GetDetailedTransactionsDomainLayer;
using ZBMS.Models;

namespace ZBMS.PresentationLayer
{
    public class TransactionsPageViewModel
    {

        public ViewTransactionsPage Viewtransactionspage;
        
        public ObservableCollection<ExtendedTransactionDetails> TransactionsList = new ObservableCollection<ExtendedTransactionDetails>();
        public ObservableCollection<ExtendedTransactionDetails> RecentTransactions = new ObservableCollection<ExtendedTransactionDetails>();

        public ExtendedTransactionDetails SelectedTransaction = new ExtendedTransactionDetails();
        private GetTransactionsRequest request;
        private GetDetailedTransactionsRequest detailedTransactionsRequest;

        public TransactionsPageViewModel(ViewTransactionsPage _page)
        {
            Viewtransactionspage = _page;
        }

        public void GetTransactions(string id, TransactionID transactionId)
        {
            request = new GetTransactionsRequest(id, transactionId);
            new GetTransactionsUseCase(new TransactionsPresenterCallBack(this), request).Execute();

        }

        public void SetSelectedTransaction(ExtendedTransactionDetails transaction)
        {
            if (transaction.SenderId == request.Id)
            {
                transaction.Status = "Debited";
              
            }
            if (transaction.ReceiverId == request.Id)
            {
                transaction.Status = "Credited";
            }
            DateTime transactionTime= Convert.ToDateTime(transaction.Time);
            transaction.ModifiedDate = transactionTime.ToString("MMM/dd,yyyy").Replace("-", ",");
            transaction.ModifiedTime = transactionTime.ToString("hh/mm").Replace("-", ":") + transactionTime.ToString("tt").Replace("-", " ");
            transaction.SenderName= transaction.SenderName + $" ({transaction.SenderId}) ";
            transaction.ReceiverName = transaction.ReceiverName + $" ({transaction.ReceiverId}) ";
            Viewtransactionspage.UpdateSelectedTransaction(transaction);
        }

        public void GetSelectedTransaction(string transactionId)
        {
            detailedTransactionsRequest = new GetDetailedTransactionsRequest(transactionId);
            DetailedTransactionsPresenterCallBack callBack = new DetailedTransactionsPresenterCallBack(this);
            GetDetailedTransactionsUseCase usecase = new GetDetailedTransactionsUseCase(detailedTransactionsRequest, callBack);
            usecase.Execute();

        }

        public void SetTransactions(IList<ExtendedTransactionDetails> list)
        {
            TransactionsList.Clear();
            foreach (var item in list)
            {
                if (item.SenderId == request.Id)
                {
                    item.TypeImage = "Assets/Money2.png";
                    item.AmountString = $"-  ₹{item.Amount}";
                    item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                    item.IconString = char.ConvertFromUtf32(0xE936);

                }
                if (item.ReceiverId == request.Id)
                {
                    item.TypeImage = "Assets/Money1.png";
                    item.AmountString = $"+  ₹{item.Amount}";
                    item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.LimeGreen);
                    item.IconString = char.ConvertFromUtf32(0xE935);
                }
                TransactionsList.Add(item);
            }
        }

        private class TransactionsPresenterCallBack : ICallBack<GetTransactionsResponse>
        {
                private TransactionsPageViewModel viewModel;

                public TransactionsPresenterCallBack(TransactionsPageViewModel _viewModel)
                {
                    viewModel = _viewModel;
                }


                public async void OnFailure()
                {
                    await viewModel.Viewtransactionspage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {

                        viewModel.Viewtransactionspage.UpdateErrorMessage();
                    });
                }

                public async void OnSuccess(GetTransactionsResponse response)
                {
                    await viewModel.Viewtransactionspage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        viewModel.SetTransactions(response.transactions);

                    });
                }

                public void OnError()
                {
                    throw new NotImplementedException();
                }
        }


            private class DetailedTransactionsPresenterCallBack : ICallBack<GetDetailedTransactionsResponse>
            {
                private TransactionsPageViewModel viewModel;

                public DetailedTransactionsPresenterCallBack(TransactionsPageViewModel _viewModel)
                {
                    viewModel = _viewModel;
                }

                public void OnError()
                {
              
                }

                public async void OnFailure()
                {
                    await viewModel.Viewtransactionspage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {

                        viewModel.Viewtransactionspage.UpdateErrorMessage();
                    });
                }

                public async void OnSuccess(GetDetailedTransactionsResponse response)
                {
                    await viewModel.Viewtransactionspage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        viewModel.SetSelectedTransaction(response.Transaction);

                    });
                }

            }

    }
}
