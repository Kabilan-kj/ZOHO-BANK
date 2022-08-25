using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DataModule
{
    public class BankData
    {
        public int BranchCount { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string BranchAddress { get; set; }
        public string ManagerName { get; set; }

        public BankData(int id, string name, string address, string managerName)
        {
            BranchCount = id;
            BranchCode = "ZB00" + ++BranchCount;
            BranchName = name;
            BranchAddress = address;
            ManagerName = managerName;
        }

        public BankData()
        {

        }

    }
}
