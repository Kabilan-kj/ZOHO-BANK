using DataModule;
using Microsoft.Toolkit.Uwp.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        private Grid previousSelectedGrid;
        private Grid selectedGrid;
        public ExtendedTransactionDetails selectedDT;

        public ViewTransactionsPage()
        {
            
            this.InitializeComponent();
            viewModel = new TransactionsPageViewModel(this);

            if (Id != null)
            {
                viewModel.GetTransactions(Id, transactionId);
                ErrorMessage.Visibility = Visibility.Collapsed;
                // TitlePanel.Visibility = Visibility.Visible;

                TransactionsGridView.Visibility = Visibility.Collapsed;
                DetailedTransactionGrid.Visibility = Visibility.Collapsed;
                TransactionsListViewGrid.Visibility = Visibility.Visible;
               
            }

            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
               // TitlePanel.Visibility = Visibility.Collapsed;
               
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

        }

        public void  UpdateListViewSelectedTransaction(ExtendedTransactionDetails transaction)
        {
            DateTextBlock.Text = transaction.ModifiedDate;
            TimeTextBlock.Text = transaction.ModifiedTime;
            SenderNameTextBlock.Text = transaction.SenderName;  
            ReceiverNameTextBlock.Text = transaction.ReceiverName;
            TransactionAmountTextBlock.Text = "₹ " + transaction.Amount.ToString();
            TransactionIdTextBlock.Text = transaction.TransactionId;
            TransactionStatusTextBlock.Text = transaction.Status;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           DetailedTransactionGrid.Visibility = Visibility.Collapsed;
            DetailedTransactionsCloseButton.Visibility = Visibility.Collapsed;
        }

        private void TransactionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TransactionList.SelectedItem != null)
            {
                var selectedTransaction = TransactionList.SelectedItem as ExtendedTransactionDetails;
                this.FindName("DetailedTransactionGrid");
                DetailedTransactionGrid.Visibility = Visibility.Visible;
                DetailedTransactionsCloseButton.Visibility = Visibility.Visible;
                viewModel.GetSelectedTransaction(selectedTransaction.TransactionId,TransactionsDisplayType.ListView);

            }
            else
            {
                return;
            }

        }

        private void ChangeViewButton_Click(object sender, RoutedEventArgs e)
        {
            if(TransactionsGridView.Visibility == Visibility.Visible)
            {
                TransactionsGridView.Visibility = Visibility.Collapsed;
                TransactionsListViewGrid.Visibility = Visibility.Visible;
               
            }
            else
            {
                TransactionsGridView.Visibility = Visibility.Visible;
                TransactionsListViewGrid.Visibility = Visibility.Collapsed;
                
            }
        }

        private void TransactionList_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

        }

        private void TransactionsGridViewOuterGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            //var grid1 = sender as Grid;
            //var Panel1 = (StackPanel)grid1.FindName("NormalSenderDetails");
            //var Panel2 = (StackPanel)grid1.FindName("ExpandedSenderDetails");
            //var Panel3 = (StackPanel)grid1.FindName("NormalReceiverDetails");
            //var Panel4 = (StackPanel)grid1.FindName("ExpandedReceiverDetails");

            //Panel1.Visibility = Visibility.Collapsed;
            //Panel2.Visibility = Visibility.Visible;
            //Panel3.Visibility = Visibility.Collapsed;
            //Panel4.Visibility = Visibility.Visible;
            //grid1.Height = 300;
        }

        private void TransactionsGridViewOuterGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            //var grid1 = sender as Grid;
            //var Panel1 = (StackPanel)grid1.FindName("NormalSenderDetails");
            //var Panel2 = (StackPanel)grid1.FindName("ExpandedSenderDetails");
            //var Panel3 = (StackPanel)grid1.FindName("NormalReceiverDetails");
            //var Panel4 = (StackPanel)grid1.FindName("ExpandedReceiverDetails");
            //Panel1.Visibility = Visibility.Visible;
            //Panel2.Visibility = Visibility.Collapsed;
            //Panel3.Visibility = Visibility.Visible;
            //Panel4.Visibility = Visibility.Collapsed;
            //grid1.Height = 150;

        }

        public void UpdateSelectedTransactionGridView(ExtendedTransactionDetails transaction)
        {
            var Panel1 = (StackPanel)selectedGrid.FindName("NormalSenderDetails");
            var Panel2 = (StackPanel)selectedGrid.FindName("ExpandedSenderDetails");
            var Panel3 = (StackPanel)selectedGrid.FindName("NormalReceiverDetails");
            var Panel4 = (StackPanel)selectedGrid.FindName("ExpandedReceiverDetails");
            var Panel5 = (StackPanel)selectedGrid.FindName("StatusDetails");
            var closeButton = (Button)previousSelectedGrid.FindName("TransactionGridCloseButton");

            Panel1.Visibility = Visibility.Collapsed;
            Panel2.Visibility = Visibility.Visible;
            Panel3.Visibility = Visibility.Collapsed;
            Panel4.Visibility = Visibility.Visible;
            Panel5.Visibility = Visibility.Visible;
            closeButton.Visibility = Visibility.Visible;
            selectedGrid.Height = 300;
            var TextBlock1 = (TextBlock)selectedGrid.FindName("StatusValueTextBlock");
            var TextBlock2 = (TextBlock)Panel1.FindName("SenderNameValueTextBlock");
            var TextBlock3 = (TextBlock)Panel1.FindName("ReceiverNameValueTextBlock");

            TextBlock1.Text = transaction.Status;
            TextBlock2.Text = transaction.SenderName;
            TextBlock3.Text = transaction.ReceiverName;
        }

        private void VisualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {

        }

       

        private  void TransactionsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemContainer = TransactionsGridView.ContainerFromIndex(TransactionsGridView.SelectedIndex);
            var grid1 = itemContainer.FindDescendant<Grid>();
            selectedGrid = grid1;

            var selectedTransaction = TransactionsGridView.SelectedItem as ExtendedTransactionDetails;
            viewModel.GetSelectedTransaction(selectedTransaction.TransactionId, TransactionsDisplayType.GridView);
             
            if (previousSelectedGrid != null)
            {
                var Panel11 = (StackPanel)previousSelectedGrid.FindName("NormalSenderDetails");
                var Panel22 = (StackPanel)previousSelectedGrid.FindName("ExpandedSenderDetails");
                var Panel33 = (StackPanel)previousSelectedGrid.FindName("NormalReceiverDetails");
                var Panel44 = (StackPanel)previousSelectedGrid.FindName("ExpandedReceiverDetails");
                var closeButton = (Button)previousSelectedGrid.FindName("TransactionGridCloseButton");
                var Panel55 = (StackPanel)previousSelectedGrid.FindName("StatusDetails");
                Panel11.Visibility = Visibility.Visible;
                Panel22.Visibility = Visibility.Collapsed;
                Panel33.Visibility = Visibility.Visible;
                closeButton.Visibility = Visibility.Collapsed;
                Panel44.Visibility = Visibility.Collapsed;
                Panel55.Visibility = Visibility.Collapsed;

                previousSelectedGrid.Height = 150;
            }
            previousSelectedGrid = grid1;

        }

        private void TransactionGridCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (previousSelectedGrid != null)
            {
                var Panel11 = (StackPanel)previousSelectedGrid.FindName("NormalSenderDetails");
                var Panel22 = (StackPanel)previousSelectedGrid.FindName("ExpandedSenderDetails");
                var Panel33 = (StackPanel)previousSelectedGrid.FindName("NormalReceiverDetails");
                var Panel44 = (StackPanel)previousSelectedGrid.FindName("ExpandedReceiverDetails");
                var closeButton = (Button)previousSelectedGrid.FindName("TransactionGridCloseButton");
                var Panel55 = (StackPanel)previousSelectedGrid.FindName("StatusDetails");
                Panel11.Visibility = Visibility.Visible;
                Panel22.Visibility = Visibility.Collapsed;
                Panel33.Visibility = Visibility.Visible;
                closeButton.Visibility = Visibility.Collapsed;
                Panel44.Visibility = Visibility.Collapsed;
                Panel55.Visibility = Visibility.Collapsed;

                previousSelectedGrid.Height = 150;
            }
        }
    }
}
