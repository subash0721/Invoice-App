using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Models
{
    public class CompanyRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
    }

    public class CompanyResponse {
        public List<CompanyInvoice> companyInvoice { get; set; }
    }

    public class CompanyInvoice {
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public double TotallAmount { get; set; }
    }
}
