using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InvoiceViewModel
    {
        public int PId { get; set; }
        public string formattedDate { get; set; }
        public string formattedTime { get; set; }
        public string toUser { get; set; }
        public string typeOfBooking { get; set; }
        public string courtName { get; set; }
        public decimal amount { get; set; }
        public int? Quantity { get; set; }
    }
}
