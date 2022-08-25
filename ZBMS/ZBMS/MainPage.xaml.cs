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

using System.Threading.Tasks;
using DataModule;
using Windows.UI.Popups;
using System.Threading;
using ZBMS.ZBMSUtils;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CustomerLoginPage LoginPage = new CustomerLoginPage();
        private CustomerData customer = new CustomerData();

        public MainPage()
        {
             this.InitializeComponent();
            // LoginAction("UID107");
            //SamplePageTesting("UID107");

        }

        private void SamplePageTesting(string id)
        {
            customer = null;
            customer = LoginPage.GetCustomer(id);
            UserDetails.Customer=customer;
            MainFrame.Navigate(typeof(MenuPage));
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
           MainFrame.Navigate(typeof(SignUpPage));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserIdTextBox.Text !="")
            {
                customer = null;
                customer = LoginPage.GetCustomer(UserIdTextBox.Text);
                if (customer==null || customer.Name==null)
                {
                    ErrorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    ErrorMessage.Text = "Invalid UserID";
                }
                else 
                {
                    UserDetails.Customer = customer;
                     MainFrame.Navigate(typeof(MenuPage));
                  //  Login(customer.Name);
                }
              
            }
            else
            {
                ErrorMessage.Foreground = new SolidColorBrush(Colors.Red);
                ErrorMessage.Text = "UserId must not be empty";
            }
        }

        public void LoginAction(string id)
        {
            customer = null;
            customer = LoginPage.GetCustomer(id);
            MainFrame.Navigate(typeof(MainFramePage));

        }

        public  void Login( string UserName)
        {
            MainFrame.Navigate(typeof(MenuPage));
          
        }
       

    }
}
