using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_4.DBcontext
{
    [Table("District")]
    public class District
    {
        public District() { }
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int districtID { get; set; }
        [StringLength(50)]
        public string districtName { get; set; }
        [StringLength(50)]
        public string? districtDescripton { get; set;}
        [ForeignKey("Province")]
        public int provinceID { get; set; }
        public virtual Province province { get; set; }
    }
}
