using System.ComponentModel.DataAnnotations;

namespace CoreWEBAPI.Domain.DTOs
{
    public class CompanyDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
    }
}