using System.ComponentModel.DataAnnotations;

namespace MyBankingProject.Models
{
    public class Transaction {

        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1, 50000)]
        public double Amount { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required]
        public string Reciver { get; set; }
        [Required]
        public DateTime StartTransactionDate { get; set; }
        [Required]
        public DateTime? EndTransactionDate { get; set; }
        [Required]
        public String TransactionType { get; set; }

        public Transaction() { }

        public Transaction(int id, double amount, string sender, string reciver, TransactionTypeEnum transactionType)
        {
            Id = id;
            Amount = amount;
            Sender = sender;
            Reciver = reciver;
            StartTransactionDate = DateTime.Now;
            EndTransactionDate = (transactionType == TransactionTypeEnum.Fixed) ? null : DateTime.Now.AddDays(2);
            TransactionType = (transactionType == TransactionTypeEnum.Fixed) ? "Fixed" : "Normal";  
        }
    }

    public enum TransactionTypeEnum
    {
        Normal,
        Fixed
    }
}
