using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class ShamirProtocolParameters
    {
        public ShamirProtocolGetSubjectsParameters GetSubjects { get; set; }
        public ShamirProtocolReconstructionParameters Reconstruction { get; set; }
    }

    public class ShamirProtocolGetSubjectsParameters
    {
        [Required]
        public long P { get; set; }
        [Required]
        public long K { get; set; }
        [Required]
        public long N { get; set; }
        [Required]
        public long S { get; set; }
        [Required]
        public Point[] Points { get; set; }
    }

    public class ShamirProtocolReconstructionParameters
    {
        [Required]
        public long P { get; set; }
        [Required]
        public long K { get; set; }
        [Required]
        public Point[] Points { get; set; }
    }
}
