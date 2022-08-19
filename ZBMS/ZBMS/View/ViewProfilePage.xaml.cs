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
using DataModule;
using Windows.UI.Xaml.Media.Imaging;
using ZBMS.ZBMSUtils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewProfilePage : Page
    {
        CustomerData customer= new CustomerData();  
        public ViewProfilePage()
        {
            this.InitializeComponent();
            GetCustomerData();
        }
        private void GetCustomerData()
        {
            customer = UserDetails.Customer;
            NameTextBox.Text = customer.Name;
            AddressTextBox.Text = customer.Address;
            ContactTextBox.Text = customer.Contact;
            MailIdTextBox.Text = customer.MailId;
           // ProfileImage.Source = new BitmapImage(new Uri(customer.ProfileImage, UriKind.RelativeOrAbsolute)); 

        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EventsUtilsClass.InvokePageChanged(MenuOptions.EditProfile);
            this.Frame.Navigate(typeof(EditProfilePage));
        }
    }
}
