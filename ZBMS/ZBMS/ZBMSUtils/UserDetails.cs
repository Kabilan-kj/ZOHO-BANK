using DataModule;
using DataModule.AccountDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.ZBMSUtils
{
    public  class UserDetails
    {
        public static CustomerData Customer { get; set; }
        public static List<AccountData> UserAccounts { get; set; }
        public static List<string> UserAccountNumbers { get; set; }
    }
}
