using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWEBAPI.Domain.Models
{
    public class ProductModel : IProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Prize { get; set; }
        public virtual BillModel Bill { get; set; }
    }
}