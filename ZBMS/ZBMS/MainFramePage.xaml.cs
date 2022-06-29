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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using DataModule;
using ZBMS.DomainLayer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainFramePage : Page
    {

        private CustomerData customer = new CustomerData();
        private CustomerTransactionsPage customerTransaction = new CustomerTransactionsPage();

        public MainFramePage()
        {
            this.InitializeComponent();
            HomePageFrame.Navigate(typeof(CustomerHomePage));
            customer=MainPage.GetCustomerData();
            SetCustomerDetails();
            
        }
       
        public void SetCustomerDetails()
        {
            UserNameTextBlock.Text = customer.Name; 
        }


        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

            MoreOptions.Hide();
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {

            MoreOptions.Hide();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            SignOutFunction();
            MoreOptions.Hide();
        }
     
        private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
        {
           HomePageFrame.Navigate(typeof(ViewProfilePage));
            MoreOptions.Hide();

        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if(HomePageFrame.CanGoForward)
            {
                HomePageFrame.GoForward();  
            }

        }
        

        private void BackWordButton_Click(object sender, RoutedEventArgs e)
        {
            if(HomePageFrame.CanGoBack)
            {
                HomePageFrame.GoBack(); 
            }
        }

    
        private async void SignOutFunction()
        {

            MessageDialog showDialog = new MessageDialog("Do You Want To Signout Your Account");
            showDialog.Commands.Add(new UICommand("Yes") { Id =0 });
            showDialog.Commands.Add(new UICommand("No") { Id = 1 });
            showDialog.DefaultCommandIndex=0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            if( (int)result.Id==0)
            {
             FullFrame.Navigate(typeof(MainPage));
            }

        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            HomePageFrame.Navigate(typeof(EditProfilePage));
            MoreOptions.Hide();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeListVisibility();
            HomePageFrame.Navigate(typeof(CustomerHomePage));
        }

        private void MoneyTransferButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoneyTransferList.Visibility == Visibility.Visible)
            { 
                MoneyTransferList.Visibility = Visibility.Collapsed;
                ExpandCharacter1.Text = char.ConvertFromUtf32(0xE011);

            }
                
            else
            {
                MoneyTransferList.Visibility = Visibility.Visible;
                ExpandCharacter1.Text = char.ConvertFromUtf32(0xE010);

                AccountSettingsList.Visibility = Visibility.Collapsed;
                ExpandCharacter3.Text = char.ConvertFromUtf32(0xE011);

                ProfileSettingsList.Visibility = Visibility.Collapsed;
                ExpandCharacter2.Text = char.ConvertFromUtf32(0xE011);

            }
        }

        private void AccountSettings_Click(object sender, RoutedEventArgs e)
        {
            if (AccountSettingsList.Visibility == Visibility.Visible)
            { 
                AccountSettingsList.Visibility = Visibility.Collapsed;
                ExpandCharacter3.Text = char.ConvertFromUtf32(0xE011);
            }
                
            else
            { 
                AccountSettingsList.Visibility = Visibility.Visible;
                ExpandCharacter3.Text = char.ConvertFromUtf32(0xE010);

                ProfileSettingsList.Visibility = Visibility.Collapsed;
                ExpandCharacter2.Text = char.ConvertFromUtf32(0xE011);

                MoneyTransferList.Visibility = Visibility.Collapsed;
                ExpandCharacter1.Text = char.ConvertFromUtf32(0xE011);
            }
                
        }

        private void ProfileSettings_Click(object sender, RoutedEventArgs e)
        {
            if (ProfileSettingsList.Visibility == Visibility.Visible)
            {
                ProfileSettingsList.Visibility = Visibility.Collapsed;
                ExpandCharacter2.Text= char.ConvertFromUtf32(0xE011);
            }

            else
            {
                ProfileSettingsList.Visibility = Visibility.Visible;
                ExpandCharacter2.Text = char.ConvertFromUtf32(0xE010);

                MoneyTransferList.Visibility = Visibility.Collapsed;
                ExpandCharacter1.Text = char.ConvertFromUtf32(0xE011);

                AccountSettingsList.Visibility = Visibility.Collapsed;
                ExpandCharacter3.Text = char.ConvertFromUtf32(0xE011);
            }

        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            ChangeListVisibility();
            SignOutFunction();
        }

        private  void AccountSettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ViewTransaction.IsSelected)
            {
                ViewTransactionsPage.SetSenderId(customer.CustomerId, TransactionID.CustomerID);
                HomePageFrame.Navigate(typeof(ViewTransactionsPage));
            }
         
            if(ViewAccount.IsSelected)
            {
                HomePageFrame.Navigate(typeof(ViewAccountDetails));
            }
        }

        private void ProfileSettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ViewProfile.IsSelected)
            {
                HomePageFrame.Navigate (typeof(ViewProfilePage));   
            }
            if (EditProfile.IsSelected)
            {
                HomePageFrame.Navigate(typeof(EditProfilePage));
            }
        }

        private void MoneyTransferList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SelfTransfer.IsSelected)
            {
                HomePageFrame.Navigate(typeof (SelfTransferPage));  
            }
            if(OtherCustomer.IsSelected)
            {
                HomePageFrame.Navigate(typeof(OtherCustomerTransferPage));
            }
            if(OtherBank.IsSelected)
            {
                HomePageFrame.Navigate(typeof(OtherBankCustomerTransferPage));
            }
        }

        private void MoneyTransferList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelfTransfer.IsSelected)
            {
                HomePageFrame.Navigate(typeof(SelfTransferPage));
            }
            if (OtherCustomer.IsSelected)
            {
                HomePageFrame.Navigate(typeof(OtherCustomerTransferPage));
            }
            if (OtherBank.IsSelected)
            {
                HomePageFrame.Navigate(typeof(OtherBankCustomerTransferPage));
            }
        }
        private void ChangeListVisibility()
        {
            ProfileSettingsList.Visibility = Visibility.Collapsed;
            ExpandCharacter2.Text = char.ConvertFromUtf32(0xE011);

            MoneyTransferList.Visibility = Visibility.Collapsed;
            ExpandCharacter1.Text = char.ConvertFromUtf32(0xE011);

            AccountSettingsList.Visibility = Visibility.Collapsed;
            ExpandCharacter3.Text = char.ConvertFromUtf32(0xE011);
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeListVisibility();
            HomePageFrame.Navigate(typeof(AboutUsPage));
        }
    }
}
