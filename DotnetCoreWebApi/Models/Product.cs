using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Description { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public decimal Rating { get; set; }

        public string? ImageURL { get; set; }
    }
}
