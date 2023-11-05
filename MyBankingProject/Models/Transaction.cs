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
        public string SenderAccountNumber { get; set; }
        [Required]
        public string ReciverAccountNumber { get; set; }
        [Required]
        public DateTime StartTransactionDate { get; set; }
        [Required]
        public DateTime? EndTransactionDate { get; set; }
        [Required]
        public String TransactionType { get; set; }

        public Transaction() { }

        public Transaction(int id, double amount, string senderAccountnumber, string reciverAccountNumber, TransactionTypeEnum transactionType)
        {
            Id = id;
            Amount = amount;
            SenderAccountNumber = senderAccountnumber;
            ReciverAccountNumber = reciverAccountNumber;
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
