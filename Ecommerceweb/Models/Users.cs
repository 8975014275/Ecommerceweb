using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceweb.Models
{
    [Table("Users")]
    public class Users
    {
        
        [Key]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "name is required")]
        [Display(Name = " Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int RoleId { get; set; }



    }
}
