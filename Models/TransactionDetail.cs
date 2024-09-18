using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCMoneyTransfer.Models
{
    public class TransactionDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        [Display(Name = "Sender First Name")]
        public string SenderFirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Sender Middle Name")]
        public string? SenderMiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Sender Last Name")]
        public  string SenderLastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Sender Address")]
        public string SenderAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Sender Country")]
        public string SenderCountry { get; set; } = "Malaysia";


        [Required]
        [MaxLength(50)]
        [Display(Name = "Receiver First Name")]
        public string ReceiverFirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Receiver Middle Name")]
        public string? ReceiverMiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Receiver Last Name")]
        public string ReceiverLastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Receiver Address")]
        public string ReceiverAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Receiver Country")]
        public string ReceiverCountry { get; set; } = "Nepal";

        [Required]
        [MaxLength(100)]
        [Display(Name = "Bank Name")]

        public string BankName { get; set; }

        [Required]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Transfer Amount (MYR)")]
        [Range(1, Double.MaxValue, ErrorMessage = "Transfer Amount must be above 1")]
        public decimal TransferAmountMYR { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        [Display(Name = "Exchange Rate")]
        public decimal ExchangeRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Payout Amount (NPR)")]
        public decimal PayoutAmountNPR { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
