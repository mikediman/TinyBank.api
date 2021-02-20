using Microsoft.EntityFrameworkCore;
using TinyBank.Implementation.Database.Models;

namespace TinyBank.Implementation.Database
{
    public class TinyBankDbContext : DbContext
    {
        public TinyBankDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Nino)
                .IsUnique();

            //modelBuilder.Entity<Account>()
            //    .ToTable("Account");

            modelBuilder.Entity<Transaction>()
                .ToTable("Transaction");
        }
    }
}
