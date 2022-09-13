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
using ZBMS.Contract.ViewModelBase;
using ZBMS.Models;
using ZBMS.ZBMSUtils;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ZBMS.View
{
    public sealed partial class TransactionsGridViewUC : UserControl
    {
        public ExtendedTransactionDetails Transaction { get { return this.DataContext as ExtendedTransactionDetails; } }
      
        public TransactionsGridViewUC()
        {
            this.InitializeComponent();
            this.DataContextChanged += (sender,e) => Bindings.Update();
            EventsUtilsClass.OnGridSelected += ModifySelectedGrid;
        }

        private void TransactionsGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var selectedGrid = sender as Grid;
            if(selectedGrid.Height <200)
            VisualStateManager.GoToState(this, "PointerEnter", false);
        }

        private void TransactionsGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var selectedGrid = sender as Grid;
            if (selectedGrid.Height < 200)
                VisualStateManager.GoToState(this, "PointerExit", false);
        }

        private void TransactionGridCloseButton_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "UnSelected", false);
        }
        private void ModifySelectedGrid(ExtendedTransactionDetails transaction)
        {
            var item = this.DataContext as ExtendedTransactionDetails;
            if (item.TransactionId==transaction.TransactionId)
            {
                VisualStateManager.GoToState(this, "Selected", false);
                SenderNameValueTextBlock.Text = transaction.SenderName;
                ReceiverNameValueTextBlock.Text = transaction.ReceiverName;
                StatusValueTextBlock.Text=transaction.Status;   
            }
            else
            {
                VisualStateManager.GoToState(this, "UnSelected", false);
            }
        }

    }
}
