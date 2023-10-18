using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_4.DBcontext
{
    [Table("User")]
    public class User
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
