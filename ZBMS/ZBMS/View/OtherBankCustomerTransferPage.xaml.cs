using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZBMS.ZBMSUtils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OtherBankCustomerTransferPage : Page
    {

        List<AccountData> UserAccounts = new List<AccountData>();
        List<string> FromUserAccounts = new List<string>();
        CustomerAccountPage customerAccountPage = new CustomerAccountPage();
        CustomerTransactionsPage customerTransaction = new CustomerTransactionsPage();

        List<string> TransactionsIdList = new List<string>();
        public OtherBankCustomerTransferPage()
        {
            this.InitializeComponent();
            GetValues();
        }
  
        private async void GetValues()
        {
            ErrorBox.Visibility = Visibility.Collapsed;
            UserAccounts = await customerAccountPage.GetUserPaymentAccounts(UserDetails.Customer.CustomerId);
            GetIdList();
         
        }
        private async void SelfTransferFailed(string message)
        {
            MessageDialog showDialog = new MessageDialog(message);
            showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            showDialog.DefaultCommandIndex = 0;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                this.Frame.Navigate(typeof(CustomerDashboard));
            }

        }

        private void GetIdList()
        {

            foreach (var account in UserAccounts)
            {
                FromUserAccounts.Add(account.AccountNumber);
            }
          
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SelfTransferFailed("DO you Want to abort Transaction");
        }

        private async void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyTransfer())
            { 
                foreach (var account in UserAccounts)
                {
                    if (FromComboBox.SelectedItem.ToString() == account.AccountNumber)
                    {
                        if (account.Balance > Convert.ToDouble(AmountTextBox.Text))
                        {

                            account.Balance = account.Balance - Convert.ToDouble(AmountTextBox.Text);
                            await customerAccountPage.UpdateAccount(account);
                            string id = await customerTransaction.MakeTransaction(account, Convert.ToDouble(AmountTextBox.Text), ToTextBox.Text);
                            if (id != null)
                            {
                                TransferDone($"Transaction Succesfull \n Transaction Id : {id} ");
                            }
                            else
                            {
                                TransferDone("Transaction Failed ");
                            }

                        }
                        else
                        {
                            ErrorBox.Visibility = Visibility.Visible;
                            ErrorBox.Text = "Transaction Failed  InSufficient Balance";
                        }
                    }
                }
            }
        }

        private bool VerifyTransfer()
        {
            if (FromComboBox.SelectedItem != null)
            {
                if (ToTextBox.Text != "")
                {
                    if (AmountTextBox.Text != "")
                        return true;
                    else
                    {
                        ErrorBox.Visibility = Visibility.Visible;
                        ErrorBox.Text = "Amount must not be Empty";
                    }
                }
                else
                {
                    ErrorBox.Visibility = Visibility.Visible;
                    ErrorBox.Text = "Receiver Account Must not be Empty";
                }
            }
            else
            {
                ErrorBox.Visibility = Visibility.Visible;
                ErrorBox.Text = "Sender Account must not be Empty";
            }
            return false;
        }

        private async void TransferDone(string message)
        {
            MessageDialog showDialog = new MessageDialog(message);
            showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            showDialog.DefaultCommandIndex = 0;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                this.Frame.Navigate(typeof(OtherCustomerTransferPage));
            }
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
