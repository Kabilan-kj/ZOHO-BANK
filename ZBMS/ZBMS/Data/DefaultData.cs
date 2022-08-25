using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.Models;

namespace ZBMS.Data
{
    public  class DefaultData
    {

        private SqliteConnection connection;
        private readonly DBAdapter dbAdapter = new DBAdapter();

        public int GetDetailedTransaction(string transactionId)
        {
          
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                string cmd = "Create Table  If Not Exists CustTable  (autoIncrementId int primary key , Name text not null, contact text,address text, mailid text,customerid text not null,profileimage text); ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, connection);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetDefaultData()
        {
            CreateCustomerDataTable();
            CreateAccountsDataTable();
            CreateBankDataTable();
            CreateTransactionsDetailsTable();
        }

        private int CreateCustomerDataTable()
        {
            return 0;
        }
        private int CreateAccountsDataTable()
        {
            return 0;
        }
        private int CreateBankDataTable()
        {
            return 0;
        }
        private int CreateTransactionsDetailsTable()
        {
            return 0;
        }



    }
}
