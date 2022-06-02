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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OtherCustomerTransferPage : Page
    {
        private List<AccountData> UserAccounts = new List<AccountData>();
        private List<AccountData> Accounts = new List<AccountData>();
        private List<string> FromUserAccounts = new List<string>();
        private List<string> ToUserAccounts = new List<string>();
        private CustomerAccountPageDBHandler dbHandler = new CustomerAccountPageDBHandler();
        private CustomerAccountPage customerAccountPage = new CustomerAccountPage();
        private CustomerTransactionsPage customerTransaction = new CustomerTransactionsPage();

        public OtherCustomerTransferPage()
        {
            this.InitializeComponent();
            GetValues();
        }
     
        public async void GetValues()
        {
            ErrorBox.Visibility = Visibility.Collapsed;
            UserAccounts = await customerAccountPage.GetUserPaymentAccounts(MainPage.GetCustomerData().CustomerId);
            Accounts = await  customerAccountPage.GetAllPaymentAccounts();
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
                this.Frame.Navigate(typeof(CustomerHomePage));
            }

        }

        private void GetIdList()
        {

            foreach (var account in UserAccounts)
            {
                FromUserAccounts.Add(account.AccountNumber);
            }
            foreach (var account in Accounts)
            {
                ToUserAccounts.Add(account.AccountNumber);
            }
        }

        private void FromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SelfTransferFailed("DO you Want to abort Transaction");
        }

        private async void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyTransfer()) 
            { 
                int count = 0;
                foreach (var receiverAccount in Accounts)
                {
                    if (ToTextBox.Text == receiverAccount.AccountNumber)
                    {

                        foreach (var account in UserAccounts)
                        {
                            if (FromComboBox.SelectedItem.ToString() == account.AccountNumber)
                            {
                                if (account.Balance > Convert.ToDouble(AmountTextBox.Text))
                                {
                                    count++;
                                    receiverAccount.Balance = receiverAccount.Balance + Convert.ToDouble(AmountTextBox.Text);
                                    dbHandler.UpdateAccount(receiverAccount);
                                    account.Balance = account.Balance - Convert.ToDouble(AmountTextBox.Text);
                                    dbHandler.UpdateAccount(account);
                                    string id = await customerTransaction.MakeTransaction(account, Convert.ToDouble(AmountTextBox.Text), ToTextBox.Text);
                                    if (id != null)

                                        TransferDone($"Transaction Succesfull \n Transaction Id : {id} ");
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
                if (count == 0)
                {
                    ErrorBox.Visibility = Visibility.Visible;
                    ErrorBox.Text = "Invalid Receiver's AccountNumber  ";
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

    }
}
