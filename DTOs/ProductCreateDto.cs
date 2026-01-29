using System.ComponentModel.DataAnnotations;

namespace Estudo.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }

    }
}
