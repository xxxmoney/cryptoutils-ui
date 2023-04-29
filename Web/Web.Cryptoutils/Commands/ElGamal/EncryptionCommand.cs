using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.ElGamal
{
    public class EncryptionCommand : Command
    {
        protected override string CommandName => base.CommandName + " " + "enc";
        private readonly long p;
        private readonly long z;
        private readonly long b;
        private readonly long k;
        private readonly long m;

        public EncryptionCommand(long p, long z, long b, long k, long m)
        {
            this.p = p;
            this.z = z;
            this.b = b;
            this.k = k;
            this.m = m;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                p.ToString(),
                z.ToString(),
                b.ToString(),
                k.ToString(),
                m.ToString()
            };
        }
    }
}
