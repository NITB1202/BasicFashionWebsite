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

        [MaxLength(100)]
        public required string image_link { get; set; }

        [Required]
        [MaxLength(100)]
        public required string name { get; set; }

        [MaxLength(200)]
        public required string description { get; set; }

        [Range(0, int.MaxValue)]
        public int stock_quantity { get; set; } = 0;

        [Required]
        [Range(0,int.MaxValue)]
        public int cost { get; set; }
    }
}
