using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_4.DBcontext
{
    [Table("Province")]
    public class Province
    {
        public Province() { }
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProvinceID { get; set; }
        [StringLength(50)]
        public string ProvinceName { get; set; }
        [StringLength(50)]
        public string? ProvinceDescription { get; set; }
    }
}
