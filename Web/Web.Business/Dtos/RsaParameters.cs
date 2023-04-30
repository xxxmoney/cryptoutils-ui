using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class RsaParameters
    {
        public RsaEncryptionParameters Encryption { get; set; }
        public RsaDecryptionParameters Decryption { get; set; }
        public RsaDerivePrivateKeyFromModuleParameters DerivePrivateKeyFromModule { get; set; }
        public RsaDeriveKeysFromPublicExponentParameters DeriveKeysFromPublicExponent { get; set; }
        public RsaDeriveKeysFromPrivateExponentParameters DeriveKeysFromPrivateExponent { get; set; }
    }

    public class RsaEncryptionParameters
    {
        [Required]
        public long M { get; set; }
        [Required]
        public long N { get; set; }
        [Required]
        public long E { get; set; }
    }

    public class RsaDecryptionParameters
    {
        [Required]
        public long M { get; set; }
        [Required]
        public long N { get; set; }
        [Required]
        public long D { get; set; }
    }

    public class RsaDerivePrivateKeyFromModuleParameters
    {
        [Required]
        public long N { get; set; }
        [Required]
        public long E { get; set; }
    }

    public class RsaDeriveKeysFromPublicExponentParameters
    {
        [Required]
        public long P { get; set; }
        [Required]
        public long Q { get; set; }
        [Required]
        public long E { get; set; }
    }

    public class RsaDeriveKeysFromPrivateExponentParameters
    {
        [Required]
        public long P { get; set; }
        [Required]
        public long Q { get; set; }
        [Required]
        public long D { get; set; }
    }
}
