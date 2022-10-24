using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceweb.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        // public int Id { get; set; }
       public int UserId { get; set; }

        public int ProductId { get; set; }
        
    }
}
