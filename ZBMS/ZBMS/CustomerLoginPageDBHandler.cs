
using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using DataModule.AccountDetails;
using DatabaseHandler;
using System.Threading;

namespace ZBMS
{
    public class CustomerLoginPageDBHandler : DatabaseHandler
    {
        public CustomerData GetCustomer(string id)
        {

            CustomerData customer= new CustomerData();
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"select * from customerdata where customerid = '{id}' ; ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();
                while (reader.Read())
                {
                    customer.autoIncrementId = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);
                    customer.Address = reader.GetString(2);
                    customer.Contact = reader.GetString(3);
                    customer.MailId = reader.GetString(4);
                    customer.CustomerId = reader.GetString(5);
                    //customer.ProfileImage = reader.GetString(6);
                }
                
              return customer;


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

        public int GetCustomerId()
        {

            CustomerData customer = new CustomerData();
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = "select * from customerdata ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
                SqliteDataReader reader = GetRecord.ExecuteReader();


                while (reader.Read())
                {
                    customer.autoIncrementId = reader.GetInt32(0);
                   
                }

                return customer.autoIncrementId;


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

        public int AddCustomer(CustomerData NewCustomer)
        {

            CustomerData customer = new CustomerData();
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = "Insert Into Customerdata (autoincrementid,Name,Address,Contact,Mailid,CustomerID)" +
                 $" Values({NewCustomer.autoIncrementId},'{NewCustomer.Name}','{NewCustomer.Address}','{NewCustomer.Contact}','{NewCustomer.MailId}','{NewCustomer.CustomerId}');  ";
                SqliteCommand GetRecord = new SqliteCommand(cmd, db);
               
                int rows= GetRecord.ExecuteNonQuery();
               

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


        public int UpdateCustomer(CustomerData customer)
        {
            try
            {
                db = new SqliteConnection($"FileName={dbpath}");
                db.Open();
                string cmd = $"update customerdata set name='{customer.Name}',address='{customer.Address}'," +
                    $"contact='{customer.Contact}',mailid='{customer.MailId}' where customerid='{customer.CustomerId}';";
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

       

    }
}