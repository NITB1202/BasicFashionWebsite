using BasicFashionWebsite.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicFashionWebsite.Server.Database
{
    public class FashionDbContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceDetails> details { get; set; }

        public string connectionString = @"Server=localhost;Database=Fashion;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
