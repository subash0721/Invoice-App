﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Streat { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
