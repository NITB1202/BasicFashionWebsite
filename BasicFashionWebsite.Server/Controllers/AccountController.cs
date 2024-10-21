using BasicFashionWebsite.Server.Database;
using BasicFashionWebsite.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
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
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccounts()
        {
            var accounts = await _context.accounts.ToListAsync();
            return Ok(accounts);
        }

        // GET: account/find-by-id?id=1
        [HttpGet("find-by-id")]
        public async Task<ActionResult<Account>> GetAccountById([FromQuery] int id)
        {
            var account = await _context.accounts.FindAsync(id);

            if (account == null)
                return NotFound();

            return account;
        }

        //GET: account/find-by-username?username=cus1
        [HttpGet("find-by-username")]
        public async Task<ActionResult<Account>> GetAccountByUsername([FromQuery] string username)
        {
            var account = await _context.accounts.FirstOrDefaultAsync(ac => ac.username.Equals(username));
            if (account == null)
                return NotFound("Username invalid");

            return account;
        }

        //POST: account/create
        [HttpPost("create")]
        public async Task<ActionResult> CreateNewAccount([FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccountById), new { id = account.account_id }, account);
        }

        //DELETE: account/delete-by-id?id=1
        [HttpDelete("delete-by-id")]
        public async Task<ActionResult> DeleteAccountById([FromQuery] int id)
        {
            var account = await _context.accounts.FindAsync(id);

            if (account == null)
                return NotFound("Invalid account id");

            _context.accounts.Remove(account);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //DELETE: account/delete-by-username?username=us1
        [HttpDelete("delete-by-username")]
        public async Task<ActionResult> DeleteAcccountById([FromQuery] string username)
        {
            var deleteAccount = _context.accounts.FirstOrDefault(account => account.username.Equals(username));
            
            if (deleteAccount == null)
                return NotFound();
            
            _context.accounts.Remove(deleteAccount);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        //PUT: account/update-by-id?id=1
        [HttpPut("update-by-id")]
        public async Task<ActionResult<Account>> UpdateAccountById([FromQuery] int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != account.account_id)
                return BadRequest("Invalid account_id");

            var realAccount = await _context.accounts.FindAsync(id);
            
            if (realAccount == null)
                return NotFound();

            _context.Entry(realAccount).CurrentValues.SetValues(account);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
