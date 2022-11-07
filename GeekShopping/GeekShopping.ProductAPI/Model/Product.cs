using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.ProductAPI.Model.Base;

namespace GeekShopping.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("Price")]
        [Required]
        [Range(10,10000)]
        public decimal Price{ get; set; }

        [StringLength(300)]
        [Column("description")]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string ImageURL { get; set; }


    }
}
