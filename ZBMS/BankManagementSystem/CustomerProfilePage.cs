using System;
using System.Collections.Generic;
using System.Text;
using DataModule;
using DatabaseHandler;

namespace BankManagementSystem
{
    public class CustomerProfilePage
    {
        //private WriteFunctions display = new WriteFunctions();
        private CustomerProfilePageDBHandler dbHandler = new CustomerProfilePageDBHandler();
        CustomerData SelectedCustomer = new CustomerData();

        public void SelectFunction()
        {
           // display.PrintMessage("<----------------- Customer Profile Page --------------->");
            int choice = 0;
            do
            {
                List<string> profilePageList = new List<string>() { "* Enter 1 to View Profile", "* Enter 2 to Edit Profile", "* Enter anyother number to Go Back to Homepage " };

                choice = 1;// display.GetChoiceWithoutLoop(profilePageList);
                switch (choice)
                {
                    case 1:
                        ViewProfile();
                        break;
                    case 2:
                        SelectedCustomer = dbHandler.EditProfile(SelectedCustomer);
                        break;
                    default:
                        choice = 0;
                        break;
                }
            } while (choice != 0);
        }
        public void ViewProfile()
        {
            List<string> profileList = new List<string>() { "\n->Customer Id : " + SelectedCustomer.CustomerId, "->Name : " + SelectedCustomer.Name,
                "->Contact : " + SelectedCustomer.Contact,"->MailId : "+SelectedCustomer.MailId,"->Address : "+SelectedCustomer.Address};
            //display.PrintDetails(profileList);
        }


    }
}
