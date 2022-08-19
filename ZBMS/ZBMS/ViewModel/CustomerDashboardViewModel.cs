using DataModule.AccountDetails;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract;
using ZBMS.Contract.ViewModelBase;
using ZBMS.DomainLayer;
using ZBMS.FilterTransactionsUseCase.DomainLayer;
using ZBMS.Models;
using ZBMS.PresentationLayer;
using ZBMS.ZBMSUtils;

namespace ZBMS.ViewModel
{
    public class CustomerDashboardViewModel : CustomerDashboardViewModelBase
    {
        private GetTransactionsRequest request;

        private FilterTransactionsRequest filterTransactionsRequest;

        public CustomerDashboardViewModel(ICustomerDashBoardView _dashboardview) 
        {
            dashboardView = _dashboardview;
            GetValues();

        }
       
        public override void SetViewObject(ICustomerDashBoardView _dashboardView)
        {
            dashboardView = _dashboardView;
        }

        public void GetValues()
        {

            MoneyTransferMenuItems = ShortcutMenuItemManager.GetMoneyTransferMenuItems();
            ShortcutMenuItems = ShortcutMenuItemManager.GetShortcutMenuItems();
            //viewmodel = new GetTransactionsViewModel(this);

            AccountTypeList.Add(AccountType.CURRENT_ACCOUNT.ToString(), "Current account");
            AccountTypeList.Add(AccountType.SAVINGS_ACCOUNT.ToString(), "Savings account");
            AccountTypeList.Add(AccountType.FIXED_DEPOSIT_ACCOUNT.ToString(), "Fixed deposit account");
            AccountTypeList.Add(AccountType.RECURRING_ACCOUNT.ToString(), "Recurring account");
            AccountTypeList.Add(AccountType.LOAN_ACCOUNT.ToString(), "Loan account");

            customer = UserDetails.Customer;

            UserAccounts =  customerAccountPage.GetUserAccounts(customer.CustomerId);
            UserDetails.UserAccounts = UserAccounts;
            GetAccountNumbers();
            UserDetails.UserAccountNumbers = AccountNumbers;
            GetTransactions(customer.CustomerId, DomainLayer.TransactionID.CustomerID);

        }
        private void GetAccountNumbers()
        {
            AccountNumbers.Clear();

            foreach (AccountData account in UserAccounts)
                AccountNumbers.Add(account.AccountNumber);

        }
       
        public void GetTransactions(string id, TransactionID transactionId)
        {
            request = new GetTransactionsRequest(id, transactionId);
            new GetTransactionsUseCase(new PresenterCallBack(this), request).Execute();
        }

        public void SetSelectedTransaction(string transactionId)
        {
            foreach (var transaction in TransactionsList)
            {
                if (transaction.TransactionId == transactionId)
                {
                    SelectedTransaction = transaction;
                    break;
                }
            }
        }

        public override void GetRecentTransactions(string customerId, RecentTransactionFilterOption filterOption)
        {
            string startDate;
            string endDate;
            DateTime modifiedDate;
            DateTime date = DateTime.Now;

            switch (filterOption)
            {
                case RecentTransactionFilterOption.Today:
                    endDate = date.ToString();
                    startDate = DateTime.Today.ToString();
                    filterTransactionsRequest = new FilterTransactionsRequest(startDate, endDate, customerId);
                    new FilterTransactionUseCase(filterTransactionsRequest, new FilterTransactionsPresenterCallBack(this)).Execute();
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

                if (request.transactionId == TransactionID.CustomerID)
                {
                    if (AccountNumbers.Contains(item.SenderAccountNumber) && AccountNumbers.Contains(item.ReceiverAccountNumber))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Blue);
                        item.IconString = char.ConvertFromUtf32(0xE117);
                    }
                    else if (AccountNumbers.Contains(item.SenderAccountNumber))
                    {
                        item.TypeImage = "Assets/Money2.png";
                        item.AmountString = $"-  ₹{item.Amount}";

                        item.IconColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                        item.IconString = char.ConvertFromUtf32(0xE936);
                    }
                    else if (AccountNumbers.Contains(item.ReceiverAccountNumber))
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
            private CustomerDashboardViewModel viewModel;

            public FilterTransactionsPresenterCallBack(CustomerDashboardViewModel _viewModel)
            {
                viewModel = _viewModel;
            }

            public void OnError()
            {
                throw new NotImplementedException();
            }

            public async void OnFailure()
            {
                await viewModel.dashboardView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    viewModel.dashboardView.UpdateRecentTransactionErrorMessage();
                });
            }

            public async void OnSuccess(FilterTransactionsResponse response)
            {
                await viewModel.dashboardView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    viewModel.SetRecentTransactions(response.transactions);

                });
            }

        }

        public class PresenterCallBack : ICallBack<GetTransactionsResponse>
        {
            private CustomerDashboardViewModel viewModel;

            public PresenterCallBack(CustomerDashboardViewModel _viewModel)
            {
                viewModel = _viewModel;
            }

            public void OnError()
            {
                throw new NotImplementedException();
            }

            public async void OnFailure()
            {
                await viewModel.dashboardView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {

                    viewModel.dashboardView.UpdateErrorMessage();
                });
            }

            public async void OnSuccess(GetTransactionsResponse response)
            {
                await viewModel.dashboardView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    viewModel.SetRecentTransactions(response.transactions);

                });
            }


        }



    }
}
