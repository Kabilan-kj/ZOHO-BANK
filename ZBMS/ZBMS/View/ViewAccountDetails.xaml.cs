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
using ZBMS.Events;
using ZBMS.ZBMSUtils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewAccountDetails : Page
    {
       private List<string> AccountNumbers = new List<string> ();
       private List<AccountData> UserAccounts = new List<AccountData>();
       private CustomerAccountPage customerAccountPage = new CustomerAccountPage();
        private static string selectedAccount; 
        public ViewAccountDetails()
        {
            this.InitializeComponent();
            UserAccounts.Clear();
            UserAccounts =UserDetails.UserAccounts;
            if (UserAccounts.Count ==0)
            {
                ErrorStackPanel.Visibility = Visibility.Visible;
                SelectAccountComboBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                ErrorStackPanel.Visibility = Visibility.Collapsed;
                SelectAccountComboBox.Visibility = Visibility.Visible;
                TriggerButton.Visibility = Visibility.Collapsed;
                LoanPaymentButton.Visibility = Visibility.Collapsed;    
                GetAccountNumbers();
               
            }
          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           selectedAccount= e.Parameter as string;
            if (selectedAccount != null)
            {
                DisplaySelectedAccount();
            }
        }

        public void GetAccountNumbers()
        {
            AccountNumbers.Clear();
            foreach (var account in UserAccounts)
                AccountNumbers.Add(account.AccountNumber);
        }
        public async void DisplaySelectedAccount()
        {
            if (selectedAccount != null)
            {
                for (int i = 0; i < UserAccounts.Count; i++)
                {
                    if (UserAccounts[i].AccountNumber == selectedAccount)
                    {
                        SelectAccountComboBox.SelectedIndex = i;
                        var useraccount = UserAccounts[i];
                        AccountNumberContentTextBlock.Text = useraccount.AccountNumber;
                        AccountTypeContentTextBlock.Text = useraccount.TypeofAccount;
                        BranchCodeContentTextBlock.Text = useraccount.BranchCode;
                        BranchContentTextBlock.Text = await customerAccountPage.GetAddress(useraccount.BranchCode);
                        if (useraccount.TypeofAccount == "RECURRING_ACCOUNT")
                        {
                            TriggerButton.Visibility = Visibility.Visible;
                            RecurringAccountData recurringAccount = (RecurringAccountData)useraccount;
                            TriggerButton.IsOn = recurringAccount.IsTriggered;

                        }
                        if (useraccount.TypeofAccount == "LOAN_ACCOUNT")
                        {
                            LoanPaymentButton.Visibility = Visibility.Visible;
                        }
                    }
                }
            }

        }

        private async void SelectAccountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AccountDetailsGrid.Visibility = Visibility.Visible;
            string account = e.AddedItems[0].ToString();

            foreach (AccountData useraccount in UserAccounts)
            {
                if (useraccount.AccountNumber == account)
                {

                    AccountNumberContentTextBlock.Text = useraccount.AccountNumber;
                    AccountTypeContentTextBlock.Text = useraccount.TypeofAccount;
                    BranchCodeContentTextBlock.Text = useraccount.BranchCode;
                    BranchContentTextBlock.Text = await customerAccountPage.GetAddress(useraccount.BranchCode);
                   if(useraccount.TypeofAccount == "RECURRING_ACCOUNT")
                   {
                        TriggerButton.Visibility = Visibility.Visible;
                        RecurringAccountData recurringAccount =(RecurringAccountData) useraccount;
                        TriggerButton.IsOn = recurringAccount.IsTriggered;

                   }
                   if(useraccount.TypeofAccount == "LOAN_ACCOUNT")
                   {
                      LoanPaymentButton.Visibility = Visibility.Visible;
                   }

                }
              
            }


        }

        private void TriggerButton_Toggled(object sender, RoutedEventArgs e)
        {
            CustomerAccountPageDBHandler dBHandler = new CustomerAccountPageDBHandler();
            foreach (AccountData useraccount in UserAccounts)
            {
                if (useraccount.AccountNumber == SelectAccountComboBox.SelectedItem.ToString())
                {
                    RecurringAccountData recurringAccount = (RecurringAccountData)useraccount;
                    recurringAccount.IsTriggered = TriggerButton.IsOn;
                    dBHandler.UpdateAutomaticTrigger(recurringAccount);
                }
            }
           
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateAccountPage));   
        }

    
        private void LoanPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoanPaymentPage));
        }
    }
}
