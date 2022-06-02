﻿using System;
using System.Collections.Generic;
using System.Text;
using DataModule.AccountDetails;

namespace BankManagementSystem.AccountPages
{
    public class SavingsAccountPage : CustomerAccountPage
    {
        public override void CreateAccount()
        {
            while (true)
            {
                string Pancard = "";//display.GetStringValue("PAN Card Number");
                if (Pancard != null)
                    break;
                //display.PrintMessage("Invalid PAN Card Number Try Again");
            }
            string branchCode = dbHandler.GetBranchCode();
            double amount = 1;//display.GetDoubleValue("Initial Amount");

            string accountNumber = dbHandler.CreateAccount(new SavingsAccountData(dbHandler.GetAccountId("SAVINGS_ACCOUNT"), SelectedCustomer.CustomerId, branchCode, amount));
            if (accountNumber != null)
            { }
                //display.PrintMessage($"Current Account Has been Created Successfully !!..\n Account Number : {accountNumber}\n");
            else
            { }
                //display.PrintMessage("Account Creation Failed !!..\n");
        }
    }
}
