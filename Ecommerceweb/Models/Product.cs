using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceweb.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; } 



    }
}
