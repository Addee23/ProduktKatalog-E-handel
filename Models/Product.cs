using System.ComponentModel.DataAnnotations;

namespace ProduktKatalog.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(1, 1000)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
        public string? ImageUrl { get; set; }

        public int Quantity { get; set; } = 0;

    }
}
