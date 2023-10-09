using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_4.Models
{
    public class DistrictModel
    {
        public int districtID { get; set; }
        public string districtName { get; set; }
        public string districtDescription { get; set; }
        public int provinceID { get; set; }
    }
}
