using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_4.Models
{
    public class WardModel
    {
        public int wardID { get; set; }
        public string wardName { get; set; }
        public string wardDescription { get; set; }
        public int districtID { get; set; }
    }
}
