using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.DomainLayer
{
    public class GetTransactionsResponse
    {
        public List<TransactionDetails> transactions { get; set; }
    }
}
