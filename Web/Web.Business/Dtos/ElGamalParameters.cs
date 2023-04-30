using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class ElGamalParameters
    {
        public ElGamalEncryptionParameters Encryption { get; set; }
        public ElGamalDecryptionParameters Decryption { get; set; }
    }

    public class ElGamalEncryptionParameters
    {
        [Required]
        public long P { get; set; }
        [Required]
        public long Z { get; set; }
        [Required]
        public long B { get; set; }
        [Required]
        public long K { get; set; }
        [Required]
        public long M { get; set; }    
    }
    public class ElGamalDecryptionParameters
    {
        [Required]
        public long C { get; set; }
        [Required]
        public long D { get; set; }
        [Required]
        public long P { get; set; }
        [Required]
        public long A { get; set; }
    }
}
