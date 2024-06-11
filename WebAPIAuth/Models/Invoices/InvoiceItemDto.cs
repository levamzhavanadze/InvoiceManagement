using WebAPIAuth.Models.Invoices;


namespace WebAPIAuth.Models.Invoices
{
    public class InvoiceItemDto
    {
        public Invoice invoiceId { get; set; }

        public string item { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public decimal amount { get; set; }


    }
}
