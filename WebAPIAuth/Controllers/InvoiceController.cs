using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Models.Customers;
using WebAPIAuth.Models.Invoices;

namespace WebAPIAuth.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoice _invoice;

        public InvoiceController(IInvoice invoice)
        {

            _invoice = invoice;
        }



        [HttpPost("Invoice"), Authorize(Roles = "Admin")]
        public ActionResult<Customer> AddInvoice(InvoiceDto request)
        {
            Invoice invoice = new Invoice();

            invoice.Description = request.Description;
            invoice.CustomerId = request.CustomerId;
            invoice.Status = "Open";
            invoice.CreatedAt = DateTime.Now;
            invoice.Items = request.Items;

            _invoice.AddInvoice(invoice);

            return Ok(invoice);

        }
    }
}