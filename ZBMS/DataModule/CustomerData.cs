using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DataModule
{
    [Table("CustomerData")]
    public class CustomerData
    {
        [PrimaryKey, AutoIncrement]
        public int CustomerCount { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string MailId { get; set; }
        public string ProfileImage { get; set; }

        public string CustomerId { get; set; }

        public CustomerData(string name, string address, string contact, string mailId, int count)
        {

            CustomerCount = count;
           
            CustomerId = "UID" + (100 + ++CustomerCount);
            Name = name;
            Address = address;
            Contact = contact;
            MailId = mailId;
        }
        public CustomerData()
        {

        }


    }
}
