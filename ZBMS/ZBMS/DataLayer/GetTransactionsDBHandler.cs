using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ZBMS.DataLayer
{
    public class GetTransactionsDBHandler
    {
        private SqliteConnection connection;
        private DBAdapter dbAdapter= new DBAdapter();

        public List<TransactionDetails> GetTransactions(string accountNumber)
        {
            List<TransactionDetails> Transactions = new List<TransactionDetails>();
            try
            {
                connection = dbAdapter.GetConnection();
                connection.Open();
                string cmd = "Select * from transactiondetails where senderid = '" + accountNumber + "' ORDER BY autoIncrementID DESC ; ";
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
                    //transaction.Type = reader.GetString(6);
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
