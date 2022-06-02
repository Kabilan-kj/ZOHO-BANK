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
    public sealed partial class LoanPaymentPage : Page
    {
        private List<AccountData> UserAccounts = new List<AccountData>();
        private List<AccountData> UserLoanAccounts = new List<AccountData>();
        private List<string> FromUserAccounts = new List<string>();
        private List<string> ToUserAccounts = new List<string>();
        private CustomerAccountPage customerAccountPage = new CustomerAccountPage();
        private CustomerTransactionsPage customerTransaction = new CustomerTransactionsPage();

        public LoanPaymentPage()
        {
            this.InitializeComponent();
            GetValues();
        }

        private async void GetValues()
        {
            UserLoanAccounts = await customerAccountPage.GetUserLoanAccounts(MainPage.GetCustomerData().CustomerId);
            if (UserLoanAccounts.Count != 0)
            {
               
                foreach (var account in UserLoanAccounts)
                {
                    LoanAccountData loanAccount = (LoanAccountData)account;
                    if (loanAccount.Balance!=0)
                    {
                        ToUserAccounts.Add(account.AccountNumber);
                    }
                }
                if (ToUserAccounts.Count == 0)
                {
                    ContentGrid.Visibility = Visibility.Collapsed;
                    NoAccountText.Visibility = Visibility.Visible;
                    NoAccountText.Text = "Loan Re-Payment has been Completed";
                }
                else
                {
                   
                    ContentGrid.Visibility = Visibility.Visible;
                    NoAccountText.Visibility = Visibility.Collapsed;
                    UserAccounts = await customerAccountPage.GetUserPaymentAccounts(MainPage.GetCustomerData().CustomerId);
                    foreach (var account in UserAccounts)
                    {
                        FromUserAccounts.Add(account.AccountNumber);
                    }
                }
            }
            else
            {
                ContentGrid.Visibility = Visibility.Collapsed;
                NoAccountText.Visibility = Visibility.Visible;
            }
  
        }

        private async void TransferFailed(string message)
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

        private void FromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.AddedItems[0].ToString();
            foreach (var account in FromUserAccounts)
            {
                if (data != account)
                    ToUserAccounts.Add(account);
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            TransferFailed("DO you Want to abort Transaction");
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
                            foreach (var receiverAccount in UserLoanAccounts)
                            {
                                if (ToComboBox.SelectedItem.ToString() == receiverAccount.AccountNumber)
                                {
                                    LoanAccountData loanAccount = (LoanAccountData)receiverAccount;
                                    loanAccount.Balance = loanAccount.Balance - Convert.ToDouble(AmountTextBox.Text);

                                    if (FullPayment.IsChecked == true)
                                    {
                                        loanAccount.MonthsCompleted = 0;

                                    }
                                    else if (PartialPayment.IsChecked == true)
                                    {
                                        loanAccount.MonthsCompleted -= loanAccount.MonthsCompleted;
                                    }

                                    await customerAccountPage.UpdateLoanAccount(loanAccount);
                                }
                            }
                            account.Balance = account.Balance - Convert.ToDouble(AmountTextBox.Text);
                            await customerAccountPage.UpdateAccount(account);
                            string id = await customerTransaction.MakeTransaction(account, Convert.ToDouble(AmountTextBox.Text), ToComboBox.SelectedItem.ToString());
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

        private bool VerifyTransfer()
        {
            if(FromComboBox.SelectedItem!=null)
            {
                if(ToComboBox.SelectedItem!=null)
                {
                    if(AmountTextBlock.Text!=null)
                        return true;
                    else
                    {
                        ErrorBox.Visibility= Visibility.Visible;
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
                this.Frame.Navigate(typeof(LoanPaymentPage));
            }
        }

        private void LoanPaymentRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var receiverAccount in UserLoanAccounts)
            {
                if (ToComboBox.SelectedItem.ToString() == receiverAccount.AccountNumber)
                {
                    LoanAccountData loanAccount = (LoanAccountData)receiverAccount;
                   
                    if (FullPayment.IsChecked == true)
                    {
                        
                        AmountTextBox.Text= loanAccount.Balance.ToString();
                    }
                    else if (PartialPayment.IsChecked == true)
                    {

                        double balance = ((loanAccount.Tenure * loanAccount.PrincipalAmount * (loanAccount.InterestRate / 12)) + loanAccount.PrincipalAmount) / loanAccount.Tenure;
                        AmountTextBox.Text = balance.ToString();

                    }

                }
            }
        }
    }
}
