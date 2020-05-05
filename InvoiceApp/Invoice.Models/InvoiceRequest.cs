using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Models
{
    public class InvoiceRequest
    {
        public int InvoiceId { get; set; }
        public int CompanyID { get; set; }
        public string InvoiceDate { get; set; }
        public Customer CustomerDetails { get; set; }
        public List<Product> ProductDetails{ get; set; }
        public int MyProperty { get; set; }
    }

    public class Customer {
        public string CustomerName { get; set; }
        public Address ShippingDetails { get; set; }
    }

    public class Product {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
