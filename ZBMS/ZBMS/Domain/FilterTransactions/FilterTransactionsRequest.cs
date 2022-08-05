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

        public FilterTransactionsRequest(string _startdate,string _endate,string _customerid)
        {
            StartDate = _startdate;
            EndDate = _endate;
            CustomerId = _customerid;
        }
    }
}
