using DataModule;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        private SolidColorBrush colorBrush = new SolidColorBrush(Colors.Yellow);
        private CustomerData customer;

        public MenuPage()
        {
            this.InitializeComponent();
            customer= MainPage.GetCustomerData();
            ContentFrame.Navigate(typeof(CustomerDashboard));
        }
       
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            colorBrush = new SolidColorBrush(Colors.Blue);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MoneyTransferButton_Click(object sender, RoutedEventArgs e)
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

                 AccountsList.Visibility = Visibility.Collapsed;
                Downarrow2.Text = char.ConvertFromUtf32(0xE972);

                ProfileList.Visibility = Visibility.Collapsed;
                Downarrow3.Text = char.ConvertFromUtf32(0xE972);
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
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

                AccountsList.Visibility = Visibility.Collapsed;
                Downarrow2.Text = char.ConvertFromUtf32(0xE972);

                MoneyTransferList.Visibility = Visibility.Collapsed;
                Downarrow1.Text = char.ConvertFromUtf32(0xE972);
            }
        }
        
        private void AccountsButton_Click(object sender, RoutedEventArgs e)
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

                MoneyTransferList.Visibility = Visibility.Collapsed;
                Downarrow1.Text = char.ConvertFromUtf32(0xE972);

                ProfileList.Visibility = Visibility.Collapsed;
                Downarrow3.Text = char.ConvertFromUtf32(0xE972);
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MoneyTransferList.Visibility = Visibility.Collapsed;
            Downarrow1.Text = char.ConvertFromUtf32(0xE972);

            AccountsList.Visibility = Visibility.Collapsed;
            Downarrow2.Text = char.ConvertFromUtf32(0xE972);

            ProfileList.Visibility = Visibility.Collapsed;
            Downarrow3.Text = char.ConvertFromUtf32(0xE972);

            ContentFrame.Navigate(typeof(CustomerDashboard));

        }

        private void TransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            MoneyTransferList.Visibility = Visibility.Collapsed;
            Downarrow1.Text = char.ConvertFromUtf32(0xE972);

            AccountsList.Visibility = Visibility.Collapsed;
            Downarrow2.Text = char.ConvertFromUtf32(0xE972);

            ProfileList.Visibility = Visibility.Collapsed;
            Downarrow3.Text = char.ConvertFromUtf32(0xE972);



            ViewTransactionsPage.SetSenderId("CTACC1004", DomainLayer.TransactionID.SenderID);
            ContentFrame.Navigate(typeof(ViewTransactionsPage));

        }

        private void ProfileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            if (ViewTransaction.IsSelected)
            {
                //ViewTransactionsPage.SetSenderId(customer.CustomerId, TransactionID.CustomerID);
                //ContentFrame.Navigate(typeof(ViewTransactionsPage));
            }

            if (ViewAccount.IsSelected)
            {
                ContentFrame.Navigate(typeof(ViewAccountDetails));
            }
        }

        private void MoneyTransferList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelfTransfer.IsSelected)
            {
                ContentFrame.Navigate(typeof(SelfTransferPage));
            }
            if (OtherCustomer.IsSelected)
            {
                ContentFrame.Navigate(typeof(OtherCustomerTransferPage));
            }
            if (OtherBank.IsSelected)
            {
                ContentFrame.Navigate(typeof(OtherBankCustomerTransferPage));
            }
        }

        //private void ThemeToggleButton_Toggled(object sender, RoutedEventArgs e)
        //{
        //   if (this.RequestedTheme == ElementTheme.Dark)
        //   {
        //        this.RequestedTheme = ElementTheme.Light;
        //        ThemeContent.Text = char.ConvertFromUtf32(0xE706);
        //   }
        //    else
        //    {
        //        this.RequestedTheme = ElementTheme.Dark;
        //        ThemeContent.Text = char.ConvertFromUtf32(0xE708);
        //    }
            
            
           
        //}

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
    }
}
