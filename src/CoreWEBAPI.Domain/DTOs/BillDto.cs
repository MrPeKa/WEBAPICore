using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreWEBAPI.Domain.DTOs
{
    public class BillDto : BaseDto
    {
        [Required]
        public List<ProductDto> Products { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public CompanyDto Company { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public double Sum { get; set; }
    }
}