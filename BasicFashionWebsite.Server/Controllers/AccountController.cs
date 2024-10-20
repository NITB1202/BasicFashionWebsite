using BasicFashionWebsite.Server.Database;
using BasicFashionWebsite.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicFashionWebsite.Server.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {   
        private readonly FashionDbContext _context;

        public AccountController(FashionDbContext context)
        {
            _context = context;
        }

        // GET: Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await _context.accounts.ToListAsync();
            return Ok(accounts);
        }
    }
}
