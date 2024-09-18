using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCMoneyTransfer.Models
{
    public class TransactionDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        public virtual ApplicationUser? Sender { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string ReceiverFirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Middle Name")]
        public string? ReceiverMiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string ReceiverLastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Address")]
        public string ReceiverAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Country")]
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
