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
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZBMS.Contract;
using ZBMS.Contract.ViewModelBase;
using ZBMS.DomainLayer;
using ZBMS.Models;
using ZBMS.PresentationLayer;
using ZBMS.ZBMSUtils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewTransactionsPage : Page, ITransactionsPageView
    {
        private TransactionsPageViewModelBase viewModel;
        private static  string Id;
        private static TransactionFilterType transactionFilterType;
        private Grid previousSelectedGrid;
        private Grid selectedGrid;
        public ExtendedTransactionDetails selectedDT;

        public ViewTransactionsPage()
        {
            
            this.InitializeComponent();
            viewModel = new TransactionsPageViewModel(this);

            if (Id != null)
            {
                viewModel.GetTransactions(Id, transactionFilterType);
                ErrorMessage.Visibility = Visibility.Collapsed;
               

                TransactionsGridView.Visibility = Visibility.Collapsed;
                DetailedTransactionGrid.Visibility = Visibility.Collapsed;
                TransactionsListViewGrid.Visibility = Visibility.Visible;
               
            }

            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
            }
            
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
           
        //}


        public static void SetSenderId(string id, TransactionFilterType _transactionId)
        {
            Id = id;
            transactionFilterType = _transactionId;
        }

        public void UpdateErrorMessage()
        {
            ErrorMessage.Visibility = Visibility.Visible; 
        }

        CoreDispatcher ITransactionsPageView.Dispatcher
        {
            get { return this.Dispatcher; }
        }

        public void  UpdateListViewSelectedTransaction(ExtendedTransactionDetails transaction)
        {
            DateTextBlock.Text = transaction.ModifiedDate;
            TimeTextBlock.Text = transaction.ModifiedTime;
            SenderNameTextBlock.Text = transaction.SenderName;  
            ReceiverNameTextBlock.Text = transaction.ReceiverName;
            TransactionAmountTextBlock.Text = transaction.AmountString;
            AmountIconTextBlock.Text = transaction.IconString;
            AmountIconTextBlock.Foreground = transaction.IconColor;
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
                viewModel.GetSelectedTransaction(selectedTransaction,TransactionsDisplayType.ListView);

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

        private void TransactionsGridViewOuterGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

            var pointedGrid = sender as Grid;
            if (selectedGrid != null)
            {
                if (pointedGrid != selectedGrid)
                {

                    pointedGrid.BorderBrush = new SolidColorBrush((Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color);
                    pointedGrid.BorderThickness = new Thickness(2);
                }
            }
            else
            {
                pointedGrid.BorderBrush = new SolidColorBrush((Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color);
                pointedGrid.BorderThickness = new Thickness(2);
            }
        }
        
        private void TransactionsGridViewOuterGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var pointedGrid = sender as Grid;
            if (selectedGrid != null)
            {
                if (pointedGrid != selectedGrid)
                {
                    pointedGrid.BorderThickness = new Thickness(1);
                    pointedGrid.BorderBrush = pointedGrid.BorderBrush = new SolidColorBrush((Application.Current.Resources["BorderColor"] as SolidColorBrush).Color);
                }
            }
            else
            {
                pointedGrid.BorderThickness = new Thickness(1);
                pointedGrid.BorderBrush = pointedGrid.BorderBrush = new SolidColorBrush((Application.Current.Resources["BorderColor"] as SolidColorBrush).Color);
            }
        }

        public void UpdateSelectedTransactionGridView(ExtendedTransactionDetails transaction)
        {
            //var Panel1 = (StackPanel)selectedGrid.FindName("NormalSenderDetails");
            //var Panel2 = (StackPanel)selectedGrid.FindName("ExpandedSenderDetails");
            //var Panel3 = (StackPanel)selectedGrid.FindName("NormalReceiverDetails");
            //var Panel4 = (StackPanel)selectedGrid.FindName("ExpandedReceiverDetails");
            //var Panel5 = (StackPanel)selectedGrid.FindName("StatusDetails");
            //var closeButton = (Button)previousSelectedGrid.FindName("TransactionGridCloseButton");

            //Panel1.Visibility = Visibility.Collapsed;
            //Panel2.Visibility = Visibility.Visible;
            //Panel3.Visibility = Visibility.Collapsed;
            //Panel4.Visibility = Visibility.Visible;
            //Panel5.Visibility = Visibility.Visible;
            //closeButton.Visibility = Visibility.Visible;
            //selectedGrid.Height = 300;
            //selectedGrid.BorderThickness = new Thickness(3);
            //selectedGrid.BorderBrush = new SolidColorBrush((Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color);
            //var TextBlock1 = (TextBlock)selectedGrid.FindName("StatusValueTextBlock");
            //var TextBlock2 = (TextBlock)Panel1.FindName("SenderNameValueTextBlock");
            //var TextBlock3 = (TextBlock)Panel1.FindName("ReceiverNameValueTextBlock");
            //if(transaction.Status!=null)
            //{
            //    TextBlock1.Text = transaction.Status;
            //}

            //TextBlock2.Text = transaction.SenderName;
            //TextBlock3.Text = transaction.ReceiverName;
            EventsUtilsClass.InvokeOnGridSelected(transaction);
        }

        private void VisualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {

        }

        private  void TransactionsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var itemContainer = TransactionsGridView.ContainerFromIndex(TransactionsGridView.SelectedIndex);
            //var grid1 = itemContainer.FindDescendant<Grid>();
            //selectedGrid = grid1;

            var selectedTransaction = TransactionsGridView.SelectedItem as ExtendedTransactionDetails;
            viewModel.GetSelectedTransaction(selectedTransaction, TransactionsDisplayType.GridView);
            TransactionsGridView.SelectedItem = null;
            //if (previousSelectedGrid != null)
            //{
            //    var Panel11 = (StackPanel)previousSelectedGrid.FindName("NormalSenderDetails");
            //    var Panel22 = (StackPanel)previousSelectedGrid.FindName("ExpandedSenderDetails");
            //    var Panel33 = (StackPanel)previousSelectedGrid.FindName("NormalReceiverDetails");
            //    var Panel44 = (StackPanel)previousSelectedGrid.FindName("ExpandedReceiverDetails");
            //    var closeButton = (Button)previousSelectedGrid.FindName("TransactionGridCloseButton");
            //    var Panel55 = (StackPanel)previousSelectedGrid.FindName("StatusDetails");
            //    Panel11.Visibility = Visibility.Visible;
            //    Panel22.Visibility = Visibility.Collapsed;
            //    Panel33.Visibility = Visibility.Visible;
            //    closeButton.Visibility = Visibility.Collapsed;
            //    Panel44.Visibility = Visibility.Collapsed;
            //    Panel55.Visibility = Visibility.Collapsed;

            //    previousSelectedGrid.Height = 150;
            //    previousSelectedGrid.BorderThickness = new Thickness(1);
            //    previousSelectedGrid.BorderBrush =  new SolidColorBrush((Application.Current.Resources["BorderColor"] as SolidColorBrush).Color);

            //}

            //previousSelectedGrid = grid1;

            //EventsUtilsClass.InvokeOnGridSelected(selectedTransaction);

        }

        private void TransactionGridCloseButton_Click(object sender, RoutedEventArgs e)
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
            previousSelectedGrid.BorderThickness = new Thickness(1);
            previousSelectedGrid.BorderBrush =  new SolidColorBrush((Application.Current.Resources["BorderColor"] as SolidColorBrush).Color);

        }
    }
}
