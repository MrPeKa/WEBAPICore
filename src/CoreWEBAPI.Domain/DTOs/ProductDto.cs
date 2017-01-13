using System.ComponentModel.DataAnnotations;

namespace CoreWEBAPI.Domain.DTOs
{
    public class ProductDto : BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Prize { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}