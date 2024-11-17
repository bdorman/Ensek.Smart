using Ensek.Smart.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Smart.Data
{
    public class SmartDatabaseContext : DbContext
    {
        public required DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}