using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Models;

namespace ZBMS.FilterTransactionsUseCase.DomainLayer
{
    public class FilterTransactionsResponse
    {
        public List<ExtendedTransactionDetails> transactions { get; set; }
    }
}
