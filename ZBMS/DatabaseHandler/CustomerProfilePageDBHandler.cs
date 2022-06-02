using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DataModule;

namespace DatabaseHandler
{
    public class CustomerProfilePageDBHandler
    {
      ///  private WriteFunctions display = new WriteFunctions();
        private string connectionString = "ZBMS_Database.db";
        private SQLiteConnection connection;

        public CustomerData EditProfile(CustomerData SelectedCustomer)
        {
            // display.PrintMessage($"Existing Name : {SelectedCustomer.Name}");
            string name = "";// display.GetStringValue("Name");
            if (name != "")
            {
                SelectedCustomer.Name = name;
            }

            // display.PrintMessage($"Existing Contact : {SelectedCustomer.Contact}");
            string contact = ""; //display.GetStringValue("Contact");
            if (contact != "")
            {
                SelectedCustomer.Contact = contact;
            }

            // display.PrintMessage($"Existing MailId : {SelectedCustomer.MailId}");
            string mailId = "";// display.GetStringValue("Mail Id");
            if (mailId != "")
            {
                SelectedCustomer.MailId = mailId;
            }

            // display.PrintMessage($"Existing Address : {SelectedCustomer.Address}");
            string address = "";// display.GetStringValue("Address");
            if (address != "")
            {
                SelectedCustomer.Address = address;
            }
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Update(SelectedCustomer);
                //display.PrintMessage("Profile has been Updated Successfully !!...\n");
                return SelectedCustomer;
            }
            catch (Exception )
            {
               // display.PrintMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return null;

        }


    }
}
