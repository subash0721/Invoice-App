using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Models
{
    public class CompanyRequest
    {
        public string CompanyName { get; set; }
        public Address Address { get; set; }
    }
}
