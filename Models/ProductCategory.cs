using System.ComponentModel.DataAnnotations;

namespace PepperShop.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 100 characters")]
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

    }
}
