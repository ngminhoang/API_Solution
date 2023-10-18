using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_4.DBcontext
{
    [Table("Ward")]
    public class Ward
    {
        
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WardID { get; set; }
        [StringLength(50)]
        public string WardName { get; set; }
        [StringLength(50)]
        public string? WardDescription { get; set; }
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        public virtual District district  { get; set; }
    }
}
