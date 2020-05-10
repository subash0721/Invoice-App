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
}
