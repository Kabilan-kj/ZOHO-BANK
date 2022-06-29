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
using ZBMS.Models;
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

        private void TransactionGrids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Grid selectedGrid = e.AddedItems[0]; //as Grid;
            var selectedTransaction = TransactionGrids.SelectedItem as ExtendedTransactionDetails;

            //TextBlock sampleTextBlock = selectedGrid1.FindName("TransactionIdValueTextBlock1") as TextBlock;
            //TextBlock sampleTextBlock1 = selectedGrid.FindName("TransactionIdValueTextBlock1") as TextBlock;
            // ((DataModule.TransactionDetails)TransactionGrids.SelectedItem).TransactionId

            // viewModel.SetSelectedTransaction(selectedTransaction.TransactionId);

            // viewModel.SetSelectedTransaction(sampleTextBlock1.Text);

            TransactionDate1.Text = selectedTransaction.Time;
            SenderIdValueTextBlock1.Text = selectedTransaction.SenderId;
            ReceiverIdValueTextBlock1.Text = selectedTransaction.ReceiverId;
            AmountValueTextBlock1.Text = selectedTransaction.AmountString;
            TransactionIdValueTextBlock1.Text = selectedTransaction.TransactionId;

            // BalanceValueTextBlock1.Text = selectedTransaction.AmountString;
            //TransactionTypeImage.Source = new ImageSource(); selectedTransaction.TypeImage;

            ExpandedGrid.Visibility = Visibility.Visible; 
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ExpandedGrid.Visibility = Visibility.Collapsed;
        }
    }
}
