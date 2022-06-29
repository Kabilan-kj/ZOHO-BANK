using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using ZBMS.Models;

namespace ZBMS.DataLayer
{
    public class GetTransactionsDBHandler
    {
        private SqliteConnection connection;
        private DBAdapter dbAdapter= new DBAdapter();

        public List<TransactionDetails> GetTransactionsByCustomerID(string id)
        {
            List<TransactionDetails> Transactions = new List<TransactionDetails>();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                string cmd = "Select * from transactiondetails  ORDER BY autoIncrementID DESC ; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, connection);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    TransactionDetails transaction = new TransactionDetails();
                    transaction.TransactionId = reader.GetString(1);
                    transaction.SenderId = reader.GetString(2);
                    transaction.ReceiverId = reader.GetString(3);
                    transaction.Time = reader.GetString(4);
                    transaction.Amount = reader.GetDouble(5);
                    transaction.Status = reader.GetString(7);

                    Transactions.Add(transaction);

                }

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


        public List<ExtendedTransactionDetails> GetTransactionsBySenderID(string accountNumber)
        {
            List<ExtendedTransactionDetails> Transactions = new List<ExtendedTransactionDetails>();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                //  string cmd = $"Select * from transactiondetails where senderid = '{accountNumber}' OR receiverid= '{accountNumber}'  ORDER BY autoIncrementID DESC ; ";
                //  SqliteCommand SQLiteCommand = new SqliteCommand(cmd,connection);

                SqliteCommand SQLiteCommand = new SqliteCommand();
                SQLiteCommand.Connection = connection;
                SQLiteCommand.CommandText = "Select * from transactiondetails where senderid = $accountnumber OR receiverid= $accountnumber  ORDER BY autoIncrementID DESC ; ";
                SQLiteCommand.Parameters.AddWithValue("$accountnumber", accountNumber);
               
                SqliteDataReader reader = SQLiteCommand.ExecuteReader();

                while (reader.Read())
                {
                    ExtendedTransactionDetails transaction = new ExtendedTransactionDetails();
                    transaction.TransactionId = reader.GetString(1);
                    transaction.SenderId = reader.GetString(2);
                    transaction.ReceiverId = reader.GetString(3);
                    transaction.Time = reader.GetString(4);
                    transaction.Amount = reader.GetDouble(5);
                    transaction.Status = reader.GetString(7);
                    Transactions.Add(transaction);

                }

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




    }
}
