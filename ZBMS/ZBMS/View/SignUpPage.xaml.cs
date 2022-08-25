using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using Windows.UI.Xaml.Navigation;
using DataModule;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {

        private CustomerLoginPage loginPage = new CustomerLoginPage();

        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text != "")
            {
                if(ContactTextBox.Text !="")
                {
                    CustomerData NewCustomer = new CustomerData() { Name=NameTextBox.Text,Address=AddressTextBox.Text,Contact=ContactTextBox.Text,MailId=MailIdTextBox.Text};
                    NewCustomer= await loginPage.SignUp(NewCustomer);
                    if(NewCustomer!=null)
                    SignUp(NewCustomer);

                    else
                    {
                        SignUpFailed();
                    }

                }
                else
                {
                    ContactTextBox.Text = "";
                    ErrorMessage.Text = "Contact Cannot Be Empty";

                }

            }
            else
            {
                NameTextBox.Text = "";
                ErrorMessage.Text = "Name Cannot Be Empty";
            }

        }
        private async void SignUp(CustomerData Customer)
        {
            MessageDialog showDialog = new MessageDialog($"Hello {Customer.Name} your have registered succesfully !! \n Your Customer ID is {Customer.CustomerId} ");
            showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            showDialog.DefaultCommandIndex = 0;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                SignUpFrame.Navigate(typeof(MainPage));
            }
        }

        private void LoginHB_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(MainPage));

        }

        private async void SignUpFailed()
        {
            MessageDialog showDialog = new MessageDialog(" Unable to Perform SignUp ");
            showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            showDialog.DefaultCommandIndex = 0;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                SignUpFrame.Navigate(typeof(SignUpPage));
                
            }
        }
    }
}
