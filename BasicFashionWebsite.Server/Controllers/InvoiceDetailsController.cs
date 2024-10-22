using BasicFashionWebsite.Server.Database;
using BasicFashionWebsite.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicFashionWebsite.Server.Controllers
{
    [Route("Details")]
    public class InvoiceDetailsController : Controller
    {
        private readonly FashionDbContext db;
        public InvoiceDetailsController(FashionDbContext db)
        {
            this.db = db;
        }

        //GET: details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetails>>> GetAllInvoiceDetails()
        {
            var details = await db.details.ToListAsync();
            return details;
        }

        //GET: details/find-details?ivoiceid=1
        [HttpGet("find-details")]
        public async Task<ActionResult<IEnumerable<InvoiceDetails>>> GetDetailsByInvoiceId([FromQuery]int invoiceId)
        {
            var details = await db.details
                        .Where(d => d.invoice_id == invoiceId)
                        .ToListAsync();

            if (!details.Any())
                return NotFound();

            return Ok(details);
        }

        //POST: details/create
        [HttpPost("create")]
        public async Task<ActionResult<InvoiceDetails>> CreateNewInvoiceDetails([FromBody] InvoiceDetails details)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.details.Add(details);
            await db.SaveChangesAsync();
            return Ok(details);
        }
    }
}
