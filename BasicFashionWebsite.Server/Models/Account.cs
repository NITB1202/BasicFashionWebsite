using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFashionWebsite.Server.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int account_id { get; set; }

        [Required]
        [StringLength(100)]
        public required string username { get; set; }

        [Required]
        [StringLength(100)]
        public required string password { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^(admin|customer)$")]
        public required string role { get; set; }
    }
}
