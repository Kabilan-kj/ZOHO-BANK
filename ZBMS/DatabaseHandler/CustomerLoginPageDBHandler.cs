using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DataModule;


namespace DatabaseHandler
{
    public class CustomerLoginPageDBHandler
    {
      //  WriteFunctions display = new WriteFunctions();
        private string connectionString = @"C:\Users\kabilan-13333\Desktop\ZBMS\ZBMS_Database.db";
        // string DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "ZBMS_Database.db");

       // string sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
        private SQLiteConnection connection;

        public CustomerData VerifySignIn(string id)
        {
            try
            {
              
                connection = new SQLiteConnection(connectionString);
                var customer = connection.Query<CustomerData>("select * from customerdata where customerid = '" + id + "' ");
                if (customer != null)
                {
                    return customer[0];
                }

            }
            catch (Exception)
            {
                
                return null;
            }
            finally
            {
                //connection.Close();
            }

            return null;

        }

        public void SignUp()
        {
            string name = "";
            string contact = "";
            string mailId = "";
            string address = "";

            while (true)
            {
                name = "1";//display.GetStringValue("Name ");
                if (name == "")
                {

                    //display.PrintMessage("Name Cannot be Empty");
                    continue;
                }
                break;
            }
            while (true)
            {
                contact = "";//display.GetStringValue("Contact");
                if (contact == "")
                {

                    //display.PrintMessage("Contact Cannot be Empty");
                    continue;
                }
                break;
            }
            //mailId = display.GetStringValue("Mail Id");
            //address = display.GetStringValue("Address");

            //display.PrintMessage("Enter any number to Create a new Customer \nEnter 0 to exit new customer creation");
            int choice = 1;//display.GetIntValue("Choice");
            if (choice == 0)
                return;

            try
            {
                connection = new SQLiteConnection(connectionString);
                var customers = connection.Query<CustomerData>("Select * from CustomerData");
                connection.Insert(new CustomerData(name, address, contact, mailId, customers[customers.Count - 1].autoIncrementId + 1));
                customers = connection.Query<CustomerData>("Select * from CustomerData");
                //display.PrintMessage($"\nNew Customer {customers[customers.Count - 1].Name} is Added Successfully !!.. \n Your Customer ID is {customers[customers.Count - 1].CustomerId} ");
            }
            catch (Exception )
            {
                //display.PrintMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
