using DataModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
                TitlePanel.Visibility = Visibility.Visible;

                TransactionsGridViewGrid.Visibility = Visibility.Collapsed;
                DetailedTransactionGrid.Visibility = Visibility.Collapsed;
                TransactionsListViewGrid.Visibility = Visibility.Visible;
                //viewModel.GetSelectedTransaction(viewModel.TransactionsList[0].TransactionId);
            }

            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
                TitlePanel.Visibility = Visibility.Collapsed;
               
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

            //if (TransactionGrids.SelectedItem != null)
            //{
            //    var selectedTransaction = TransactionGrids.SelectedItem as ExtendedTransactionDetails;
            //    this.FindName("DetailedTransactionGrid");
            //    viewModel.GetSelectedTransaction(selectedTransaction.TransactionId);
             
            //}
            //else
            //{
            //    return;
            ////}
            //var selectedGrid = sender as Grid;
            //var grid1 = (Grid)selectedGrid.FindName("TransactionsGrid");
            //grid1.Height = 300;
        }

        public void  UpdateSelectedTransaction(ExtendedTransactionDetails transaction)
        {
            DateTextBlock.Text = transaction.ModifiedDate;
            TimeTextBlock.Text = transaction.ModifiedTime;
            SenderNameTextBlock.Text = transaction.SenderName;  
            ReceiverNameTextBlock.Text = transaction.ReceiverName;
            TransactionAmountTextBlock.Text = transaction.Amount.ToString();
            //TransactionIdTextBlock.Text = transaction.TransactionId;  
            //TransactionStatusTextBlock.Text=transaction.Status; 
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           DetailedTransactionGrid.Visibility = Visibility.Collapsed;
        }

        private void TransactionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TransactionList.SelectedItem != null)
            {
                var selectedTransaction = TransactionList.SelectedItem as ExtendedTransactionDetails;
                this.FindName("DetailedTransactionGrid");
                DetailedTransactionGrid.Visibility = Visibility.Visible;
                viewModel.GetSelectedTransaction(selectedTransaction.TransactionId);

            }
            else
            {
                return;
            }

            //var selectedGrid = sender as Grid;
            //var grid1 = (Grid)selectedGrid.FindName("TransactionsGrid");
            //grid1.Height = 300;

        }

        private void ChangeViewButton_Click(object sender, RoutedEventArgs e)
        {
            if(TransactionsGridViewGrid.Visibility == Visibility.Visible)
            {
                TransactionsGridViewGrid.Visibility = Visibility.Collapsed;
                TransactionsListViewGrid.Visibility = Visibility.Visible;
                TitleTextBlock.Text = "List View :";
            }
            else
            {
                TransactionsGridViewGrid.Visibility = Visibility.Visible;
                TransactionsListViewGrid.Visibility = Visibility.Collapsed;
                TitleTextBlock.Text = "Grid View :";
            }
        }

        private void TransactionList_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

        }

        private void TransactionsGridViewOuterGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            //var selectedGrid = sender as Grid;
            //var grid1 = (Grid)selectedGrid.FindName("TransactionsGrid");
            //grid1.Height = 300;

            //var grid2 = (Grid)selectedGrid.FindName("ExpandedTransactionsGrid");
            //grid1.Background = new SolidColorBrush(Colors.Red);
            //grid1.Visibility = Visibility.Collapsed;
            //grid2.Visibility = Visibility.Visible;
        }

        private void TransactionsGridViewOuterGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            //var selectedGrid = sender as Grid;
            //var grid1 = (Grid)selectedGrid.FindName("TransactionsGrid");
            //grid1.Height = 140;

            //var grid2 = (Grid)selectedGrid.FindName("ExpandedTransactionsGrid");
            //grid1.Background = new SolidColorBrush(Colors.Blue);
            //grid1.Visibility = Visibility.Visible;
            //grid2.Visibility = Visibility.Collapsed;
        }

        public void UpdateSelectedTransactionGridView(ExtendedTransactionDetails transaction)
        {
            //DateTextBlock1.Text = transaction.ModifiedDate;
            //TimeTextBlock1.Text = transaction.ModifiedTime;
            //SenderNameTextBlock1.Text = transaction.SenderName;
            //ReceiverNameTextBlock1.Text = transaction.ReceiverName;
            //TransactionAmountTextBlock1.Text = transaction.Amount.ToString();
            //TransactionIdTextBlock1.Text = transaction.TransactionId;
            //TransactionStatusTextBlock1.Text = transaction.Status;
        }

        private void TransactionsGridViewOuterGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var selectedGrid = sender as Grid;
            var grid1 = (Grid)selectedGrid.FindName("TransactionsGrid");
            grid1.Height = 140;
        }

        private void TransactionGrids_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGrid = sender as GridView;
            var grid1 = (Grid)selectedGrid.FindName("TransactionsGridViewOuterGrid");
            var grid2 = (Grid)grid1.FindName("TransactionsGrid");
            grid2.Height = 140;
        }
    }
}
