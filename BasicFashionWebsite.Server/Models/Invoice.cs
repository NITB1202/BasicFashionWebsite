using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFashionWebsite.Server.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int invoice_id { get; set; }

        [Required]
        public DateTime order_date { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey("Account")]
        public int account_id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int total { get; set; }

        public virtual required Account Account { get; set; }
    }
}
