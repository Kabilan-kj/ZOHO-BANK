using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;
using ZBMS.GetDetailedTransactionsDomainLayer;
using ZBMS.Models;
using ZBMS.PresentationLayer;
using ZBMS.ViewModel;

namespace ZBMS.Contract.ViewModelBase
{
    public abstract class TransactionsPageViewModelBase
    {
        public ViewTransactionsPage Viewtransactionspage;
        public ExtendedTransactionDetails DT;
        public ObservableCollection<ExtendedTransactionDetails> TransactionsList = new ObservableCollection<ExtendedTransactionDetails>();
        public ObservableCollection<ExtendedTransactionDetails> RecentTransactions = new ObservableCollection<ExtendedTransactionDetails>();

        public ExtendedTransactionDetails SelectedTransaction = new ExtendedTransactionDetails();
        public GetTransactionsRequest request;
        public GetDetailedTransactionsRequest detailedTransactionsRequest;
        public TransactionsDisplayType transactionsdisplaytype;

        public abstract void GetSelectedTransaction(string transactionId, TransactionsDisplayType type);
        public abstract void GetTransactions(string id, TransactionID transactionId);

    }
}
