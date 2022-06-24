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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZBMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutUsPage : Page
    {
        public AboutUsPage()
        {
            this.InitializeComponent();
            AboutUsWebView.Source = new Uri("ms-appx-web:///Webpages/AboutUsPage.html");
            
        }

        private void AboutUsWebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            PopUp(e.Value);
        }

        private async void PopUp(string name )
        {
            MessageDialog showDialog = new MessageDialog($"Thank you {name} for reaching out us");
            showDialog.Commands.Add(new UICommand("Okay") { Id = 0 });
            showDialog.Commands.Add(new UICommand("Cancel") { Id = 1 });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            IEnumerable<string> resultmessage;

            if ((int)result.Id == 0)
            {
                resultmessage = new string[] { "Enquiry Added Successfully"};
            }
            else
            {
                resultmessage = new string[] { "Enquiry request was cancelled" };
            }
            await AboutUsWebView.InvokeScriptAsync("updateresult", resultmessage);
         
        }



    }
}
