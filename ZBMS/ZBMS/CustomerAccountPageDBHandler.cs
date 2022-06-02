using DatabaseHandler;
using DataModule;
using DataModule.AccountDetails;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ZBMS
{
    public  class CustomerAccountPageDBHandler : DatabaseHandler
    {
   

        public int CreateAccount(AccountData account)
        {
            DBAccountData dbaccount = GetDBAccount(account);  
            try
            {

                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = "Insert into Accountdata (autoincrementid,AccountNumber,CustomerId,branchcode,balance,typeofaccount,minimumbalance," +
                    "interestrate,SourceAccountNumber,Tenure,MonthsCompleted,PrincipalAmount,Istriggered)"+
                  $"Values({dbaccount.autoIncrementId},'{dbaccount.AccountNumber}','{dbaccount.CustomerId}','{dbaccount.BranchCode}',{dbaccount.Balance}," +
                  $"'{dbaccount.TypeofAccount}',{dbaccount.MinimumBalance},{dbaccount.InterestRate},'{dbaccount.SourceAccountNumber}',{dbaccount.Tenure}," +
                  $"{dbaccount.MonthsCompleted},{dbaccount.PrincipalAmount},{dbaccount.IsTriggered})";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);

                int rows = GetRecord.ExecuteNonQuery();


                return rows;

            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                db.Close();
            }
        }

        public int GetAccountId(string type)
        {

            int id = 0 ;
            
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"select * from AccountData Where typeofaccount = '{type}' ;";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();


                while (reader.Read())
                {
                    id = reader.GetInt32(0);

                }

                return id;


            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                db.Close();
            }


        }

        public List<string> GetBranchCode()
        {

            List<string> branchCode = new List<string>();     

            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"Select branchcode from Bankdata  ;";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();


                while (reader.Read())
                {
                     branchCode.Add( reader.GetString(0));

                }

                return branchCode;


            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }


        }
       
        public int UpdateAccount(AccountData account)
        {
            try
            {
                db = new SqliteConnection($"Filename={dbpath}");
                db.Open();
                string command = $"Update AccountData set balance={account.Balance} where accountNumber='{account.AccountNumber}'";
                SqliteCommand GetRecord = new SqliteCommand(command, db);
                int rows= GetRecord.ExecuteNonQuery();
                return rows;
            }
            catch(Exception)
            {
                return 0;
            }
            finally
            { 
                db.Close();
            }
        }

        public int UpdateLoanAccount(AccountData account)
        {
            LoanAccountData loanAccount = (LoanAccountData)account;
            try
            {
                db = new SqliteConnection($"Filename={dbpath}");
                db.Open();
                string command = $"Update AccountData set balance={loanAccount.Balance},monthscompleted={loanAccount.MonthsCompleted} where accountNumber='{loanAccount.AccountNumber}'";
                SqliteCommand GetRecord = new SqliteCommand(command, db);
                int rows = GetRecord.ExecuteNonQuery();
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                db.Close();
            }
        }
        public int UpdateAutomaticTrigger(RecurringAccountData account)
        {
            int istriggered = 0;
            if (account.IsTriggered == true)
                 istriggered = 1;

            try
            {
                db = new SqliteConnection($"Filename={dbpath}");
                db.Open();
                string command = $"Update AccountData set Istriggered={istriggered} where accountNumber='{account.AccountNumber}'";
                SqliteCommand GetRecord = new SqliteCommand(command, db);
                int rows = GetRecord.ExecuteNonQuery();
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                db.Close();
            }
        }

        public List<AccountData> GetUserAccounts(string id)
        {
            List<DBAccountData> DBaccounts = new List<DBAccountData>();
            List<AccountData> UserAccounts = new List<AccountData>();

            using (SqliteConnection db = new SqliteConnection($"FileName={dbpath}"))
            {

                db.Open();
                string cmd = "select * from accountdata where customerid = '" + id + "' ; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    DBAccountData account = new DBAccountData();
                    account.autoIncrementId = reader.GetInt32(0);
                    account.AccountNumber = reader.GetString(1);
                    account.CustomerId = reader.GetString(2);
                    account.BranchCode = reader.GetString(3);
                    account.Balance = reader.GetDouble(4);
                    account.TypeofAccount = reader.GetString(5);
                    account.MinimumBalance = reader.GetInt32(6);
                    account.InterestRate = reader.GetInt32(7);
                    if (!reader.IsDBNull(8))
                    {
                        account.SourceAccountNumber = reader.GetString(8);
                    }
                    account.Tenure=reader.GetInt32(9);
                    account.MonthsCompleted = reader.GetInt32(10);
                    account.PrincipalAmount = reader.GetDouble(11);
                    account.IsTriggered = reader.GetBoolean(12);

                    DBaccounts.Add(account);

                }

                db.Close();
                foreach (DBAccountData dbaccount in DBaccounts)
                {
                    UserAccounts.Add(getAccount(dbaccount));
                }
                return UserAccounts;


            }

        }

        public List<AccountData> GetUserLoanAccounts(string id)
        {

           
            List<AccountData> UserAccounts = new List<AccountData>();

            using (SqliteConnection db = new SqliteConnection($"FileName={dbpath}"))
            {

                db.Open();
                string cmd = "select * from accountdata where customerid = '" + id + "' and TypeOfAccount='LOAN_ACCOUNT' ; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    LoanAccountData account = new LoanAccountData();
                    account.autoIncrementId = reader.GetInt32(0);
                    account.AccountNumber = reader.GetString(1);
                    account.CustomerId = reader.GetString(2);
                    account.BranchCode = reader.GetString(3);
                    account.Balance = reader.GetDouble(4);
                    account.TypeofAccount = reader.GetString(5);
                    account.InterestRate = reader.GetDouble(7);
                    account.Tenure = reader.GetInt32(9);
                    account.MonthsCompleted = reader.GetInt32(10);
                    account.PrincipalAmount = reader.GetDouble(11);
                   
                    UserAccounts.Add(account);

                }

                db.Close();
                return UserAccounts;

            }

        }

        public List<AccountData> GetSavingsAccount(string id)
        {

            List<AccountData> accounts = new List<AccountData>();

            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"Select AccountNumber,Balance from Accountdata  where typeofaccount='SAVINGS_ACCOUNT' and customerid='{id}' ;";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();


                while (reader.Read())
                {
                    accounts.Add(new AccountData { AccountNumber= reader.GetString(0) ,Balance= reader.GetDouble(1) });

                }

                return accounts;


            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }


        }

        public List<AccountData> GetUserPaymentAccounts(string id)
        {

            List<AccountData> accounts = new List<AccountData>();

            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"Select AccountNumber,Balance from Accountdata  where   customerid='{id}' and (typeofaccount='SAVINGS_ACCOUNT' or typeofaccount='CURRENT_ACCOUNT')  ;";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    accounts.Add(new AccountData { AccountNumber = reader.GetString(0), Balance = reader.GetDouble(1) });

                }

                return accounts;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }


        }

        public string GetAddress(string branchcode)
        {
            string branchAddress = null;
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"Select * from BankData  where Branchcode='{branchcode}';";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();
                while (reader.Read())
                {
                   branchAddress = reader.GetString(3); 

                }

                return branchAddress;


            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }
        }

        public List<AccountData> GetAllPaymentAccounts()
        {

            List<AccountData> accounts = new List<AccountData>();

            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"Select AccountNumber,Balance from Accountdata  where (typeofaccount='SAVINGS_ACCOUNT' or typeofaccount='CURRENT_ACCOUNT') ;";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();
                while (reader.Read())
                {
                    accounts.Add(new AccountData { AccountNumber = reader.GetString(0), Balance = reader.GetDouble(1) });

                }

                return accounts;


            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }


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



    }
}
