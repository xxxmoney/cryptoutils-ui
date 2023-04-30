using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class FermantFactorizationParameters
    {
        [Required]
        public long Number { get; set; }
    }
}
