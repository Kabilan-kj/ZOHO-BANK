using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DataModule;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditProfilePage : Page
    {
        private CustomerData customer;
        private CustomerLoginPage customerLogin= new CustomerLoginPage();
        private bool IsTextModified=false;
        public EditProfilePage()
        {
            this.InitializeComponent();
            GetCustomerData();

        }

        public void GetCustomerData()
        {
            customer = MainPage.GetCustomerData();
            NameTextBox.Text = customer.Name;
            AddressTextBox.Text = customer.Address;
            ContactTextBox.Text = customer.Contact;
            MailIdTextBox.Text = customer.MailId;
        }


        private async void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if ( IsTextModified && NameTextBox.Text != "" && ContactTextBox.Text != "" && MailIdTextBox.Text != "" && AddressTextBox.Text != "")
            {
                MessageDialog showDialog = new MessageDialog("Do you want discard the changes");
                showDialog.Commands.Add(new UICommand("Yes") { Id = 0 });
                showDialog.Commands.Add(new UICommand("No") { Id = 1 });

                showDialog.DefaultCommandIndex = 0;
                showDialog.CancelCommandIndex = 1;
                var results = await showDialog.ShowAsync();
                if ((int)results.Id == 0)
                {
                    ViewProfilePageFrame.Navigate(typeof(CustomerDashboard));
                }
            }
            else
            {
                ViewProfilePageFrame.Navigate(typeof(CustomerDashboard));
            }
        
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            MessageDialog showDialog = new MessageDialog("Do you want Save the Changes");
            showDialog.Commands.Add(new UICommand("Save") { Id = 0 });
            showDialog.Commands.Add(new UICommand("Cancel") { Id=1});
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var results= await showDialog.ShowAsync();
            if((int)results.Id==0){

                if(NameTextBox.Text!="")
                {
                    customer.Name = NameTextBox.Text;   
                }
                if (ContactTextBox.Text != "")
                {
                    customer.Contact = ContactTextBox.Text; 
                }
                if (MailIdTextBox.Text != "")
                {
                    customer.MailId = MailIdTextBox.Text;   
                }
                if (AddressTextBox.Text != "")
                {
                    customer.Address = AddressTextBox.Text;
                }
                if(await customerLogin.UpdateCustomerData(customer)==0)
                {
                    ProfileEditingFailed();
                }
                else
                {
                    ProfileEdited();
                }
               
            }

        }

        private  void ProfileEdited()
        {
            //MessageDialog showDialog = new MessageDialog("Profile Updated Successfully");
            //showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
           
            //showDialog.DefaultCommandIndex = 0;
            //showDialog.CancelCommandIndex = 1;
            //var results = await showDialog.ShowAsync();
            //if ((int)results.Id == 0)
            //{
                ViewProfilePageFrame.Navigate(typeof(CustomerDashboard));
          //  }
        }
        private  void ProfileEditingFailed()
        {
            //MessageDialog showDialog = new MessageDialog("Unable to Update Values");
            //showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
         
            //showDialog.DefaultCommandIndex = 0;
            
            //var results = await showDialog.ShowAsync();
            //if ((int)results.Id == 0)
            //{
                this.Frame.Navigate(typeof(EditProfilePage));
            //}
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsTextModified = true;
            ButtonPanel.Visibility = Visibility.Visible;
            
        }
    }
}
