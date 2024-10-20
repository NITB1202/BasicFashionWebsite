using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFashionWebsite.Server.Models
{
    [Table("InvoiceDetails")]
    public class InvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int details_id { get; set; }

        [Required]
        [ForeignKey("Invoice")]
        public int invoice_id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int product_id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int quantity { get; set; } = 0;

        public required Invoice Invoice { get; set; }
        public required Product Product { get; set; }
    }
}
