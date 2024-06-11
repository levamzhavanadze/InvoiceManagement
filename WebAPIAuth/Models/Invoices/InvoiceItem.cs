using WebAPIAuth.Models.Invoices;


namespace WebAPIAuth.Models.Invoices
{
    public class InvoiceItem
    {

        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        public int InvoiceId { get; set; }

        public string Item {  get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }  

        public decimal Amount {  get; set; }


    }
}
