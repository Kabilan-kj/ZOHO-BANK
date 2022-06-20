using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.DomainLayer
{
    public class GetTransactionsRequest
    {
        public string Id { get; set; }
        public GetTransactionsRequest(string id)
        {
            Id = id;
        }

    }
}
