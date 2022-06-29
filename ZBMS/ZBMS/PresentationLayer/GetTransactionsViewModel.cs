using DataModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.DomainLayer;
using ZBMS.Models;

namespace ZBMS.PresentationLayer
{
    public class GetTransactionsViewModel
    {
        public ViewTransactionsPage page;
        public  ObservableCollection<ExtendedTransactionDetails> TransactionsList = new ObservableCollection<ExtendedTransactionDetails>();
      
        private GetTransactionsRequest request;

        public GetTransactionsViewModel( ViewTransactionsPage _page)
        {
            page = _page;
        }

        public void GetTransactions(string id, TransactionID transactionId )
        {
            request = new GetTransactionsRequest(id, transactionId);
            new GetTransactionsUseCase(new PresenterCallBack(this),request, new GetTransactionsDataManager()).Execute();

        }

        public void SetTransactions(IList<ExtendedTransactionDetails> list)
        {
            TransactionsList.Clear();
            foreach (var item in list)
            {
               if(item.SenderId==request.Id)
               {
                    item.TypeImage = "Assets/Money2.png";
                    item.AmountString = $"-  ₹{item.Amount}";
               }
               if (item.ReceiverId == request.Id)
               {
                    item.TypeImage = "Assets/Money1.png";
                    item.AmountString = $"+  ₹{item.Amount}";
                }
                TransactionsList.Add(item);
            }
           

        }
       
    }
}
