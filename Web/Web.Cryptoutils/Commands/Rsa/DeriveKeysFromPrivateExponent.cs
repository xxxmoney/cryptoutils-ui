using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Rsa
{
    public class DeriveKeysFromPrivateExponent : Rsa.Command
    {
        protected override string CommandName => base.CommandName + " " + "deriveKeysFromPrivExp";
        private readonly long p;
        private readonly long q;
        private readonly long d;

        public DeriveKeysFromPrivateExponent(long p, long q, long d)
        {
            this.p = p;
            this.q = q;
            this.d = d;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.p.ToString(),
                this.q.ToString(),
                this.d.ToString()
            };
        }
    }
}
