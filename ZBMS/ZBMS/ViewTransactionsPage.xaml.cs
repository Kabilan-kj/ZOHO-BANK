using DataModule;
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
using ZBMS.PresentationLayer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewTransactionsPage : Page
    {
       public  GetTransactionsViewModel viewModel = new GetTransactionsViewModel();
       public static  string Id;
        public ViewTransactionsPage()
        {
            
            this.InitializeComponent();
            viewModel.GetTransactions(Id,this);
            ErrorMessage.Visibility = Visibility.Collapsed;
            //if (TransactionDetailList.Count != 0)
            //{
            //    TransactionList = TransactionDetailList;
            //    if (TransactionList.Count == 0)
            //    {
            //        DisplayErrorMessage();
            //    }
            //}
            //else
            //{
            //    DisplayErrorMessage();
            //}

        }

        public static void SetTransactionDetails(List<TransactionDetails> transactionList)
        {
            //TransactionDetailList = transactionList;
            //foreach(TransactionDetails transactionDetail in transactionList)
            //{
            //    if(transactionDetail.Type==TransactionType.CREDITED.ToString())
            //    {
            //        transactionDetail.TypeImage = "Assets/Money1.png";
            //    }
            //    else
            //        transactionDetail.TypeImage = "Assets/Money2.png";
            //}
        }

        public static void SetSenderId(string id)
        {
            Id = id;
        }

        public void UpdateErrorMessage()
        {
            ErrorMessage.Visibility = Visibility.Visible; 
        }

    }
}
