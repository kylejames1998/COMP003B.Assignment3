using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }
    }
}
