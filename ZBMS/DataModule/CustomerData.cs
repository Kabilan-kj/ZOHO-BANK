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
        public int autoIncrementId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string MailId { get; set; }
        public string ProfileImage { get; set; }

        public string CustomerId { get; set; }

        public CustomerData(string _name, string _address, string _contact, string _mailId, int _autoIncrementId)
        {

            autoIncrementId = _autoIncrementId;
            CustomerId = "UID" + (100 + ++autoIncrementId);
            Name = _name;
            Address = _address;
            Contact = _contact;
            MailId = _mailId;
        }
        public CustomerData()
        {

        }


    }
}
