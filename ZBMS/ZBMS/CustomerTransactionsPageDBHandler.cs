using DataModule;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS
{
    public class CustomerTransactionsPageDBHandler : DatabaseHandler
    {
        public int GetTransactionId()
        {
            int id = 0;

            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"select autoIncrementId from TransactionDetails ;";
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

        public int AddTransaction(TransactionDetails transaction)
        {
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = "Insert into Transactiondetails (autoIncrementID,TransactionId,SenderId,receiverid,transactiontime,amount,type,status,)" +
                 $" Values({transaction.autoIncrement},'{transaction.TransactionId}', '{transaction.SenderId}', '{transaction.ReceiverId}', '{transaction.TransactionTime}', {transaction.Amount}, '{transaction.Type}', " +
                 $"'{transaction.Status}'); ";
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

        public List<TransactionDetails> GetTransactions(string accountNumber)
        {
            List<TransactionDetails> Transactions = new List<TransactionDetails>();
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = "Select * from transactiondetails where senderid = '" + accountNumber + "' ORDER BY autoIncrementID DESC ; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    TransactionDetails transaction = new TransactionDetails();
                    transaction.TransactionId = reader.GetString(1);
                    transaction.SenderId = reader.GetString(2);
                    transaction.ReceiverId = reader.GetString(3);
                    transaction.Time = reader.GetString(4);
                    transaction.Amount = reader.GetDouble(5);
                    transaction.Type = reader.GetString(6);
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
                db.Close();
            }

        }

        public List<TransactionDetails> GetTransactions()
        {
            List<TransactionDetails> Transactions = new List<TransactionDetails>();
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = "Select * from transactiondetails ORDER BY autoIncrementID DESC  ; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();

                while (reader.Read())
                {
                    TransactionDetails transaction = new TransactionDetails();
                    transaction.TransactionId = reader.GetString(1);
                    transaction.SenderId = reader.GetString(2);
                    transaction.ReceiverId = reader.GetString(3);
                    transaction.Time = reader.GetString(4);
                    transaction.Amount = reader.GetDouble(5);
                    transaction.Type = reader.GetString(6);
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
                db.Close();
            }

        }


    }
}
