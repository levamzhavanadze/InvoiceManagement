﻿using WebAPIAuth.Models.Customers;

namespace WebAPIAuth.Models.Invoices
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } 

        public string? Description { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public string Status { get; set; }

        public List<InvoiceItem> Items { get; set; }


    }
}
