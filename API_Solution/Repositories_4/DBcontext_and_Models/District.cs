using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_4.DBcontext
{
    [Table("District")]
    public class District
    {
        public District() { }
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistrictID { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }
        [StringLength(50)]
        public string? DistrictDescripton { get; set;}
        [ForeignKey("Province")]
        public int DrovinceID { get; set; }
        public virtual Province province { get; set; }
        public int ProvinceID { get; internal set; }
    }
}
