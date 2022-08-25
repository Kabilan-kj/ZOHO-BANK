using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Models;

namespace ZBMS.DomainLayer
{
    public class GetTransactionsResponse
    {
        public List<ExtendedTransactionDetails> Transactions { get; set; }
    }
}
