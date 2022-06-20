using DataModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DomainLayer;

namespace ZBMS.PresentationLayer
{
    public class GetTransactionsViewModel
    {
        public ViewTransactionsPage page;
        public ObservableCollection<TransactionDetails> TransactionsList = new ObservableCollection<TransactionDetails>();
        public void GetTransactions(string id, ViewTransactionsPage _page)
        {
            page = _page;
            new GetTransactionsUseCase(new PresenterCallBack(this), new GetTransactionsRequest(id)).Execute();

        }

        public void SetTransactions(IList<TransactionDetails> list)
        {
            TransactionsList.Clear();
            ObservableCollection<TransactionDetails> Transactions = new ObservableCollection<TransactionDetails>(list);
            foreach (var item in Transactions)
            {
                TransactionsList.Add(item);
            }
        }
    }
}
