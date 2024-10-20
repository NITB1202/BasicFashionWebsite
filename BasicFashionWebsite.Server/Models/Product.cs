using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFashionWebsite.Server.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_id { get; set; }

        [StringLength(100)]
        public string? image_link { get; set; }

        [Required]
        [StringLength(100)]
        public required string name { get; set; }

        [StringLength(200)]
        public required string description { get; set; }

        [Range(0, int.MaxValue)]
        public int stock_quantity { get; set; } = 0;

        [Required]
        [Range(1,int.MaxValue)]
        public int? cost { get; set; }
    }
}
