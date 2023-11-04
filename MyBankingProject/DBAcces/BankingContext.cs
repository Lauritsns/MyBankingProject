using Microsoft.EntityFrameworkCore;
using MyBankingProject.Models;

namespace MyBankingProject.DBAcces
{
    public class BankingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[] { new Account(-1, "200000", 1000, Account.AccountTypesEnum.PrivateCustomer) });
            modelBuilder.Entity<Customer>().HasData(new Customer[] { new Customer(-1, "Karl", "1234567890", "OdinVej", "Silkeborg", "MinMail@gmail.com") });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LauritsPC\\LOCALHOST;Initial Catalog=MyBankingProject;Integrated Security=SSPI; TrustServerCertificate=true");
        }
    }
}
