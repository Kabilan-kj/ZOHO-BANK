using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace ZBMS.Models
{
    public class ExtendedTransactionDetails : TransactionDetails
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string TypeImage { get; set; }

        public string AmountString { get; set; }

        public string ModifiedTime { get; set; }

        public string SenderName { get; set; }

        public string ReceiverName { get; set; }    

        public string Remarks { get; set; } 

        public string ModifiedDate { get; set; }    

        private DateTime DateTimeData { get; set; }  

        public string IconString { get; set; }

        public SolidColorBrush IconColor { get; set; }

    }
}
