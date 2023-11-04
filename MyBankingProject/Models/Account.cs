

using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace MyBankingProject.Models

{
    
    public class Account
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1,6)]
        public String AccountNumber { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        [Range(10,11)]
        public string CPR { get; set; }
        [Required]
        public double Saldo { get; set; }
        [Required]
        public String AccountType { get; set; }

        public Account() { }
        public Account(int id, string accountNumber, String name, String cpr, double saldo, AccountTypesEnum accountType)
        {
            this.Id = id;
            this.AccountNumber = accountNumber;
            this.AccountName = name;
            this.CPR = cpr;
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
