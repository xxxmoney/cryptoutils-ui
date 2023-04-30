using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class LehmanPeraltPrimalityParameters
    {
        [Required]
        public long ExaminedNumber { get; set; }
        [Required]
        public long[] Numbers { get; set; }
    }
}
