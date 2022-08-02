using DataModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.DomainLayer;
using ZBMS.Models;

namespace ZBMS.PresentationLayer
{
    public class GetTransactionsViewModel
    {
        public ViewTransactionsPage page;
        public CustomerDashboard dashboardPage;
        public  ObservableCollection<ExtendedTransactionDetails> TransactionsList = new ObservableCollection<ExtendedTransactionDetails>();
        public ObservableCollection<ExtendedTransactionDetails> RecentTransactions = new ObservableCollection<ExtendedTransactionDetails>();

        public ExtendedTransactionDetails SelectedTransaction = new ExtendedTransactionDetails();
        private GetTransactionsRequest request;

        public GetTransactionsViewModel( ViewTransactionsPage _page)
        {
            page = _page;
        }

        public GetTransactionsViewModel(CustomerDashboard _page)
        {
            dashboardPage = _page;
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

        //public void SetTransactions(IList<ExtendedTransactionDetails> list)
        //{
        //    TransactionsList.Clear();
        //    foreach (var item in list)
        //    {
        //       if(item.SenderId==request.Id)
        //       {
        //            item.TypeImage = "Assets/Money2.png";
        //            item.AmountString = $"-  ₹{item.Amount}";
        //       }
        //       if (item.ReceiverId == request.Id)
        //       {
        //            item.TypeImage = "Assets/Money1.png";
        //            item.AmountString = $"+  ₹{item.Amount}";
        //        }
        //        TransactionsList.Add(item);
        //    }
        //}

        public void GetRecentTransactions(string id , RecentTransactionFilterOption filterOption)
        {

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
                    if (dashboardPage.AccountNumbers.Contains(item.SenderId) && dashboardPage.AccountNumbers.Contains(item.ReceiverId))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Blue);
                        item.IconString = char.ConvertFromUtf32(0xE117);
                    }
                    else if( dashboardPage.AccountNumbers.Contains(item.SenderId))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);
                    }
                    else if(dashboardPage.AccountNumbers.Contains(item.ReceiverId))
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
                    if (item.SenderId == request.Id)
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);

                    }
                    else if (item.ReceiverId == request.Id)
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

    }
}
