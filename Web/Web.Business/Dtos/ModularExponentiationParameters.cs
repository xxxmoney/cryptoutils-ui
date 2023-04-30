using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class ModularExponentiationParameters
    {
        [Required]
        public long Number { get; set; }
        [Required]
        public long Power { get; set; }
        [Required]
        public long Prime { get; set; }
    }
}
