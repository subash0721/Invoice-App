using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public double price { get; set; }
        public string Name { get; set; }
    }
}
