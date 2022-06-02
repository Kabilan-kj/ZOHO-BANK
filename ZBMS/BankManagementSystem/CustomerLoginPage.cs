using System;
using System.Collections.Generic;
using System.Text;
using DataModule;
using DatabaseHandler;

namespace BankManagementSystem
{
    public class CustomerLoginPage
    {
       // WriteFunctions display = new WriteFunctions();
        CustomerLoginPageDBHandler dbHandler = new CustomerLoginPageDBHandler();
        public CustomerData SelectedCustomer = new CustomerData();

        //public void CustomerHomePageLogin()
        //{
        //   // display.PrintMessage("\n<----------------- Customer Login Page --------------->");
        //    int choice = 0;
        //    do
        //    {
        //        List<string> loginList = new List<string> { "* Enter 1 to SignIn", "* Enter 2 to SignUp", "* Enter anyother number to Exit" };
        //        choice = display.GetChoiceWithoutLoop(loginList);
        //        switch (choice)
        //        {
        //            case 1:
        //               // SignIn();
        //                if (SelectedCustomer == null)
        //                {
        //                    display.PrintMessage("Sign Cancelled !!..\n");
        //                    break;
        //                }
        //                display.PrintMessage($"Login Successful !!..\nWelcome {SelectedCustomer.Name}\n");
        //                SelectHomePageFunction();
        //                break;

        //            case 2:
        //                dbHandler.SignUp();
        //                break;

        //            default:
        //                choice = 0;
        //                break;

        //        }
        //    } while (choice != 0);
        //}

        public string SignIn(string id)
        {
            SelectedCustomer = null;
            //while (true)
            //{
            // string id = display.GetStringValue("User Id");

            //if (id == "")
            //{
            //    return "User ID Cannot Be Empty";
            //}
            SelectedCustomer = dbHandler.VerifySignIn(id);
            if (SelectedCustomer != null)
            {
                return "done";
            }

            return "Invalid User";

        }
       



        //void SelectHomePageFunction()
        //{
        //    display.PrintMessage("<----------------- Customer Home Page --------------->");
        //    int choice = 0;
        //    do
        //    {

        //        List<string> selectFunctionList = new List<string>() { "* Enter 1 to Select Customer Profile Page", "* Enter 2 to Select Customer Accounts Page", "* Enter anyother Number to SignOut" };


        //        choice = display.GetChoiceWithoutLoop(selectFunctionList);
        //        switch (choice)
        //        {
        //            case 1:
        //                CustomerProfilePage profilePage = new CustomerProfilePage();
        //                profilePage.SelectFunction();
        //                break;

        //            case 2:
        //                CustomerAccountPage accountPage = new CustomerAccountPage();
        //                accountPage.SelectAccountPageFunction();
        //                break;


        //            default:
        //                choice = 0;
        //                break;

        //        }
        //    } while (choice != 0);
        //}
    }
}
