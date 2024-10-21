using BasicFashionWebsite.Server.Database;
using BasicFashionWebsite.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicFashionWebsite.Server.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly FashionDbContext db;

        public ProductController(FashionDbContext db)
        {
            this.db = db;
        }

        //GET: product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await db.products.ToListAsync();
            return products;
        }

        //GET: product/find-by-id?id=1
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductByName([FromQuery] int id)
        {
            var product = await db.products.FindAsync(id);
            if(product == null)
                return NotFound("Can't find product.");
            return Ok(product);
        }

        //POST: product/create
        [HttpPost("create")]
        public async Task<ActionResult> CreateNewProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product can't be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.products.Add(product);
            await db.SaveChangesAsync();
            return Ok();
        }

        //PUT: product/update-by-id?id=1
        [HttpPut("update-by-id")]
        public async Task<ActionResult> UpdateProductById([FromQuery] int id, [FromBody] Product updatedProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product  = await db.products.FindAsync(id);

            if (product == null)
                return NotFound();

            db.Entry(product).CurrentValues.SetValues(updatedProduct);
            await db.SaveChangesAsync();
            return Ok();
        }

        //DELETE: product/delete-by-id?id=1
        [HttpDelete("delete-by-id")]
        public async Task<ActionResult> DeleteProductById([FromQuery]int id)
        {
            var product = await db.products.FindAsync(id);

            if (product == null)
                return NotFound();

            db.products.Remove(product);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
