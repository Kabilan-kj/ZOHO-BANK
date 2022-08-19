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

        public ExtendedTransactionDetails GetDetailedTransaction(string transactionId)
        {
            ExtendedTransactionDetails transaction = new ExtendedTransactionDetails();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                string cmd = $"Select s.transactiontime,s.senderid,c.name,s.receiverid,d.name,s.amount,s.transactionid,c.customerid,d.customerid from transactiondetails s join AccountData a on a.accountnumber = s.senderid join customerdata c on  a.accountnumber = s.senderid and a.customerid = c.customerid join AccountData a1 on a1.accountnumber = s.receiverid join customerdata d on  a1.accountnumber = s.receiverid and a1.customerid = d.customerid where s.transactionid = '{transactionId}'; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, connection);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                   transaction.Time= reader.GetString(0);
                   transaction.SenderAccountNumber = reader.GetString(1);
                   transaction.SenderName= reader.GetString(2);
                   transaction.ReceiverAccountNumber = reader.GetString(3);
                   transaction.ReceiverName= reader.GetString(4);
                   transaction.Amount=reader.GetDouble(5);
                   transaction.TransactionId= reader.GetString(6); 
                    transaction.SenderId= reader.GetString(7);
                    transaction.ReceiverId= reader.GetString(8);
                   
                }

                if (transaction.TransactionId == null)
                {
                    transaction = GetDetailedTransactionOfOtherBankCustomer(transactionId);
                }
                return transaction;

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

        private ExtendedTransactionDetails GetDetailedTransactionOfOtherBankCustomer(string transactionId)
        {
            ExtendedTransactionDetails transaction = new ExtendedTransactionDetails();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                string cmd = $"Select s.transactiontime,s.senderid,c.name,s.receiverid,s.amount,s.transactionid from transactiondetails s join AccountData a on a.accountnumber = s.senderid join customerdata c on  a.customerid = c.customerid  where s.transactionid = '{transactionId}'; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, connection);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    transaction.Time = reader.GetString(0);
                    transaction.SenderAccountNumber = reader.GetString(1);
                    transaction.SenderName = reader.GetString(2);
                    transaction.ReceiverAccountNumber = reader.GetString(3);
                    transaction.Amount = reader.GetDouble(4);
                    transaction.TransactionId = reader.GetString(5);

                }

                return transaction;

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


        public List<ExtendedTransactionDetails> GetTransactionsByCustomerID(string id)
        {
            List<ExtendedTransactionDetails> Transactions = new List<ExtendedTransactionDetails>();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                string cmd = $"Select * from transactiondetails s  join AccountData a on a.accountnumber = s.senderid  join customerdata c on  a.accountnumber = s.senderid  and a.customerid = c.customerid  join AccountData a1 on a1.accountnumber = s.receiverid  join customerdata d on  a1.accountnumber = s.receiverid  and a1.customerid = d.customerid  where d.customerid = '{id}' or c.customerid='{id}'  ORDER BY s.autoIncrementID DESC ;  ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, connection);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    ExtendedTransactionDetails transaction = new ExtendedTransactionDetails();
                    transaction.TransactionId = reader.GetString(1);
                    transaction.SenderAccountNumber = reader.GetString(2);
                    transaction.ReceiverAccountNumber = reader.GetString(3);
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
                    transaction.SenderAccountNumber = reader.GetString(2);
                    transaction.ReceiverAccountNumber = reader.GetString(3);
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

        public List<ExtendedTransactionDetails> GetFilteredTransactions(string customerid ,string startDate,string endDate)
        {
            List<ExtendedTransactionDetails> Transactions = new List<ExtendedTransactionDetails>();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
               // string cmd = $"Select * from transactiondetails Where  ";

                string cmd = $" Select s.transactionid,s.senderid , s.receiverid ,s.transactiontime,s.amount from transactiondetails s join AccountData a on a.accountnumber = s.senderid join customerdata c on  a.accountnumber = s.senderid and a.customerid = c.customerid where c.customerid = '{customerid}' and transactiontime between '{endDate}' and '{startDate}'   ORDER BY s.autoIncrementID DESC ; ";


                SqliteCommand GetRecord = new SqliteCommand(cmd, connection);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    ExtendedTransactionDetails transaction = new ExtendedTransactionDetails();
                    transaction.TransactionId = reader.GetString(0);
                    transaction.SenderAccountNumber = reader.GetString(1);
                    transaction.ReceiverAccountNumber = reader.GetString(2);
                    transaction.Time = reader.GetString(3);
                    transaction.Amount = reader.GetDouble(4);
                    

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
