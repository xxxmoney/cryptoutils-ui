using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Rsa
{
    public class DeriveKeysFromPublicExponent : Rsa.Command
    {
        protected override string CommandName => base.CommandName + " " + "deriveKeysFromPubExp";
        private readonly long p;
        private readonly long q;
        private readonly long e;

        public DeriveKeysFromPublicExponent(long p, long q, long e)
        {
            this.p = p;
            this.q = q;
            this.e = e;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.p.ToString(),
                this.q.ToString(),
                this.e.ToString()
            };
        }
    }
}
