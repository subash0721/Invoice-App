using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.DataAccess.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProuductId { get; set; }
        public int Quantity { get; set; }
    }
}
