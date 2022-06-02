using System;
using System.Collections.Generic;
using System.Text;
using DatabaseHandler;
using DataModule.AccountDetails;

namespace BankManagementSystem.AccountPages
{
    public class CurrentAccountPage : CustomerAccountPage
    {
        public  void CreateAccount(DBAccountData dbAccount)
        {
            //while (true)
            //{
            //    string Pancard = display.GetStringValue("PAN Card Number");
            //    if (Pancard != null)
            //        break;
            //    display.PrintMessage("Invalid PAN Card Number Try Again");
            //}
            //string branchCode = dbHandler.GetBranchCode();
            //double amount = display.GetDoubleValue("Initial Amount");

            //string accountNumber = dbHandler.CreateAccount(new CurrentAccountData(dbHandler.GetAccountId("CURRENT_ACCOUNT"), SelectedCustomer.CustomerId, branchCode, amount));
            //if (accountNumber != null)
            //    display.PrintMessage($"Current Account Has been Created Successfully !!..\n Account Number : {accountNumber}\n");
            //else
            //    display.PrintMessage("Account Creation Failed !!..\n");
        }

    }
}
