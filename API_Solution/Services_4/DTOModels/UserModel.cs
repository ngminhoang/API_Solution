using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_4.DTOModels
{
    public class UserModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string account { get; set; }
        public string password { get; set; }
    }
}
