using WebAPIAuth.Models.Customers;

namespace WebAPIAuth.Models.Invoices
{
    public class InvoiceDto
    {

        public string? Description { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public string status { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }
}
