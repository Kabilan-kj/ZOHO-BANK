using System;
using System.Collections.Generic;
using System.Text;
using DataModule;
using DataModule.AccountDetails;

namespace BankManagementSystem.AccountPages
{
    public class LoanAccountPage : CustomerAccountPage
    {
        public override void SelectFunction()
        {
            int choice = 0;
            do
            {
                List<string> accountsPageList = new List<String>() {"* Enter 1 to View Balance Payment to be paid "
                ,"* Enter 2 to View Transactions","* Enter 3 to View Account Details","* Enter 4 to Switch Account","*Enter 5 to Make Loan Payment","* Enter 6 to Close Selected Account","* Enter any other Number to go Back to Home Page"};
                choice = 1;//display.GetChoiceWithoutLoop(accountsPageList);
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
                        //LoanPayment(SelectedAccount);
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
        public override void ViewAccountDetails(AccountData Account)
        {
            LoanAccountData account = (LoanAccountData)Account;
            List<string> accountList = new List<string>() {"\nAccount Number : "+account.AccountNumber,"Customer Id : "+account.CustomerId,
            "Branch Code : "+account.BranchCode,"Balance :"+account.Balance,"Number of Months Loan Paid:"+account.MonthsCompleted,"Account Type :"+account.TypeofAccount};
            //display.PrintDetails(accountList);

        }

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
            double amount;// = display.GetDoubleValue("Loan Amount");
            int tenure;// = display.GetIntValue("Tenure in Months");

            string accountNumber ="";//= dbHandler.CreateAccount(new LoanAccountData(dbHandler.GetAccountId("LOAN_ACCOUNT"), SelectedCustomer.CustomerId, branchCode, amount, tenure));
            if (accountNumber != null) { }
            //display.PrintMessage($"Current Account Has been Created Successfully !!..\n Account Number : {accountNumber}\n");
            else { }
                //display.PrintMessage("Account Creation Failed !!..\n");


        }
        //public void LoanPayment(AccountData account)
        //{
        //    LoanAccountData loanAccount = (LoanAccountData)account;
        //    List<String> accountsPageList = new List<String>() { "Enter 1 to Make Full Payment", "Enter 2 to Make Partial Payment", "Enter any other number to EXIT " };
        //    switch (1)//display.GetChoiceWithoutLoop(accountsPageList))
        //    {

        //        case 1:
        //            //display.PrintMessage($"Loan Amount to be paid {loanAccount.PrincipalAmount}");
        //            //display.PrintMessage("Enter 1 to Make Payment \n Enter any other number to EXIT ");
        //            //if (display.GetIntValue("Choice") == 1)
        //            //{
        //            string senderAccountNumber;//= display.GetStringValue("Sender Account Number");
        //                Deposit(loanAccount, loanAccount.Balance);
        //                dbHandler.UpdateAccount(loanAccount);
        //                dbHandler.AddTransaction(new TransactionDetails(loanAccount.Balance, senderAccountNumber, loanAccount.AccountNumber,
        //                TransactionType.DEBITED, TransactionStatus.SUCCESSFUL,
        //                loanAccount.CustomerId, loanAccount.BranchCode, dbHandler.GetTransactionId()));
        //                loanAccount.MonthsCompleted = loanAccount.Tenure;
        //                //display.PrintMessage("Loan Payment Successful");

        //            //}
        //            //else
        //            //{
        //            //    display.PrintMessage("Loan Payment Failed");
        //            //}

        //            break;

        //        case 2:
        //            //if (loanAccount.MonthsCompleted <= loanAccount.Tenure)
        //            //{
        //            //    display.PrintMessage($"Loan Amount to be paid {loanAccount.Balance / loanAccount.Tenure}");
        //            //    display.PrintMessage("Enter 1 to Make Payment \n Enter any other number to EXIT ");
        //            //    if (display.GetIntValue("Choice") == 1)
        //            //    {
        //                    /string senderAccountNumber = display.GetStringValue("Sender Account Number");
        //                    Deposit(loanAccount, loanAccount.Balance / loanAccount.Tenure);
        //                    dbHandler.AddTransaction(new TransactionDetails(loanAccount.Balance / loanAccount.Tenure, senderAccountNumber, loanAccount.AccountNumber,
        //                    TransactionType.DEBITED, TransactionStatus.SUCCESSFUL,
        //                    loanAccount.CustomerId, loanAccount.BranchCode, dbHandler.GetTransactionId()));
        //                    display.PrintMessage("Loan Payment Successful");
        //                    loanAccount.MonthsCompleted++;
        //                    dbHandler.UpdateAccount(loanAccount);

        //                }
        //                else
        //                {
        //                    display.PrintMessage("Loan Payment Failed");
        //                }
        //            }
        //            break;

        //        default:
        //            return;
        //    }

        //}

    }
}
