using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_4.DBcontext
{
    [Table("Ward")]
    public class Ward
    {
        
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wardID { get; set; }
        [StringLength(50)]
        public string wardName { get; set; }
        [StringLength(50)]
        public string? wardDescription { get; set; }
        [ForeignKey("District")]
        public int districtID { get; set; }
        public virtual District district  { get; set; }
    }
}
