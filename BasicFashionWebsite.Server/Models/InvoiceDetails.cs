using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFashionWebsite.Server.Models
{
    [Table("InvoiceDetails")]
    public class InvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int details_id;

        [Required]
        [ForeignKey("Invoice")]
        public int invoice_id;

        [Required]
        [ForeignKey("Product")]
        public int product_id;

        [Required]
        [Range(1, int.MaxValue)]
        public int quantity = 0;

        public required Invoice Invoice { get; set; }
        public required Product Product { get; set; }
    }
}
