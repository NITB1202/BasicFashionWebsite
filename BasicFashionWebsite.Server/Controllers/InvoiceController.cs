using BasicFashionWebsite.Server.Database;
using BasicFashionWebsite.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicFashionWebsite.Server.Controllers
{
    [Route("Invoice")]
    public class InvoiceController : Controller
    {
        private readonly FashionDbContext db;
        public InvoiceController(FashionDbContext context)
        {
            db = context;
        }

        //GET: invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoice()
        {
            var invoices = await db.invoices.ToListAsync();
            return invoices;
        }

        //GET: invoice/find-by-id?id=1
        [HttpGet("find-by-id")]
        public async Task<ActionResult<Invoice>> GetInvoiceById([FromQuery]int id)
        {
            var invoice = await db.invoices.FindAsync(id);

            if (invoice == null)
                return NotFound();

            return invoice;
        }

        //POST: invoice/create
        [HttpPost("create")]
        public async Task<ActionResult<Invoice>> CreateNewInvoice([FromBody] Invoice invoice)
        {
            if (invoice == null)
                return BadRequest("Product can't be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.invoices.Add(invoice);
            await db.SaveChangesAsync();
            return Ok(invoice);
        }
    }
}
