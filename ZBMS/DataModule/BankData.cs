using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DataModule
{
    [Table("BankData")]
    public class BankData
    {
        public int autoIncrementId { get; set; }
        public string BranchName { get; set; }
        [PrimaryKey]
        public string BranchCode { get; set; }
        public string BranchAddress { get; set; }
        public string ManagerName { get; set; }

        public BankData(int _id, string _name, string _address, string _managerName)
        {
            autoIncrementId = _id;
            BranchCode = "ZB00" + ++autoIncrementId;
            BranchName = _name;
            BranchAddress = _address;
            ManagerName = _managerName;

        }

        public BankData()
        {

        }

    }
}
