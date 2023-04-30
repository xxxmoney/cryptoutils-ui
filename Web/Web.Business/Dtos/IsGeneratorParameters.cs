using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class IsGeneratorParameters
    {
        public IsGeneratorNormalParameters Normal { get; set; }
        public IsGeneratorAdvancedParameters Advanced { get; set; }
    }

    public class IsGeneratorNormalParameters
    {
        [Required]
        public long P { get; set; }
        [Required]
        public long[] Numbers { get; set; }
    }

    public class IsGeneratorAdvancedParameters
    {
        [Required]
        public string IrreduciblePolynomialBinary { get; set; }
        [Required]
        public long N { get; set; }
        [Required]
        public string[] PolynomialsBinary { get; set; }
    }
}
