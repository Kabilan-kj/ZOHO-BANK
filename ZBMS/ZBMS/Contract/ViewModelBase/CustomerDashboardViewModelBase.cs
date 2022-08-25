using DataModule;
using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;
using ZBMS.FilterTransactionsUseCase.DomainLayer;
using ZBMS.Models;

namespace ZBMS.Contract.ViewModelBase
{
    public abstract class CustomerDashboardViewModelBase
    {

        public ICustomerDashBoardView DashboardView;
        public List<string> AccountNumbers = new List<string>();
        public List<ShortcutMenuItems> ShortcutMenuItems = new List<ShortcutMenuItems>();
        public List<ShortcutMenuItems> MoneyTransferMenuItems = new List<ShortcutMenuItems>();
        public CustomerLoginPage CustomerLoginPage = new CustomerLoginPage();
        public CustomerAccountPage CustomerAccountPage = new CustomerAccountPage();
        public CustomerTransactionsPage CustomerTransaction = new CustomerTransactionsPage();
        public CustomerData Customer = new CustomerData();
        public  List<AccountData> UserAccounts = new List<AccountData>();
        public Dictionary<string, string> AccountTypeList = new Dictionary<string, string>();
       
        public ObservableCollection<ExtendedTransactionDetails> TransactionsList = new ObservableCollection<ExtendedTransactionDetails>();
        public ObservableCollection<ExtendedTransactionDetails> RecentTransactions = new ObservableCollection<ExtendedTransactionDetails>();

        public ExtendedTransactionDetails SelectedTransaction = new ExtendedTransactionDetails();

        public abstract void GetRecentTransactions(string customerId, RecentTransactionFilterOption filterOption);
        public abstract void SetViewObject(ICustomerDashBoardView dashboardView);
    }
}
