using Invoice.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.DataAccess
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions options) : base(options) { }
        public InvoiceContext() { }
        public DbSet<Customer> Customer {get;set;}
        public DbSet<Company> Company { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
