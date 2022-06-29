using DataModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ZBMS.DomainLayer;
using ZBMS.PresentationLayer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewTransactionsPage : Page
    {
       private GetTransactionsViewModel viewModel;
       private static  string Id;
       private static TransactionID transactionId;


        public ViewTransactionsPage()
        {
            
            this.InitializeComponent();
            viewModel = new GetTransactionsViewModel(this);

            if (Id != null)
            {
                viewModel.GetTransactions(Id, transactionId);
            }
            ErrorMessage.Visibility = Visibility.Collapsed;
            

        }

        public static void SetSenderId(string id, TransactionID _transactionId)
        {
            Id = id;
            transactionId= _transactionId;
        }

        public void UpdateErrorMessage()
        {
            ErrorMessage.Visibility = Visibility.Visible; 
        }

    }
}
