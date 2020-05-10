using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.DataAccess.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int CompanyId { get; set; }
        public string Date { get; set; }
        public int CustomerId { get; set; }
        public List<OrderDetails> Products { get; set; } = new List<OrderDetails>();

    }
}
