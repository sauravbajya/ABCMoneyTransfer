using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.Models
{
    public class ApplicationUser :  IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; }
    }
}
