using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DataModule.AccountDetails;
using DataModule;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using ZBMS.PresentationLayer;
using ZBMS.DomainLayer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerHomePage : Page
    {
        private List<ShortcutMenuItems> ShortcutMenuItems = new List<ShortcutMenuItems>(); 
        private List<ShortcutMenuItems> MoneyTransferMenuItems = new List<ShortcutMenuItems>();
        private List<string> AccountNumbers = new List<string>();
       
        private CustomerLoginPage customerLoginPage= new CustomerLoginPage();
        private CustomerAccountPage customerAccountPage= new CustomerAccountPage();
        private CustomerTransactionsPage customerTransaction= new CustomerTransactionsPage();
        private CustomerData customer = new CustomerData();
        private static List<AccountData>  UserAccounts = new List<AccountData>();

        public CustomerHomePage()
        {

            this.InitializeComponent();
            GetValues();
          

        }

        public  void GetValues()
        {
            ShortcutMenuItems = ShortcutMenuItemManager.GetShortcutMenuItems();
            MoneyTransferMenuItems = ShortcutMenuItemManager.GetMoneyTransferMenuItems();
            //customer = MainPage.GetCustomerData();

           // UserAccounts.Clear();
            //UserAccounts = await  customerAccountPage.GetUserAccounts(customer.CustomerId);
            if (UserAccounts.Count > 0)
            {
                GetAccountNumbers();
                ContentStackPanel.Visibility = Visibility.Visible;
                ErrorStackPanel.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                ContentStackPanel.Visibility = Visibility.Collapsed;
                ErrorStackPanel.Visibility = Visibility.Visible;
            }
        }

       private void GetAccountNumbers()
       {
            AccountNumbers.Clear(); 

            foreach (AccountData account in UserAccounts)
                AccountNumbers.Add(account.AccountNumber);
           

       }
        public static List<AccountData> GetUserAccounts()
        {
            return UserAccounts;
        }

        private  void ShortcutGrids_ItemClick(object sender, ItemClickEventArgs e)
        {

            ShortcutMenuItems shortcutItems = (ShortcutMenuItems)e.ClickedItem;
            switch(shortcutItems.ItemId)
            {
                case 1:

                    CreateNewAccount();
                    break;
               
             
                case 2:

                    ViewTransactionsPage.SetSenderId(customer.CustomerId, TransactionFilterType.CustomerID);
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
        
        private void SelectAccountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransactionButton.Visibility = Visibility.Visible;
            BalanceTextBlock.Visibility = Visibility.Visible;

            foreach (AccountData useraccount in UserAccounts)
            {
                if (useraccount.AccountNumber == e.AddedItems[0].ToString())
                {
                    AccountTypeTextBlock.Text = useraccount.TypeofAccount;
                    BalanceContentTextBlock.Text = useraccount.Balance.ToString();
                    AccountNumberTextBlock.Text = useraccount.AccountNumber;
                }

            }


        }
        
        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectAccountComboBox.SelectedItem!=null)
            {
                ViewTransactionsPage.SetSenderId(SelectAccountComboBox.SelectedItem.ToString(), TransactionFilterType.SenderID);
                this.Frame.Navigate(typeof(ViewTransactionsPage));
            }

        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
             CreateNewAccount();
        }

        private void MoneyTransferGrids_ItemClick(object sender, ItemClickEventArgs e)
        {

            ShortcutMenuItems shortcutItems = (ShortcutMenuItems)e.ClickedItem;
            switch(shortcutItems.ItemId)
            {
                case 1:
                    
                    this.Frame.Navigate(typeof(SelfTransferPage));

                    break;
                case 2:
                   
                    this.Frame.Navigate(typeof(OtherCustomerTransferPage));
                  
                    break;
             
                case 3:
                    this.Frame.Navigate(typeof(OtherBankCustomerTransferPage));
                    break;

                case 4:
                    this.Frame.Navigate(typeof(DepositPage));
                    break;
            }

        }
    }
}
