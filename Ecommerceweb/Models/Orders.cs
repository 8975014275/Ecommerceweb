using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceweb.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { set; get; }
    }
}
