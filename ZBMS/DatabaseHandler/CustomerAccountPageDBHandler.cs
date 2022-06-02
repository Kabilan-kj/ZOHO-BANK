using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DataModule;
using DataModule.AccountDetails;


namespace DatabaseHandler
{
    public class CustomerAccountPageDBHandler
    {
       // WriteFunctions display = new WriteFunctions();
        private string connectionString = "ZBMS_Database.db";
        private SQLiteConnection connection;

        public void AddTransaction(TransactionDetails transaction)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Insert(transaction);
            }
            catch (Exception ex)
            {
                //display.PrintMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteAccount(AccountData account)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Delete<DBAccountData>((GetDBAccount(account)).AccountNumber);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
            finally
            {
                connection.Close();
            }
        }
        public int GetTransactionId()
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var transactions = connection.Query<TransactionDetails>("Select * from transactiondetails");
                return transactions[transactions.Count - 1].autoIncrement + 1;
            }
            catch (Exception)
            {
                return 0;
            }
            finally { connection.Close(); }

        }

        public int GetAccountId(string accountType)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var accounts = connection.Query<DBAccountData>($"Select * from AccountData where typeofaccount='{accountType}'");
                return accounts[accounts.Count - 1].autoIncrementId;
            }
            catch (Exception)
            {
                return 0;
            }
            finally { connection.Close(); }

        }





        public List<TransactionDetails> GetTransactions(string accountNumber)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var Transactions = connection.Query<TransactionDetails>("select * from transactiondetails where senderid = '" + accountNumber + "' or receiverid = '" + accountNumber + "';");
                return Transactions;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }


        }



        public string CreateAccount(AccountData Account)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                DBAccountData accountData = new DBAccountData();
                accountData = GetDBAccount(Account);
                connection.Insert(accountData);
                return accountData.AccountNumber;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }
        public AccountData SelectExistingAccount(string query)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var userAccounts = connection.Query<DBAccountData>(query);
                //if (userAccounts.Count() >= 1)
                    while (true)
                    {
                        for (int i = 0; i < userAccounts.Count; i++)
                        {
                           // display.PrintMessage("Enter " + (i + 1) + " to Select " + userAccounts[i].TypeofAccount + " - " + userAccounts[i].AccountNumber);
                        }
                    int choice = 1; //display.GetIntValue("Account Number Choice");
                        if (choice > 0 && choice <= userAccounts.Count)
                        {
                            return getAccount(userAccounts[choice - 1]);
                        }
                       // display.PrintMessage("Invalid AccountNumber TryAgain");

                    }
               // else
                    //return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }


        }

        public string GetBranchCode()
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var branches = connection.Query<BankData>("Select * from BankData");
                while (true)
                {
                    for (int i = 0; i < branches.Count; i++)
                    {
                        //display.PrintMessage("Enter " + (i + 1) + " to Select " + branches[i].BranchName + " Branch - " + branches[i].BranchCode);
                    }
                    int choice = 1;// display.GetIntValue("Branch Code Choice");
                    if (choice > 0 && choice <= branches.Count)
                    {
                        return branches[choice - 1].BranchCode;
                    }
                    //display.PrintMessage("Invalid Choice TryAgain");

                }

            }
            catch (Exception)
            {
                //display.PrintMessage("No Bank Data Available !!..");
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public AccountData SelectReceiverAccount(string query)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var Accounts = connection.Query<DBAccountData>(query);
                while (true)
                {
                    string accountNumber = "";// display.GetStringValue("Account Number :");
                    foreach (DBAccountData account in Accounts)
                    {
                        if (account.AccountNumber == accountNumber)
                        {
                            return getAccount(account);
                        }
                    }


                    //display.PrintMessage("Invalid AccountNumber TryAgain");

                }

            }
            catch (Exception)
            {
                //display.PrintMessage("No Account Data Available !!..\nTry Creating New Accounts");
            }
            finally
            {
                connection.Close();
            }

            return null;
        }


        public int GetCount(string query)
        {
            try
            {
                connection = new SQLiteConnection(connectionString);
                var userAccounts = connection.Query<DBAccountData>(query);
                return userAccounts.Count;
            }
            catch (Exception)
            {
                return 0;
            }
            finally { connection.Close(); }
        }

        public AccountData getAccount(DBAccountData Account)
        {
            switch (Account.TypeofAccount)
            {
                case "CURRENT_ACCOUNT":
                    CurrentAccountData currentAccount = new CurrentAccountData();
                    currentAccount.autoIncrementId = Account.autoIncrementId;
                    currentAccount.AccountNumber = Account.AccountNumber;
                    currentAccount.TypeofAccount = Account.TypeofAccount;
                    currentAccount.CustomerId = Account.CustomerId;
                    currentAccount.BranchCode = Account.BranchCode;
                    currentAccount.Balance = Account.Balance;
                    currentAccount.MinimumBalance = Account.MinimumBalance;
                    return currentAccount;

                case "SAVINGS_ACCOUNT":
                    SavingsAccountData savingsAccount = new SavingsAccountData();
                    savingsAccount.autoIncrementId = Account.autoIncrementId;
                    savingsAccount.AccountNumber = Account.AccountNumber;
                    savingsAccount.TypeofAccount = Account.TypeofAccount;
                    savingsAccount.BranchCode = Account.BranchCode;
                    savingsAccount.CustomerId = Account.CustomerId;
                    savingsAccount.Balance = Account.Balance;
                    savingsAccount.MinimumBalance = Account.MinimumBalance;
                    savingsAccount.InterestRate = Account.InterestRate;
                    return savingsAccount;

                case "RECURRING_ACCOUNT":
                    RecurringAccountData recurringAccount = new RecurringAccountData();
                    recurringAccount.autoIncrementId = Account.autoIncrementId;
                    recurringAccount.AccountNumber = Account.AccountNumber;
                    recurringAccount.TypeofAccount = Account.TypeofAccount;
                    recurringAccount.CustomerId = Account.CustomerId;
                    recurringAccount.BranchCode = Account.BranchCode;
                    recurringAccount.Balance = Account.Balance;
                    recurringAccount.MinimumBalance = Account.MinimumBalance;
                    recurringAccount.InterestRate = Account.InterestRate;
                    recurringAccount.Tenure = Account.Tenure;
                    recurringAccount.SourceAccountNumber = Account.SourceAccountNumber;
                    recurringAccount.IsTriggered = Account.IsTriggered;
                    return recurringAccount;


                case "FIXED_DEPOSIT_ACCOUNT":
                    FixedDepositAccountData fixedDepositAccount = new FixedDepositAccountData();
                    fixedDepositAccount.autoIncrementId = Account.autoIncrementId;
                    fixedDepositAccount.AccountNumber = Account.AccountNumber;
                    fixedDepositAccount.TypeofAccount = Account.TypeofAccount;
                    fixedDepositAccount.BranchCode = Account.BranchCode;
                    fixedDepositAccount.CustomerId = Account.CustomerId;
                    fixedDepositAccount.Balance = Account.Balance;
                    fixedDepositAccount.MinimumBalance = Account.MinimumBalance;
                    fixedDepositAccount.InterestRate = Account.InterestRate;
                    fixedDepositAccount.Tenure = Account.Tenure;

                    return fixedDepositAccount;

                case "LOAN_ACCOUNT":
                    LoanAccountData loanAccount = new LoanAccountData();
                    loanAccount.autoIncrementId = Account.autoIncrementId;
                    loanAccount.AccountNumber = Account.AccountNumber;
                    loanAccount.TypeofAccount = Account.TypeofAccount;
                    loanAccount.BranchCode = Account.BranchCode;
                    loanAccount.CustomerId = Account.CustomerId;
                    loanAccount.Balance = Account.Balance;
                    loanAccount.MinimumBalance = Account.MinimumBalance;
                    loanAccount.InterestRate = Account.InterestRate;
                    loanAccount.Tenure = Account.Tenure;
                    loanAccount.PrincipalAmount = Account.PrincipalAmount;

                    return loanAccount;

            }

            return null;


        }

        public DBAccountData GetDBAccount(AccountData Account)
        {
            DBAccountData DBaccount;
            switch (Account.TypeofAccount)
            {
                case "CURRENT_ACCOUNT":
                    CurrentAccountData ca = (CurrentAccountData)Account;
                    DBaccount = new DBAccountData()
                    {
                        autoIncrementId = ca.autoIncrementId,
                        AccountNumber = ca.AccountNumber,
                        CustomerId = ca.CustomerId,
                        BranchCode = ca.BranchCode,
                        Balance = ca.Balance,
                        MinimumBalance = ca.MinimumBalance,
                        TypeofAccount = ca.TypeofAccount

                    };
                    return DBaccount;
                case "SAVINGS_ACCOUNT":
                    SavingsAccountData sa = (SavingsAccountData)Account;
                    DBaccount = new DBAccountData()
                    {
                        autoIncrementId = sa.autoIncrementId,
                        AccountNumber = sa.AccountNumber,
                        CustomerId = sa.CustomerId,
                        BranchCode = sa.BranchCode,
                        Balance = sa.Balance,
                        MinimumBalance = sa.MinimumBalance,
                        TypeofAccount = sa.TypeofAccount,
                        InterestRate = sa.InterestRate



                    };
                    return DBaccount;

                case "RECURRING_ACCOUNT":
                    RecurringAccountData ra = (RecurringAccountData)Account;
                    DBaccount = new DBAccountData()
                    {
                        autoIncrementId = ra.autoIncrementId,
                        AccountNumber = ra.AccountNumber,
                        CustomerId = ra.CustomerId,
                        BranchCode = ra.BranchCode,
                        Balance = ra.Balance,
                        MinimumBalance = ra.MinimumBalance,
                        TypeofAccount = ra.TypeofAccount,
                        SourceAccountNumber = ra.SourceAccountNumber,
                        IsTriggered = ra.IsTriggered,


                    };
                    return DBaccount;
                case "FIXED_DEPOSIT_ACCOUNT":
                    FixedDepositAccountData fa = (FixedDepositAccountData)Account;
                    DBaccount = new DBAccountData()
                    {
                        autoIncrementId = fa.autoIncrementId,
                        AccountNumber = fa.AccountNumber,
                        CustomerId = fa.CustomerId,
                        BranchCode = fa.BranchCode,
                        Balance = fa.Balance,
                        MinimumBalance = fa.MinimumBalance,
                        TypeofAccount = fa.Type.ToString()



                    };
                    return DBaccount;
                case "LOAN_ACCOUNT":
                    LoanAccountData la = (LoanAccountData)Account;
                    DBaccount = new DBAccountData()
                    {
                        autoIncrementId = la.autoIncrementId,
                        AccountNumber = la.AccountNumber,
                        CustomerId = la.CustomerId,
                        BranchCode = la.BranchCode,
                        Balance = la.Balance,
                        PrincipalAmount = la.PrincipalAmount,
                        MinimumBalance = la.MinimumBalance,
                        TypeofAccount = la.Type.ToString(),
                        Tenure = la.Tenure,
                        MonthsCompleted = la.MonthsCompleted,
                        InterestRate = la.InterestRate,


                    };
                    return DBaccount;

            }
            return null;
        }

        public void UpdateAccount(AccountData Account)
        {

            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Update(GetDBAccount(Account));
            }
            catch (Exception ex)
            {
               // display.PrintMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }


    }
}
