using System.ComponentModel.DataAnnotations;

namespace PepperShop.Models
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string? Description { get; set; }
    }
}
