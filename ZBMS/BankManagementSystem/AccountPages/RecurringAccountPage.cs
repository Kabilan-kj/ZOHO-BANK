using System;
using System.Collections.Generic;
using System.Text;
using DataModule.AccountDetails;

namespace BankManagementSystem.AccountPages
{
    public class RecurringAccountPage : CustomerAccountPage
    {

        public override void SelectFunction()
        {
            int choice = 0;
            do
            {
                List<string> accountsPageList = new List<String>() {"* Enter 1 to View Account Balance"
                ,"* Enter 2 to View Transactions","* Enter 3 to View Account Details","* Enter 4 to Switch Account","*Enter 5 to Trigger Make Automatic Payment from Source Account","* Enter 6 to Close Selected Account","* Enter any other Number to go Back to Home Page"};
                choice = 1; //display.GetChoiceWithoutLoop(accountsPageList);
                switch (choice)
                {
                    case 1:
                        ViewBalance(SelectedAccount);
                        break;
                    case 2:
                        ViewTransaction(SelectedAccount);
                        break;

                    case 3:
                        ViewAccountDetails(SelectedAccount);
                        break;

                    case 4:
                        SelectExistingAccount();
                        break;

                    case 5:
                        TriggerAutomaticPayment(SelectedAccount);
                        break;
                    case 6:
                        CloseAccount(SelectedAccount);
                        break;

                    default:
                        choice = 0;
                        break;

                }

            } while (choice != 0);


        }
        public override void CreateAccount()
        {
            while (true)
            {
                string Pancard = "";// display.GetStringValue("PAN Card Number");
                if (Pancard != null)
                    break;
                //display.PrintMessage("Invalid PAN Card Number Try Again");
            }
            string branchCode = dbHandler.GetBranchCode();
            double amount = 1;// display.GetDoubleValue("Initial Amount");
            AccountData SourceAccount = dbHandler.SelectExistingAccount($"Select * from AccountData where typeofAccount='SAVINGS_ACCOUNT' and customerid ='{SelectedCustomer.CustomerId}'");
            //if (SourceAccount == null)
            //{
            //    display.PrintMessage("No Savings Account Available \n\n Enter 1 to Create New Savings Account \n Enter any other number to exit");
            //    if (display.GetIntValue("Choice") == 1)
            //    {
                    SavingsAccountPage savingsAccountPage = new SavingsAccountPage();
                    savingsAccountPage.CreateAccount();
                    return;
            //    }
            //    else

            //        return;

            //}

            string accountNumber = dbHandler.CreateAccount(new RecurringAccountData(dbHandler.GetAccountId("RECURRING_ACCOUNT"), SelectedCustomer.CustomerId, branchCode, SourceAccount.AccountNumber, amount));
            if (accountNumber != null)
            { }
                //display.PrintMessage($"Current Account Has been Created Successfully !!..\n Account Number : {accountNumber}\n");
            else
            { }
                //display.PrintMessage("Account Creation Failed !!..\n");
        }

        public void TriggerAutomaticPayment(AccountData account)
        {
            RecurringAccountData recurringAccount = (RecurringAccountData)account;
            //if (recurringAccount.IsTriggered)
            //{
            //    display.PrintMessage("Automatic Payment is Selected \n\n Enter 0 to Cancel Automatic Payment \nEnter any other number to EXIT ");
            //    if (display.GetIntValue("Choice") == 0)
            //    {
                    recurringAccount.IsTriggered = false;
                    dbHandler.UpdateAccount(recurringAccount);
            //        display.PrintMessage("Automatic Payment is Cancelled");
            //    }

            //}
            //else
            //{
                //display.PrintMessage("Automatic Payment is Not Selected \n\n Enter 1 to Select Automatic Payment \n Enter any other number to EXIT ");
                //if (display.GetIntValue("Choice") == 1)
                //{
                    recurringAccount.IsTriggered = true;
                    dbHandler.UpdateAccount(recurringAccount);
            //        display.PrintMessage("Automatic Payment is Selected");
            //    }

            //}

        }
        public override void ViewAccountDetails(AccountData Account)
        {
            RecurringAccountData account = (RecurringAccountData)Account;
            List<string> accountList = new List<string>() {"\nAccount Number : "+account.AccountNumber,"Customer Id : "+account.CustomerId,
            "Branch Code : "+account.BranchCode,"Balance :"+account.Balance,"Account Type :"+account.TypeofAccount,"Automatic Payment Triggered:"+account.IsTriggered};
            //display.PrintDetails(accountList);

        }



    }
}
