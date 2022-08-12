using DatabaseHandler;
using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
    public sealed partial class CreateAccountPage : Page
    {
       private List<string> accountTypes = new List<string>();
       private List<int> tenure= new List<int>();
       private List<string> savingsAccount = new List<string>();
       private List<string> branchCode = new List<string>();
       private List<AccountData> accounts = new List<AccountData>();

       private CustomerAccountPage customerAccountPage = new CustomerAccountPage();
       private CustomerTransactionsPage customerTransaction = new CustomerTransactionsPage();
       private Dictionary<string, AccountType> AccountTypeList = new Dictionary<string, AccountType>();

        public CreateAccountPage()
        {
            this.InitializeComponent();
            GetValues();
        }

        public async  void GetValues()
        {
            accountTypes.Add("Savings account");
            accountTypes.Add("Current account");
            accountTypes.Add("Recurring account");
            accountTypes.Add("Fixed deposit account");
            accountTypes.Add("Loan account");

            AccountTypeList.Add( "Current account", AccountType.CURRENT_ACCOUNT);
            AccountTypeList.Add("Savings account" , AccountType.SAVINGS_ACCOUNT);
            AccountTypeList.Add("Fixed deposit account" , AccountType.FIXED_DEPOSIT_ACCOUNT);
            AccountTypeList.Add( "Recurring account" , AccountType.RECURRING_ACCOUNT);
            AccountTypeList.Add("Loan account", AccountType.LOAN_ACCOUNT);

            branchCode = await customerAccountPage.GetBranchCode();

            tenure.Add(6);
            tenure.Add(12);
            tenure.Add(18);
            tenure.Add(24);

            accounts = CustomerHomePage.GetUserAccounts();
            
            foreach (var account in accounts)
            {
                if (account.TypeofAccount == "SAVINGS_ACCOUNT")
                {
                    savingsAccount.Add(account.AccountNumber);
                }
            }

        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyAccountCreation())
            {
                DBAccountData dbAccount = new DBAccountData();
                dbAccount.TypeofAccount = AccountTypeList[AccountTypeComboBox.SelectedItem.ToString()].ToString();// AccountTypeComboBox.SelectedItem.ToString();
                dbAccount.Balance = Convert.ToDouble(AmountTextBox.Text);
                dbAccount.BranchCode = BranchCodeComboBox.SelectedItem.ToString();
                dbAccount.CustomerId = MainPage.GetCustomerData().CustomerId;
                if (TenureComboBox.SelectedItem != null)
                {
                    dbAccount.Tenure = Convert.ToInt32(TenureComboBox.SelectedItem.ToString());
                }

                if (SavingAccountComboBox.SelectedItem != null)
                {
                    dbAccount.SourceAccountNumber = SavingAccountComboBox.SelectedItem.ToString();
                }

                if (AccountTypeComboBox.SelectedItem.ToString() == "Recurring account")
                {

                    foreach (var savingsaccount in accounts)
                    {
                        if (savingsaccount.AccountNumber == SavingAccountComboBox.SelectedItem.ToString())
                        {
                            if (savingsaccount.Balance < Convert.ToDouble(AmountTextBox.Text))
                            {
                                MessageDialog showDialog = new MessageDialog($"Selected Savings Account does not contain required Initial Balance ");
                                showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
                                showDialog.DefaultCommandIndex = 0;
                                var result = await showDialog.ShowAsync();
                                if ((int)result.Id == 0)
                                {
                                    this.Frame.Navigate(typeof(CreateAccountPage));
                                    return;
                                }
                            }
                            else
                            {
                                CreateAccount(dbAccount, savingsaccount);
                                break;
                            }

                        }
                    }

                }
                else
                {
                    CreateAccount(dbAccount);
                }
            }
          

        }

        //dbAccount.TypeofAccount=AccountTypeComboBox.SelectedItem.ToString();
        //    dbAccount.Balance =Convert.ToDouble(AmountTextBox.Text);
        //    dbAccount.BranchCode=BranchCodeComboBox.SelectedItem.ToString();
      
        private bool VerifyAccountCreation()
        {
            if(AccountTypeComboBox.SelectedItem!=null)
            {
                if(BranchCodeComboBox.SelectedItem!=null)
                {
                    if(AccountTypeComboBox.SelectedItem.ToString() == "Recurring account" || AccountTypeComboBox.SelectedItem.ToString() == "Fixed deposit account" || AccountTypeComboBox.SelectedItem.ToString() == "Loan account")
                    {
                        if (TenureComboBox.SelectedItem != null)
                        {
                            if (AccountTypeComboBox.SelectedItem.ToString() == "Recurring account")
                            {
                                if (AmountTextBox.Text !="")
                                { 
                                    if (SavingAccountComboBox.SelectedItem != null)
                                    {

                                        return true;
                                    }
                                    else
                                    {
                                        ErrorMessage.Text = "Select Savings Account";
                                        return false;
                                    }
                                }
                                else
                                {
                                    ErrorMessage.Text = "Enter initial deposit amount";
                                    return false;
                                }
                            }
                            else
                            {
                                return true; 
                            }
                        }
                        else
                        {
                            ErrorMessage.Text = "Select Tenure";
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    ErrorMessage.Text = "Select Branch Code";
                    return false;
                }
            }
            else
            {
                ErrorMessage.Text = "Select account type";
                return false;
            }
        }

        private async void CreateAccount(DBAccountData dbAccount,AccountData savingsaccount)
        {
       
            AccountData account = await customerAccountPage.CreateAccount(dbAccount);
            if (account != null)
            {

                AccountCreated(account);
            }
            else
            {
                AccountCreationFailed();
            }
            savingsaccount.Balance = savingsaccount.Balance - Convert.ToDouble(AmountTextBox.Text);
            await customerAccountPage.UpdateAccount(savingsaccount);
            string id = await  customerTransaction.MakeTransaction(savingsaccount, Convert.ToDouble(AmountTextBox.Text), account.AccountNumber);

        }
        private async  void CreateAccount(DBAccountData dbAccount)
        {
            AccountData account = await customerAccountPage.CreateAccount(dbAccount);
            if (account != null)
            {

                AccountCreated(account);
            }
            else
            {
                AccountCreationFailed();
            }
        }

        private async void AccountCreated(AccountData account)
        {
            //MessageDialog showDialog = new MessageDialog($" your have been created succesfully !! \n Your AccountNumber is {account.AccountNumber} ");
            //showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            //showDialog.DefaultCommandIndex = 0;
            //var result = await showDialog.ShowAsync();
            //if ((int)result.Id == 0)
            //{
                //this.Frame.Navigate(typeof(CustomerHomePage));
                await Window.Current.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    CoreWindow.GetForCurrentThread().Close();
                });

           // }
        }

        private  void AccountCreationFailed()
        {
            //MessageDialog showDialog = new MessageDialog(" Unable to Create Account");
            //showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            //showDialog.DefaultCommandIndex = 0;
            //var result = await showDialog.ShowAsync();
            //if ((int)result.Id == 0)
            //{
                this.Frame.Navigate(typeof(CreateAccountPage));

            //}
        }

        private async void AccountTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.AddedItems[0].ToString();
          
            if (data =="Recurring account")
            {

                if (savingsAccount.Count == 0)
                {
                    MessageDialog showDialog = new MessageDialog($"You does not have any Savings Account \n Create Savings Account and Try Again");
                    showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
                    showDialog.DefaultCommandIndex = 0;
                    var result = await showDialog.ShowAsync();
                    if ((int)result.Id == 0)
                    {
                        this.Frame.Navigate(typeof(CreateAccountPage));
                    }

                }
                TenurePanel.Visibility = Visibility.Visible;
                SavingsAccountPanel.Visibility = Visibility.Visible;
            }
            if (data == "Current account")
            {
                TenurePanel.Visibility = Visibility.Collapsed;
                SavingsAccountPanel.Visibility = Visibility.Collapsed;    
            }
            if (data == "Loan account")
            {
                TenurePanel.Visibility = Visibility.Visible;
                SavingsAccountPanel.Visibility = Visibility.Collapsed;
            }
            if (data == "Fixed deposit account")
            {
                TenurePanel.Visibility = Visibility.Visible;
                SavingsAccountPanel.Visibility = Visibility.Collapsed;
            }
            if (data == "Savings account")
            {
                TenurePanel.Visibility = Visibility.Collapsed;
                SavingsAccountPanel.Visibility = Visibility.Collapsed;
            }

        }

        private async void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog showDialog = new MessageDialog($"Do you want to cancel account creation ");
            showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            showDialog.DefaultCommandIndex = 0;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                this.Frame.Navigate(typeof(CreateAccountPage));
                return;
            }
        }

        //private async void CloseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    await Window.Current.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    { 
        //        CoreWindow.GetForCurrentThread().Close();
        //    });
        //}
    }
}
