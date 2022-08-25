using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.FilterTransactionsUseCase.DomainLayer
{
    public class FilterTransactionsRequest
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CustomerId { get; set; }

        public FilterTransactionsRequest(string startdate,string endate,string customerid)
        {
            StartDate = startdate;
            EndDate = endate;
            CustomerId = customerid;
        }
    }
}
