using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWEBAPI.Domain.Models
{
    public class BillModel : IBill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public virtual CompanyModel Company { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
        public double Sum { get; set; }
    }
}