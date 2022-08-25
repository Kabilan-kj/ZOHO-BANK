using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract.ViewModelBase;
using ZBMS.DomainLayer;
using ZBMS.GetDetailedTransactionsDomainLayer;
using ZBMS.Models;
using ZBMS.ViewModel;
using ZBMS.ZBMSUtils;

namespace ZBMS.PresentationLayer
{

    public enum TransactionsDisplayType
    {
        ListView , GridView
    }

    public class TransactionsPageViewModel : TransactionsPageViewModelBase
    {
       
        public TransactionsPageViewModel(ViewTransactionsPage page)
        {
            Viewtransactionspage = page;
        }

        public override void GetTransactions(string id, TransactionFilterType transactionId)
        {
            Request = new GetTransactionsRequest(id, transactionId);
            new GetTransactionsUseCase(new TransactionsPresenterCallBack(this), Request).Execute();

        }
        public ExtendedTransactionDetails GetDT()
        {
            return DetailedTransaction;
        }
        public void SetSelectedTransaction(ExtendedTransactionDetails transaction)
        {
            transaction.IconColor = SelectedTransaction.IconColor;
            transaction.IconString = SelectedTransaction.IconString;    
            transaction.AmountString= SelectedTransaction.AmountString; 
            if (transaction != null)
            {
                if (transaction.SenderName == transaction.ReceiverName)
                {
                    transaction.Status = "Self Transfered";
                }
                else if (transaction.SenderId == Request.Id)
                {
                    transaction.Status = "Debited";

                }
                else if (transaction.ReceiverId == Request.Id)
                {
                    transaction.Status = "Credited";
                }
                else
                {
                    transaction.Status = "Debited";
                }

                DateTime transactionTime = Convert.ToDateTime(transaction.Time);
                transaction.ModifiedDate = transactionTime.ToString("MMM/dd,yyyy").Replace("-", ",");
                transaction.ModifiedTime = transactionTime.ToString("hh/mm").Replace("-", ":") + transactionTime.ToString("tt").Replace("-", " ");
                transaction.SenderName = transaction.SenderName + $" ({transaction.SenderAccountNumber}) ";
                if (transaction.ReceiverName != null)
                {
                    transaction.ReceiverName = transaction.ReceiverName + $" ({transaction.ReceiverAccountNumber}) ";
                }
                else
                {
                    transaction.ReceiverName = "Unknown_User" + $" ({transaction.ReceiverAccountNumber}) ";
                }

                if (Transactionsdisplaytype == TransactionsDisplayType.ListView)
                {
                    
                    Viewtransactionspage.UpdateListViewSelectedTransaction(transaction);
                }
                else
                {
                    Viewtransactionspage.UpdateSelectedTransactionGridView(transaction);
                }
            }
            else
            {
                Viewtransactionspage.UpdateErrorMessage();
            }
           
        }

        public override void GetSelectedTransaction(ExtendedTransactionDetails _selectedTransaction , TransactionsDisplayType type)
        {
            if (_selectedTransaction != null)
            {
                SelectedTransaction = _selectedTransaction;
                Transactionsdisplaytype = type;
                DetailedTransactionsRequest = new GetDetailedTransactionsRequest(SelectedTransaction.TransactionId);
                DetailedTransactionsPresenterCallBack callBack = new DetailedTransactionsPresenterCallBack(this);
                GetDetailedTransactionsUseCase usecase = new GetDetailedTransactionsUseCase(DetailedTransactionsRequest, callBack);
                usecase.Execute();
            }
           
        }

        public void SetTransactions(IList<ExtendedTransactionDetails> list)
        {
            TransactionsList.Clear();
           
            foreach (var item in list)
            {
                DateTime transactionTime = Convert.ToDateTime(item.Time);
                item.ModifiedDate = transactionTime.ToString("MMM/dd,yyyy").Replace("-", ",");
                item.ModifiedTime = transactionTime.ToString("hh/mm").Replace("-", ":") + transactionTime.ToString("tt").Replace("-", " ");

                if (Request.TransactionId == TransactionFilterType.CustomerID)
                {
                    if (UserDetails.UserAccountNumbers.Contains(item.SenderAccountNumber) && UserDetails.UserAccountNumbers.Contains(item.ReceiverAccountNumber))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Blue);
                        item.IconString = char.ConvertFromUtf32(0xE117);
                    }
                    else if (UserDetails.UserAccountNumbers.Contains(item.SenderAccountNumber))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);
                    }
                    else if (UserDetails.UserAccountNumbers.Contains(item.ReceiverAccountNumber))
                    {
                        item.TypeImage = "Assets/Money1.png";
                        item.AmountString = $"+  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.LimeGreen);
                        item.IconString = char.ConvertFromUtf32(0xE935);
                    }
                    TransactionsList.Add(item);

                }
                else
                {
                    if (item.SenderAccountNumber == Request.Id)
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);

                    }
                    else if (item.ReceiverAccountNumber == Request.Id)
                    {
                        item.TypeImage = "Assets/Money1.png";
                        item.AmountString = $"+  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.LimeGreen);
                        item.IconString = char.ConvertFromUtf32(0xE935);
                    }
                    TransactionsList.Add(item);
                }

            }

            GetSelectedTransaction(TransactionsList[0],TransactionsDisplayType.ListView);
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
                        viewModel.SetTransactions(response.Transactions);

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
