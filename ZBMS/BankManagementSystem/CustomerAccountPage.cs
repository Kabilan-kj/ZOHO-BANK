using System;
using System.Collections.Generic;
using System.Text;
using BankManagementSystem.AccountPages;
using DataModule;
using DataModule.AccountDetails;
using DatabaseHandler;
using SQLite;

namespace BankManagementSystem
{
    public class CustomerAccountPage
    {
        //protected WriteFunctions display = new WriteFunctions();
        protected CustomerAccountPageDBHandler dbHandler = new CustomerAccountPageDBHandler();
        public static AccountData SelectedAccount;
        public CustomerData SelectedCustomer= new CustomerData();

        public void SelectAccountPageFunction()
        {

           // display.PrintMessage("<----------------- Customer Account Page --------------->");
            int choice = 0;

            SelectedAccount = null;
            do
            {
                List<string> selectAccountList = new List<string> { "* Enter 1 to Create New Account ", "* Enter 2 to Select Existing Account", "* Enter 3 to Select for Money Transfer", "* Enter anyother number to EXIT" };
                choice = 1;// display.GetChoiceWithoutLoop(selectAccountList);
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;

                    case 2:
                        SelectExistingAccount();
                        break;
                    case 3:
                        MoneyTransfer();
                        break;


                    default:
                        choice = 0;
                        break;

                }
            } while (choice != 0);


        }

        public virtual void SelectFunction()
        {
            int choice = 0;
            do
            {
                List<string> accountsPageList = new List<String>() {"* Enter 1 to View Account Balance"
                ,"* Enter 2 to View Transactions","* Enter 3 to View Account Details","* Enter 4 to Switch Account","* Enter 5 to Close Selected Account","* Enter any other Number to go Back to Home Page"};
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
                        CloseAccount(SelectedAccount);
                        break;

                    default:
                        choice = 0;
                        break;
                }

            } while (choice != 0);


        }

        public virtual void CreateAccount()
        {
            CustomerAccountPage accountPage = new CustomerAccountPage();
            List<string> accountTypeList = new List<string>() { "* Enter 1 to Create Current Account", "* Enter 2 to Create Savings Account", "* Enter 3 to Create Recurring Account", "* Enter 4 to Create Fixed Deposit Account", "* Enter 5 to Create Loan Account" };
            int accountTypeChoice = 1;// display.GetChoiceWithLoop(accountTypeList);
            accountPage = SelectAccountType(((AccountType)accountTypeChoice).ToString());
            accountPage.CreateAccount();
        }

        public void MoneyTransfer()
        {
            List<string> moneyTransferList = new List<string>() { "* Enter 1 to make Self Transactions",
                "* Enter 2 to make Transactions to Others With Same Bank",
               "* Enter 3 to make Transactions to Others With Different Bank" };
            int transferChoice = 1;// display.GetChoiceWithLoop(moneyTransferList);
            switch (transferChoice)
            {
                case 1:
                    SelfTransfer();
                    break;

                case 2:
                    OtherCustomerTransfer();
                    break;

                case 3:
                    AccountData senderAccount = dbHandler.SelectExistingAccount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and customerid ='{SelectedCustomer.CustomerId}'");
                    string receiverAccountNumber = "";// display.GetStringValue("Receiver Account Number");
                    double amount = 1;//display.GetDoubleValue("Amount to Transfer");
                    if (Withdraw(senderAccount, amount))
                    {

                        dbHandler.AddTransaction(new TransactionDetails(amount, senderAccount.AccountNumber, receiverAccountNumber,
                       TransactionType.DEBITED, TransactionStatus.SUCCESSFUL,
                       SelectedCustomer.CustomerId, senderAccount.BranchCode, dbHandler.GetTransactionId()));
                      //  display.PrintMessage("Money Transfer Successful");

                    }
                    else
                    {
                      //  display.PrintMessage("Insufficient Fund to make requested Money Transfer");
                        dbHandler.AddTransaction(new TransactionDetails(amount, senderAccount.AccountNumber, receiverAccountNumber, TransactionType.DEBITED, TransactionStatus.FAILED, SelectedCustomer.CustomerId, senderAccount.BranchCode, dbHandler.GetTransactionId()));

                    }
                    break;


            }


        }

        public void SelectExistingAccount()
        {
            CustomerAccountPage accountPage = new CustomerAccountPage();
            SelectedAccount = null;
            SelectedAccount = dbHandler.SelectExistingAccount($"Select * from AccountData  where customerid = '{SelectedCustomer.CustomerId}'");
            if (SelectedAccount == null)
            {
                //display.PrintMessage("No Accounts Available \n\n Enter 1 to Create New Account \n Enter any other number to exit");
                if (true)//display.GetIntValue("Choice") == 1)
                {
                    CreateAccount();
                    return;
                }
                //else
                //    return;
            }
            //display.PrintMessage($"You Have Selected Account -  {SelectedAccount.AccountNumber} ");
            accountPage = SelectAccountType(SelectedAccount.TypeofAccount);
            accountPage.SelectFunction();
        }
        public void ViewTransaction(AccountData account)
        {

            List<TransactionDetails> Transactions = dbHandler.GetTransactions(account.AccountNumber);

            if (Transactions != null)
            {
                foreach (TransactionDetails transaction in Transactions)
                {
                    List<string> transactionList = new List<string>() { "->Transaction Id : " + transaction.TransactionId, "->From :" + transaction.SenderId,
                        "->To :" + transaction.ReceiverId,"->Amount : "+transaction.Amount,
                        "->Transaction Time : "+transaction.TransactionTime.ToString(),"->Transaction Type : "+transaction.Type,"->Transaction Status :"+transaction.Status };
                    //display.PrintDetails(transactionList);
                }
            }
            else
            {
                //display.PrintMessage("No TransactionData Available");
            }
        }


        public void CloseAccount(AccountData account)
        {
            if (dbHandler.DeleteAccount(account))
            {
               // display.PrintMessage($"Account-{account.AccountNumber} Has been Closed Successfully !!..");
                SelectAccountPageFunction();
            }
            else
            {
               // display.PrintMessage($"Unable to close the account !!....");
            }


        }

        public virtual void ViewAccountDetails(AccountData account)
        {

            List<string> accountList = new List<string>() {"\nAccount Number : "+account.AccountNumber,"Customer Id : "+account.CustomerId,
            "Branch Code : "+account.BranchCode,"Balance :"+account.Balance,"Account Type :"+account.TypeofAccount};
            //display.PrintDetails(accountList);

        }
        public void ViewBalance(AccountData account)
        {
            //display.PrintMessage("Available Balance : " + account.Balance);

        }
        public bool Withdraw(AccountData account, double amount)
        {
            if (account.TypeofAccount == "CURRENT_ACCOUNT" || account.TypeofAccount == "SAVINGS_ACCOUNT")
            {
                if (account.Balance >= amount)
                {
                    account.Balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                //display.PrintMessage("Withdraw Failed Try Valid Account");
                return false;
            }


        }
        public void Deposit(AccountData account, double amount)
        {
            if (account.TypeofAccount == "LOAN_ACCOUNT")
            {
                account.Balance -= amount;
            }
            else
            {
                account.Balance += amount;
            }

        }
        public void OtherCustomerTransfer()
        {
            int count = dbHandler.GetCount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and customerid ='{SelectedCustomer.CustomerId}'");

            if (count > 0)
            {

                AccountData senderAccount = dbHandler.SelectExistingAccount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and customerid ='{SelectedCustomer.CustomerId}'");


                AccountData receiverAccount = dbHandler.SelectReceiverAccount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and accountnumber!='{senderAccount.AccountNumber}'");


                Withdraw(senderAccount, receiverAccount);


            }
            else
            {
                //display.PrintMessage("Self Transfer not available");
            }
        }



        public void Withdraw(AccountData senderAccount, AccountData receiverAccount)
        {
            double amount = 1;//display.GetDoubleValue("Amount to Transfer");
            bool isSuccessful = Withdraw(senderAccount, amount);
            if (isSuccessful)
            {
                Deposit(receiverAccount, amount);
                dbHandler.UpdateAccount(senderAccount);
                dbHandler.UpdateAccount(receiverAccount);
                int transactionid = dbHandler.GetTransactionId();
                dbHandler.AddTransaction(new TransactionDetails(amount, senderAccount.AccountNumber, receiverAccount.AccountNumber,
                 TransactionType.DEBITED, TransactionStatus.SUCCESSFUL,
                 SelectedCustomer.CustomerId, senderAccount.BranchCode, transactionid));
                //display.PrintMessage("Money Trasfer Successful");

            }
            else
            {
                //display.PrintMessage("Insufficient Fund to make requested Money Transfer");
                dbHandler.AddTransaction(new TransactionDetails(amount, senderAccount.AccountNumber, receiverAccount.AccountNumber, TransactionType.DEBITED, TransactionStatus.FAILED, SelectedCustomer.CustomerId, senderAccount.BranchCode, dbHandler.GetTransactionId()));

            }


        }

        public void SelfTransfer()
        {


            int count = dbHandler.GetCount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and customerid ='{SelectedCustomer.CustomerId}'");

            if (count > 1)
            {

                AccountData senderAccount = dbHandler.SelectExistingAccount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and customerid ='{SelectedCustomer.CustomerId}'");


                AccountData receiverAccount = dbHandler.SelectExistingAccount($"Select * from AccountData where (typeofAccount='SAVINGS_ACCOUNT' or typeofAccount='CURRENT_ACCOUNT') and customerid ='{SelectedCustomer.CustomerId}' and accountnumber!='{senderAccount.AccountNumber}'");


                Withdraw(senderAccount, receiverAccount);


            }
            else
            {
                //display.PrintMessage("Self Transfer not available");
            }
        }

        public CustomerAccountPage SelectAccountType(string Type)
        {
            CustomerAccountPage accountPage = new CustomerAccountPage();
            switch (Type)
            {
                case "CURRENT_ACCOUNT":
                    accountPage = new CurrentAccountPage();
                    break;
                case "SAVINGS_ACCOUNT":
                    accountPage = new SavingsAccountPage();
                    break;
                case "RECURRING_ACCOUNT":
                    accountPage = new RecurringAccountPage();
                    break;
                case "FIXED_DEPOSIT_ACCOUNT":
                    accountPage = new FixedDepositAccountPage();
                    break;
                case "LOAN_ACCOUNT":
                    accountPage = new LoanAccountPage();
                    break;
            }
            return accountPage;
        }





    }
}
