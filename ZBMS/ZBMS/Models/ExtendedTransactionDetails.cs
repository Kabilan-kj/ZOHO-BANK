using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.Models
{
    public class ExtendedTransactionDetails : TransactionDetails
    {

        public string TypeImage { get; set; }
        public string AmountString { get; set; }

    }
}
