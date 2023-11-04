

using System.ComponentModel.DataAnnotations;

namespace MyBankingProject.Models

{
    
    public class Account
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1,6)]
        public String AccountNumber { get; set; }

        public double Saldo { get; set; }
        [Required]
        public String AccountType { get; set; }

        public Account() { }
        public Account(int id, string accountNumber, double saldo, AccountTypesEnum accountType)
        {
            this.Id = id;
            this.AccountNumber = accountNumber;
            this.Saldo = saldo;
            AccountType = (accountType == AccountTypesEnum.BusinessCustomer) ? "BusinessCustomer" : "PrivateCustomer";
        }

        public enum AccountTypesEnum
        {
            PrivateCustomer,
            BusinessCustomer,
        }
    }
}
