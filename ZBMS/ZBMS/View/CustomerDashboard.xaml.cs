using DataModule;
using DataModule.AccountDetails;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZBMS.Contract;
using ZBMS.Contract.ViewModelBase;
using ZBMS.Events;
using ZBMS.Models;
using ZBMS.PresentationLayer;
using ZBMS.ViewModel;
using ZBMS.ZBMSUtils;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerDashboard : Page , ICustomerDashBoardView
    {
        //public List<string> AccountNumbers = new List<string>();
        //private List<ShortcutMenuItems> ShortcutMenuItems = new List<ShortcutMenuItems>();
        //private List<ShortcutMenuItems> MoneyTransferMenuItems = new List<ShortcutMenuItems>();
        //private GetTransactionsViewModel viewmodel;
        //private CustomerLoginPage customerLoginPage = new CustomerLoginPage();
        //private CustomerAccountPage customerAccountPage = new CustomerAccountPage();
        //private CustomerTransactionsPage customerTransaction = new CustomerTransactionsPage();
        //private CustomerData customer = new CustomerData();
       // public static List<AccountData> UserAccounts = new List<AccountData>();
        //private Dictionary<string, string> AccountTypeList = new Dictionary<string, string>();

        private CustomerDashboardViewModelBase viewModel;

        public CustomerDashboard()
        {
            this.InitializeComponent();
             viewModel = new CustomerDashboardViewModel(this);
           // viewModel = DependencyContainersClass.DependencyContainerObject.GetProvider().GetService(typeof(CustomerDashboardViewModelBase)) as CustomerDashboardViewModelBase;
            //viewModel.SetViewObject(this);

            if (viewModel.UserAccounts.Count > 0)
            {
                ContentStackPanel.Visibility = Visibility.Visible;
                ErrorStackPanel.Visibility = Visibility.Collapsed;
                UserDetails.UserAccounts = viewModel.UserAccounts;
            }
            else
            {
                ContentStackPanel.Visibility = Visibility.Collapsed;
                ErrorStackPanel.Visibility = Visibility.Visible;
            }
           
            // GetValues();

        }

        public void UpdateErrorMessage()
        {
            TransactionsErrorMessage.Visibility = Visibility.Visible;
            Filter.Visibility = Visibility.Collapsed;
        }

        public void UpdateRecentTransactionErrorMessage()
        {
            RecentTransactionsErrorMessage.Visibility = Visibility.Visible;
           
        }

        CoreDispatcher ICustomerDashBoardView.Dispatcher
        { 
            get { return this.Dispatcher; }
        }

        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectAccountComboBox.SelectedItem != null)
            {
                EventsUtilsClass.InvokePageChanged(MenuOptions.ViewTransaction);
                ViewTransactionsPage.SetSenderId(SelectAccountComboBox.SelectedItem.ToString(), DomainLayer.TransactionID.SenderID);
                this.Frame.Navigate(typeof(ViewTransactionsPage));
            }
        }

        private void ShowDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectAccountComboBox.SelectedItem != null)
            {
                EventsUtilsClass.InvokePageChanged(MenuOptions.ViewAccount);
                var selectedAccount = SelectAccountComboBox.SelectedItem.ToString();
                this.Frame.Navigate(typeof(ViewAccountDetails),selectedAccount);
            }
        }

        private void TransactionAllButton_Click(object sender, RoutedEventArgs e)
        {
            EventsUtilsClass.InvokePageChanged(MenuOptions.Transactions);
            ViewTransactionsPage.SetSenderId(viewModel.customer.CustomerId, DomainLayer.TransactionID.SenderID);
            this.Frame.Navigate(typeof(ViewTransactionsPage));
        }

        private void SelectAccountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransactionButton.Visibility = Visibility.Visible;
            ShowDetailsButton.Visibility = Visibility.Visible;
            BalanceTextBlock.Visibility = Visibility.Visible;
            BalanceContentTextBlock.Visibility = Visibility.Visible;

            foreach (AccountData useraccount in viewModel.UserAccounts)
            {
                if (useraccount.AccountNumber == e.AddedItems[0].ToString())
                {
                    AccountTypeTextBlock.Text= viewModel.AccountTypeList[useraccount.TypeofAccount];
                    BalanceContentTextBlock.Text = useraccount.Balance.ToString();
                    AccountNumberTextBlock.Text = useraccount.AccountNumber;
                }

            }

        }

        private void ShortcutGrids_ItemClick(object sender, ItemClickEventArgs e)
        {

            var shortcutItems = e.ClickedItem as ShortcutMenuItems;
            switch (shortcutItems.ItemId)
            {
                case 1:

                    CreateNewAccount();
                    break;

                case 2:
                    EventsUtilsClass.InvokePageChanged(MenuOptions.Transactions);
                    ViewTransactionsPage.SetSenderId(viewModel.customer.CustomerId, DomainLayer.TransactionID.CustomerID);
                    this.Frame.Navigate(typeof(ViewTransactionsPage));
                     break;

                case 3:

                    this.Frame.Navigate(typeof(LoanPaymentPage));
                    break;
            }
        }

        private async void CreateNewAccount()
        {
            int newAppViewId = 0;
            var newAppView = CoreApplication.CreateNewView();
            await newAppView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var newWindow = Window.Current;
                var newApplicationView = ApplicationView.GetForCurrentView();
                newAppViewId = newApplicationView.Id;
                newApplicationView.Title = "Create New Account";

                var newFrame = new Frame();
                newFrame.Navigate(typeof(CreateAccountPage), null);

                newWindow.Content = newFrame;
                newWindow.Activate();

            });
            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppViewId);
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewAccount();
        }

        private void MoneyTransferGrids_ItemClick(object sender, ItemClickEventArgs e)
        {
            var  shortcutItems = e.ClickedItem as ShortcutMenuItems;
            switch (shortcutItems.ItemId)
            {
                case 1:
                    EventsUtilsClass.InvokePageChanged(MenuOptions.SelfTransfer);
                    this.Frame.Navigate(typeof(SelfTransferPage));

                    break;
                case 2:
                    EventsUtilsClass.InvokePageChanged(MenuOptions.OtherCustomerTransfer);
                    this.Frame.Navigate(typeof(OtherCustomerTransferPage));

                    break;

                case 3:
                    EventsUtilsClass.InvokePageChanged(MenuOptions.OtherBankTransfer);
                    this.Frame.Navigate(typeof(OtherBankCustomerTransferPage));
                    break;

                case 4:
                    this.Frame.Navigate(typeof(DepositPage));
                    break;
            }
        }

        private void FilterListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterToday.IsSelected)
            {
                viewModel.GetRecentTransactions(viewModel.customer.CustomerId,DomainLayer.RecentTransactionFilterOption.Today);
            }
            else if (FilterLastTwoDays.IsSelected)
            {
                viewModel.GetRecentTransactions(viewModel.customer.CustomerId,  DomainLayer.RecentTransactionFilterOption.LastTwoDays);
            }
            else if (FilterLastSevenDays.IsSelected)
            {
                viewModel.GetRecentTransactions(viewModel.customer.CustomerId,DomainLayer.RecentTransactionFilterOption.LastSevenDays);
            }
        }
    }
}
