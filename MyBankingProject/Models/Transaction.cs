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
        public String SenderType { get; set; }
        [Required]
        public string ReciverAccountNumber { get; set; }
        [Required]
        public String ReciverType { get; set; }
        [Required]
        public DateTime StartTransactionDate { get; set; }
        [Required]
        public DateTime? EndTransactionDate { get; set; }
        [Required]
        public String TransactionType { get; set; }

        public Transaction() { }

        public Transaction(double amount, string senderAccountnumber, SenderReciverType senderType, string reciverAccountNumber, SenderReciverType reciverType, TransactionTypeEnum transactionType)
        {
            Amount = amount;
            SenderAccountNumber = senderAccountnumber;
            SenderType = (senderType == SenderReciverType.Myself) ? "Myself" : "Stranger";
            ReciverAccountNumber = reciverAccountNumber;
            ReciverType = (reciverType == SenderReciverType.Myself) ? "Myself" : "Stranger";
            StartTransactionDate = DateTime.Now;
            EndTransactionDate = (transactionType == TransactionTypeEnum.Fixed) ? null : DateTime.Now.AddDays(2);
            TransactionType = (transactionType == TransactionTypeEnum.Fixed) ? "Fixed" : "Normal";  
        }

        public Transaction(int id, double amount, string senderAccountnumber, SenderReciverType senderType, string reciverAccountNumber, SenderReciverType reciverType, TransactionTypeEnum transactionType)
        {
            Id = id;
            Amount = amount;
            SenderAccountNumber = senderAccountnumber;
            SenderType = (senderType == SenderReciverType.Myself) ? "Myself" : "Stranger";
            ReciverAccountNumber = reciverAccountNumber;
            ReciverType = (reciverType == SenderReciverType.Myself) ? "Myself" : "Stranger";
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

    public enum SenderReciverType
    {
        Myself,
        Stranger
    }
}
