using DataModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZBMS.DomainLayer;
using ZBMS.ViewModel;
using ZBMS.ZBMSUtils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        private ListViewItem addedItem = new ListViewItem();
        private ListViewItem removedItem = new ListViewItem();
        private ListViewItem previousSelectedItem= new ListViewItem();
      
        public MenuPage()
        {
            this.InitializeComponent();
            addedItem = Dashboard;
            removedItem = Dashboard;
          
            EventsUtilsClass.OnPopupTriggered += TriggerPopup;
            EventsUtilsClass.OnPageChanged += UpdateMenuOption;
            ContentFrame.Navigate(typeof(CustomerDashboard));

        }

        private void UpdateMenuOption(MenuOptions name)
        {
            switch(name)
            {
                case MenuOptions.Dashboard:
                    MenuOptionsListView.SelectedItem = Dashboard;
                    break;

                case MenuOptions.SelfTransfer:
                    MoneyTransferList.SelectedItem = SelfTransfer;
                    break;

                case MenuOptions.OtherCustomerTransfer:
                    MoneyTransferList.SelectedItem = OtherCustomer;
                    break;

                case MenuOptions.OtherBankTransfer:
                    MoneyTransferList.SelectedItem = OtherBank;
                    break;

                case MenuOptions.ViewProfile:
                    ProfileList.SelectedItem = ViewProfile; 
                    break;

                case MenuOptions.EditProfile:
                    ProfileList.SelectedItem= EditProfile;
                    break;

                case MenuOptions.ViewAccount:
                    AccountsList.SelectedItem = ViewAccount;
                    break;

                case MenuOptions.ViewTransaction:
                    AccountsList.SelectedItem= ViewTransaction;
                    break;

                case MenuOptions.Transactions: 
                    MenuOptionsListView.SelectedItem= Transactions;
                    break;
            }
        }
       
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            SignOutFunction();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AboutUsPage));
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
        
        }
        private async void SignOutFunction()
        {

            MessageDialog showDialog = new MessageDialog("Do You Want To Signout Your Account");
            showDialog.Commands.Add(new UICommand("Yes") { Id = 0 });
            showDialog.Commands.Add(new UICommand("No") { Id = 1 });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                FullFrame.Navigate(typeof(MainPage));
            }

        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.RequestedTheme == ElementTheme.Dark)
            {
                this.RequestedTheme = ElementTheme.Light;
                ThemeButton.Content = char.ConvertFromUtf32(0xE706);
            }
            else
            {
                this.RequestedTheme = ElementTheme.Dark;
                ThemeButton.Content = char.ConvertFromUtf32(0xE708);
            }


        }
        private void ColorsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            string selectedColor = ((e.ClickedItem as StackPanel).Parent as ListViewItem).Name.ToString();
            switch (selectedColor)
            {
                case "Red":
                    (Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color = Colors.Red;
                    (Application.Current.Resources["ZBMSAccentColorBrushDark1"] as SolidColorBrush).Color = Colors.DarkRed;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight1"] as SolidColorBrush).Color = Colors.Red;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush).Color = Colors.Red;
                    break;

                case "Green":
                    (Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color = Colors.Green;
                    (Application.Current.Resources["ZBMSAccentColorBrushDark1"] as SolidColorBrush).Color = Colors.DarkGreen;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight1"] as SolidColorBrush).Color = Colors.Green;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush).Color = Colors.LightGreen;
                    break;

                case "Blue":
                    (Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color = Colors.Blue;
                    (Application.Current.Resources["ZBMSAccentColorBrushDark1"] as SolidColorBrush).Color = Colors.DarkBlue;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight1"] as SolidColorBrush).Color = Colors.Blue;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush).Color = Colors.DeepSkyBlue;
                    break;

                case "Pink":
                    (Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush).Color = Colors.HotPink;
                    (Application.Current.Resources["ZBMSAccentColorBrushDark1"] as SolidColorBrush).Color = Colors.HotPink;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight1"] as SolidColorBrush).Color = Colors.DeepPink;
                    (Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush).Color = Colors.Pink;
                    break;
            }
        }

        private void MoneyTransferSelected()
        {
            if (MoneyTransferList.Visibility == Visibility.Visible)
            {
                MoneyTransferList.Visibility = Visibility.Collapsed;
                Downarrow1.Text = char.ConvertFromUtf32(0xE972);

            }
            else
            {
                MoneyTransferList.Visibility = Visibility.Visible;
                Downarrow1.Text = char.ConvertFromUtf32(0xE971);

            }
        }

        private void ProfileSelected()
        {
            if (ProfileList.Visibility == Visibility.Visible)
            {
                ProfileList.Visibility = Visibility.Collapsed;
                Downarrow3.Text = char.ConvertFromUtf32(0xE972);

            }
            else
            {
                ProfileList.Visibility = Visibility.Visible;
                Downarrow3.Text = char.ConvertFromUtf32(0xE971);

            }
        }

        private void AccountsSelected()
        {
            if (AccountsList.Visibility == Visibility.Visible)
            {
                AccountsList.Visibility = Visibility.Collapsed;
                Downarrow2.Text = char.ConvertFromUtf32(0xE972);

            }
            else
            {
                AccountsList.Visibility = Visibility.Visible;
                Downarrow2.Text = char.ConvertFromUtf32(0xE971);

            }
        }

        private void DashboardSelected()
        {

            var selectedItem = (AccountsList.SelectedItem as ListViewItem);
            if (selectedItem != null)
            {
                selectedItem.Background = new SolidColorBrush(Colors.Transparent);
                AccountsList.SelectedItem = null;
            }

            var selectedItem1 = (ProfileList.SelectedItem as ListViewItem);
            if (selectedItem1 != null)
            {
                selectedItem1.Background = new SolidColorBrush(Colors.Transparent);
                ProfileList.SelectedItem = null;
            }
            var selectedItem2 = (MoneyTransferList.SelectedItem as ListViewItem);
            if (selectedItem2 != null)
            {
                selectedItem2.Background = new SolidColorBrush(Colors.Transparent);
                MoneyTransferList.SelectedItem = null;
            }

            addedItem = MenuOptionsListView.SelectedItem as ListViewItem;
            if (addedItem != null)
                addedItem.Foreground = Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush;

            if (removedItem != null)
            {
                if (this.RequestedTheme == ElementTheme.Dark)
                {
                    removedItem.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    removedItem.Foreground = new SolidColorBrush(Colors.Black);
                }
            }

            if (addedItem != removedItem)
            {
                removedItem = addedItem;
                ContentFrame.Navigate(typeof(CustomerDashboard));
            }

        }


        private void TransactionSelected()
        {

            var selectedItem = (AccountsList.SelectedItem as ListViewItem);
            if (selectedItem != null)
            {
                selectedItem.Background = new SolidColorBrush(Colors.Transparent);
                AccountsList.SelectedItem = null;
            }

            var selectedItem1 = (ProfileList.SelectedItem as ListViewItem);
            if (selectedItem1 != null)
            {
                selectedItem1.Background = new SolidColorBrush(Colors.Transparent);
                ProfileList.SelectedItem = null;
            }
            var selectedItem2 = (MoneyTransferList.SelectedItem as ListViewItem);
            if (selectedItem2 != null)
            {
                selectedItem2.Background = new SolidColorBrush(Colors.Transparent);
                MoneyTransferList.SelectedItem = null;
            }

            addedItem = MenuOptionsListView.SelectedItem as ListViewItem;
            if (addedItem != null)
                addedItem.Foreground = Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush;

            if (removedItem != null)
            {
                if (this.RequestedTheme == ElementTheme.Dark)
                {
                    removedItem.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    removedItem.Foreground = new SolidColorBrush(Colors.Black);
                }
            }

            if (addedItem != removedItem)
            {
                removedItem = addedItem;

                ViewTransactionsPage.SetSenderId(UserDetails.Customer.CustomerId, TransactionFilterType.CustomerID);
                ContentFrame.Navigate(typeof(ViewTransactionsPage));
            }
           

        }

        private void ProfileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var newitem = ((sender as ListView).Parent as StackPanel).Parent as ListViewItem;

            if (addedItem != newitem)
            {
                addedItem = newitem;

                if (addedItem != null)
                    addedItem.Foreground = Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush;

                if (removedItem != null)
                {
                    if (this.RequestedTheme == ElementTheme.Dark)
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
                removedItem = addedItem;
            }

            var selectedItem = (MoneyTransferList.SelectedItem as ListViewItem);
            if (selectedItem != null)
            {
                selectedItem.Background = new SolidColorBrush(Colors.Transparent);
                MoneyTransferList.SelectedItem = null;
            }

            var selectedItem1 = (AccountsList.SelectedItem as ListViewItem);
            if (selectedItem1 != null)
            {
                selectedItem1.Background = new SolidColorBrush(Colors.Transparent);
                AccountsList.SelectedItem = null;
            }
            var selectedItem2 = ProfileList.SelectedItem as ListViewItem;
            if(selectedItem2 != null)
            {
                selectedItem2.Background = Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush;
                
                if (previousSelectedItem != null && previousSelectedItem != selectedItem2)
                {
                    previousSelectedItem.Background = new SolidColorBrush(Colors.Transparent);
                }
                previousSelectedItem = selectedItem2;
            }


            if (ViewProfile.IsSelected)
            {
                ContentFrame.Navigate(typeof(ViewProfilePage));
            }
            if (EditProfile.IsSelected)
            {
                ContentFrame.Navigate(typeof(EditProfilePage));
            }

        }

        private void AccountsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var newitem = ((sender as ListView).Parent as StackPanel).Parent as ListViewItem;

            if (addedItem != newitem)
            {
                addedItem = newitem;

                if (addedItem != null)
                    addedItem.Foreground = Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush;

                if (removedItem != null)
                {
                    if (this.RequestedTheme == ElementTheme.Dark)
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
                removedItem = addedItem;
            }

            var selectedItem = (MoneyTransferList.SelectedItem as ListViewItem);
            if (selectedItem != null)
            {
                selectedItem.Background = new SolidColorBrush(Colors.Transparent);
               MoneyTransferList.SelectedItem = null;
            }

            var selectedItem1 = (ProfileList.SelectedItem as ListViewItem);
            if (selectedItem1 != null)
            {
                selectedItem1.Background = new SolidColorBrush(Colors.Transparent);
                ProfileList.SelectedItem = null;
            }

            var selectedItem2 = AccountsList.SelectedItem as ListViewItem;  
            if(selectedItem2 != null)
            {
                selectedItem2.Background = Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush;
                
                if (previousSelectedItem != null && previousSelectedItem != selectedItem2)
                {
                    previousSelectedItem.Background = new SolidColorBrush(Colors.Transparent);
                }
                previousSelectedItem = selectedItem2;
            }

            if (ViewTransaction.IsSelected)
            {
                ViewTransactionsPage.SetSenderId(UserDetails.Customer.CustomerId, TransactionFilterType.CustomerID);
                ContentFrame.Navigate(typeof(ViewTransactionsPage));
            }

            if (ViewAccount.IsSelected)
            {
                ContentFrame.Navigate(typeof(ViewAccountDetails));
            }

        }

        private void MoneyTransferList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var newitem = ((sender as ListView).Parent as StackPanel).Parent as ListViewItem;

            if (addedItem != newitem)
            {
                addedItem = newitem;

                if (addedItem != null)
                    addedItem.Foreground = Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush;

                if (removedItem != null)
                {
                    if (this.RequestedTheme == ElementTheme.Dark)
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
                removedItem = addedItem;
            }

            var selectedItem = (AccountsList.SelectedItem as ListViewItem);
            if (selectedItem != null)
            {
                selectedItem.Background = new SolidColorBrush(Colors.Transparent);
                AccountsList.SelectedItem = null;
            }

            var selectedItem1 = (ProfileList.SelectedItem as ListViewItem);
            if (selectedItem1 != null)
            {
                selectedItem1.Background = new SolidColorBrush(Colors.Transparent);
                ProfileList.SelectedItem = null;
            }
             var selectedItem2 = MoneyTransferList.SelectedItem as ListViewItem;    
            if(selectedItem2 != null)
            {
                selectedItem2.Background = Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush; 
               
                if(previousSelectedItem != null && previousSelectedItem!=selectedItem2)
                {
                    previousSelectedItem.Background = new SolidColorBrush(Colors.Transparent);
                }
                previousSelectedItem = selectedItem2;
            }

            var moneyTransferIndex = MoneyTransferList.SelectedIndex;
            switch (moneyTransferIndex)
            {
                case 0:
                    ContentFrame.Navigate(typeof(SelfTransferPage));
                    break;

                case 1:
                    ContentFrame.Navigate(typeof(OtherCustomerTransferPage));
                    break;

                case 2:
                    ContentFrame.Navigate(typeof(OtherBankCustomerTransferPage));
                    break;
            }

            


        }

        private void MenuOptionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = MenuOptionsListView.SelectedIndex;

            switch (index)
            {
                case 0:
                   
                    DashboardSelected();
                    break;

                case 1:
                    MoneyTransferSelected();
                    break;

                case 2:
                    AccountsSelected();
                    

                    break;

                case 3:
                    ProfileSelected();
                   
                    break;

                case 4:
                    if (addedItem == removedItem)
                        TransactionSelected();
                    break;
            }
             MenuOptionsListView.SelectedItem = null;
        }

        private async void TriggerPopup(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
           {
               BlinkPopup.Begin();
               Popup.Visibility = Visibility.Visible;
               PopupTextBlock.Text = message;
           });
        }

        private void AccountsList_ItemClick(object sender, ItemClickEventArgs e)
        {


            var newitem = ((sender as ListView).Parent as StackPanel).Parent as ListViewItem;

            if (addedItem != newitem)
            {
                addedItem = newitem;

                if (addedItem != null)
                {
                    addedItem.Foreground = Application.Current.Resources["ZBMSAccentColorBrush"] as SolidColorBrush;
                }
                if (removedItem != null)
                {
                    if (this.RequestedTheme == ElementTheme.Dark)
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        removedItem.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
                removedItem = addedItem;
            }

            var selectedItem = (MoneyTransferList.SelectedItem as ListViewItem);
            if (selectedItem != null)
            {
                selectedItem.Background = new SolidColorBrush(Colors.Transparent);
                MoneyTransferList.SelectedItem = null;
            }

            var selectedItem1 = (ProfileList.SelectedItem as ListViewItem);
            if (selectedItem1 != null)
            {
                selectedItem1.Background = new SolidColorBrush(Colors.Transparent);
                ProfileList.SelectedItem = null;
            }

            var selectedItem2 = AccountsList.SelectedItem as ListViewItem;
            if (selectedItem2 != null)
            {
                selectedItem2.Background = Application.Current.Resources["ZBMSAccentColorBrushLight2"] as SolidColorBrush;

                if (previousSelectedItem != null && previousSelectedItem != selectedItem2)
                {
                    previousSelectedItem.Background = new SolidColorBrush(Colors.Transparent);
                }
                previousSelectedItem = selectedItem2;
            }
             
            

            if (e.ClickedItem==ViewTransaction)
            {
                ViewTransactionsPage.SetSenderId(UserDetails.Customer.CustomerId, TransactionFilterType.CustomerID);
                ContentFrame.Navigate(typeof(ViewTransactionsPage));
            }

            if (e.ClickedItem==ViewAccount)
            {
                ContentFrame.Navigate(typeof(ViewAccountDetails));
            }


        }
    }
}
 