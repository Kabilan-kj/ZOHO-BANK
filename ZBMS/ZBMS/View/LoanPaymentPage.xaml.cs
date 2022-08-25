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
            UserLoanAccounts = await customerAccountPage.GetUserLoanAccounts(UserDetails.Customer.CustomerId);
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
                    UserAccounts = await customerAccountPage.GetUserPaymentAccounts(UserDetails.Customer.CustomerId);
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
            EventsUtilsClass.InvokeOnPopupTiggered("Loanpayment Cancelled");
            this.Frame.Navigate(typeof(CustomerDashboard));
        }

        private async void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyTransfer())
            {
                foreach (var account in UserAccounts)
                {
                    if (FromComboBox.SelectedItem.ToString() == account.AccountNumber)
                    {
                        if (account.Balance > Convert.ToDouble(AmountTextBlock.Text))
                        {
                            foreach (var receiverAccount in UserLoanAccounts)
                            {
                                if (ToComboBox.SelectedItem.ToString() == receiverAccount.AccountNumber)
                                {
                                    LoanAccountData loanAccount = (LoanAccountData)receiverAccount;
                                    loanAccount.Balance = loanAccount.Balance - Convert.ToDouble(AmountTextBlock.Text);

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
                            account.Balance = account.Balance - Convert.ToDouble(AmountTextBlock.Text);
                            await customerAccountPage.UpdateAccount(account);
                            string id = await customerTransaction.MakeTransaction(account, Convert.ToDouble(AmountTextBlock.Text), ToComboBox.SelectedItem.ToString());
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
                ErrorBox.Visibility = Visibility.Collapsed;
                if (ToComboBox.SelectedItem!=null)
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

        private  void TransferDone(string message)
        {
           EventsUtilsClass.InvokeOnPopupTiggered(message);
           this.Frame.Navigate(typeof(LoanPaymentPage));
            
        }

        private void LoanPaymentRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ToComboBox.SelectedItem != null)
            {
                ErrorBox.Visibility = Visibility.Collapsed;
                foreach (var receiverAccount in UserLoanAccounts)
                {
                    if (ToComboBox.SelectedItem.ToString() == receiverAccount.AccountNumber)
                    {
                        LoanAccountData loanAccount = (LoanAccountData)receiverAccount;

                        if (FullPayment.IsChecked == true)
                        {
                            AmountStackPanel.Visibility = Visibility.Visible;
                            AmountTextBlock.Text = loanAccount.Balance.ToString();
                        }
                        else if (PartialPayment.IsChecked == true)
                        {
                            AmountStackPanel.Visibility = Visibility.Visible;
                            double balance = ((loanAccount.Tenure * loanAccount.PrincipalAmount * (loanAccount.InterestRate / 12)) + loanAccount.PrincipalAmount) / loanAccount.Tenure;
                            AmountTextBlock.Text = balance.ToString();

                        }

                    }
                }
            }
            else
            {
                ErrorBox.Visibility = Visibility.Visible;
                ErrorBox.Text = "Select Loan Account";
            }
        }
    }
}
