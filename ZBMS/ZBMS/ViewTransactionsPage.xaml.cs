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
using Windows.UI.Xaml.Media.Imaging;
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
       private TransactionsPageViewModel viewModel;
       private static  string Id;
       private static TransactionID transactionId;


        public ViewTransactionsPage()
        {
            
            this.InitializeComponent();
            viewModel = new TransactionsPageViewModel(this);

            if (Id != null)
            {
                viewModel.GetTransactions(Id, transactionId);
                ErrorMessage.Visibility = Visibility.Collapsed;
              
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
               
            }
            
           
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

            if (TransactionGrids.SelectedItem != null)
            {
                var selectedTransaction = TransactionGrids.SelectedItem as ExtendedTransactionDetails;
                this.FindName("DetailedTransactionGrid");
                viewModel.GetSelectedTransaction(selectedTransaction.TransactionId);
             
            }
            else
            {
                return;
            }
        }

        public void  UpdateSelectedTransaction(ExtendedTransactionDetails transaction)
        {
            DateTextBlock.Text = transaction.ModifiedDate;
            TimeTextBlock.Text = transaction.ModifiedTime;
            SenderNameTextBlock.Text = transaction.SenderName;  
            ReceiverNameTextBlock.Text = transaction.ReceiverName;
            TransactionAmountTextBlock.Text = transaction.Amount.ToString();
            TransactionIdTextBlock.Text = transaction.TransactionId;  
            TransactionStatusTextBlock.Text=transaction.Status; 
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           //S ExpandedGrid.Visibility = Visibility.Collapsed;
        }
    }
}
