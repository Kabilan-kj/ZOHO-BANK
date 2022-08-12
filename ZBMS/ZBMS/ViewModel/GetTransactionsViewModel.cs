using DataModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.DomainLayer;
using ZBMS.FilterTransactionsUseCase.DomainLayer;
using ZBMS.Models;

namespace ZBMS.PresentationLayer
{
    public class GetTransactionsViewModel
    {
        public static List<string> AccountNumbers = new List<string>();
        public ViewTransactionsPage page;
        public CustomerDashboard dashboardPage;
        public  ObservableCollection<ExtendedTransactionDetails> TransactionsList = new ObservableCollection<ExtendedTransactionDetails>();
        public ObservableCollection<ExtendedTransactionDetails> RecentTransactions = new ObservableCollection<ExtendedTransactionDetails>();

        public ExtendedTransactionDetails SelectedTransaction = new ExtendedTransactionDetails();
        private GetTransactionsRequest request;

        private FilterTransactionsRequest filterTransactionsRequest;

        public GetTransactionsViewModel( ViewTransactionsPage _page)
        {
            page = _page;
        }

        public GetTransactionsViewModel(CustomerDashboard _page)
        {
            dashboardPage = _page;
            AccountNumbers=dashboardPage.AccountNumbers;    
        }

        public void GetTransactions(string id, TransactionID transactionId )
        {
            request = new GetTransactionsRequest(id, transactionId);
            new GetTransactionsUseCase(new PresenterCallBack(this),request).Execute();
        }

        public void SetSelectedTransaction(string transactionId)
        {
            foreach(var transaction in TransactionsList)
            {
                if(transaction.TransactionId== transactionId)
                {
                    SelectedTransaction = transaction;
                    break;
                }
            }
        }

        public void GetRecentTransactions(string customerId , RecentTransactionFilterOption filterOption)
        {
            string startDate;
            string endDate;
            DateTime modifiedDate;
            DateTime date = DateTime.Now;

            switch (filterOption)
            {
                case RecentTransactionFilterOption.Today:
                    endDate = date.ToString();
                    startDate= DateTime.Today.ToString();
                    filterTransactionsRequest = new FilterTransactionsRequest(startDate,endDate,customerId);
                    new FilterTransactionUseCase(filterTransactionsRequest, new FilterTransactionsPresenterCallBack(this)).Execute() ;
                    break;

                case RecentTransactionFilterOption.LastTwoDays:
                    endDate = date.ToString();
                    modifiedDate = date.AddDays(2);
                    startDate = date.Subtract(modifiedDate.Subtract(date)).ToString();
                    filterTransactionsRequest = new FilterTransactionsRequest(startDate, endDate, customerId);
                    new FilterTransactionUseCase(filterTransactionsRequest, new FilterTransactionsPresenterCallBack(this)).Execute();
                    break;

                case RecentTransactionFilterOption.LastSevenDays:
                    endDate = date.ToString();
                    modifiedDate = date.AddDays(75);
                    startDate = date.Subtract(modifiedDate.Subtract(date)).ToString();
                    filterTransactionsRequest = new FilterTransactionsRequest(startDate, endDate, customerId);
                    new FilterTransactionUseCase(filterTransactionsRequest, new FilterTransactionsPresenterCallBack(this)).Execute();
                    break;
            }
        }

        public void SetRecentTransactions(IList<ExtendedTransactionDetails> list)
        {
            RecentTransactions.Clear();
            foreach (var item in list)
            {
                DateTime transactionTime = Convert.ToDateTime(item.Time);
                item.ModifiedDate = transactionTime.ToString("MMM/dd,yyyy").Replace("-", ",");
                item.ModifiedTime = transactionTime.ToString("hh/mm").Replace("-", ":") + transactionTime.ToString("tt").Replace("-", " ");

                if (request.transactionId==TransactionID.CustomerID)
                {
                    if (dashboardPage.AccountNumbers.Contains(item.SenderAccountNumber) && dashboardPage.AccountNumbers.Contains(item.ReceiverAccountNumber))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Blue);
                        item.IconString = char.ConvertFromUtf32(0xE117);
                    }
                    else if( dashboardPage.AccountNumbers.Contains(item.SenderAccountNumber))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);
                    }
                    else if(dashboardPage.AccountNumbers.Contains(item.ReceiverAccountNumber))
                    {
                        item.TypeImage = "Assets/Money1.png";
                        item.AmountString = $"+  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.LimeGreen);
                        item.IconString = char.ConvertFromUtf32(0xE935);
                    }
                    RecentTransactions.Add(item);
                    
                }
                else
                {
                    if (item.SenderAccountNumber == request.Id)
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);

                    }
                    else if (item.ReceiverAccountNumber == request.Id)
                    {
                        item.TypeImage = "Assets/Money1.png";
                        item.AmountString = $"+  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.LimeGreen);
                        item.IconString = char.ConvertFromUtf32(0xE935);
                    }
                    RecentTransactions.Add(item);
                }
              
            }
        }


        public class FilterTransactionsPresenterCallBack : ICallBack<FilterTransactionsResponse>
        {
            private GetTransactionsViewModel viewModel;

            public FilterTransactionsPresenterCallBack(GetTransactionsViewModel _viewModel)
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
                    viewModel.dashboardPage.UpdateRecentTransactionErrorMessage();
                });
            }

            public async void OnSuccess(FilterTransactionsResponse response)
            {
                await viewModel.dashboardPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    viewModel.SetRecentTransactions(response.transactions);

                });
            }

        }









    }
}
