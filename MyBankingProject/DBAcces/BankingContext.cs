using Microsoft.EntityFrameworkCore;
using MyBankingProject.Models;

namespace MyBankingProject.DBAcces
{
    public class BankingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[] { new Account(-1, "200000","Salary", "123456-7890", 1000, Account.AccountTypesEnum.PrivateCustomer) });
            modelBuilder.Entity<Account>().HasData(new Account[] { new Account(2, "200001", "Savings", "123456-7890", 1000, Account.AccountTypesEnum.PrivateCustomer) });
            modelBuilder.Entity<Customer>().HasData(new Customer[] { new Customer(-1, "Karl Superrig Mappedyr", "123456-7890", "OdinVej", "Silkeborg", "MinMail@gmail.com") });
            modelBuilder.Entity<Account>().HasData(new Account[] { new Account(1, "100000", "Salary", "098765-4321", 2000,  Account.AccountTypesEnum.PrivateCustomer) });
            modelBuilder.Entity<Customer>().HasData(new Customer[] { new Customer(1, "John", "098765-4321", "ThorsVej", "Silkeborg", "DinMail@gmail.com") });
            modelBuilder.Entity<Transaction>().HasData(new Transaction[] { new Transaction(-1, 1000, "100000", SenderReciverType.Stranger, "200001", SenderReciverType.Myself, TransactionTypeEnum.Normal) });
        }
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LauritsPC\\LOCALHOST;Initial Catalog=MyBankingProject;Integrated Security=SSPI; TrustServerCertificate=true");
        }
    }
}
