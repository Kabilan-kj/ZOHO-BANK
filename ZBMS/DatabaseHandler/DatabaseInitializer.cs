using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataModule;
using DataModule.AccountDetails;


namespace DatabaseHandler
{
    public class DatabaseInitializer
    {
        private string connectionString = "ZBMS_DB.db";
        private SQLite.SQLiteConnection connection;

        public void GetDBConnection()
        {
           // System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB0.db");
            //System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB1.db");
            //System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB2.db");
            //System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB3.db");
            //System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB4.db");
            
            System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB6.txt");
            if (!File.Exists(connectionString))
            {
                System.Data.SQLite.SQLiteConnection.CreateFile("ZBMS_DB.db");
               // ConsoleDataInitializer consoleDataInitializer = new ConsoleDataInitializer();
                try
                {
                    connection = new SQLite.SQLiteConnection(connectionString);
                    connection.CreateTable<CustomerData>();
                    connection.CreateTable<DBAccountData>();
                    connection.CreateTable<BankData>();
                    connection.CreateTable<AccountData>();
                    connection.CreateTable<TransactionDetails>();

                    //connection.InsertAll(consoleDataInitializer.GetBankObject());
                    //connection.InsertAll(consoleDataInitializer.GetCustomerObject());
                    //List<AccountData> accounts = consoleDataInitializer.GetAccountObject();
                    //foreach (AccountData account in accounts)
                    //{
                    //    connection.Insert(UpdateAccount(account));
                    //}

                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public DBAccountData UpdateAccount(AccountData Account)
        {

            DBAccountData DBaccount = new DBAccountData();
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
                        TypeofAccount = ca.Type.ToString()

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
                        TypeofAccount = ra.Type.ToString(),
                        SourceAccountNumber = ra.SourceAccountNumber,

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
                        InterestRate = la.InterestRate,

                    };
                    return DBaccount;

            }
            return null;



        }




    }
}
