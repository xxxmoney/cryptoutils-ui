using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.ElGamal
{
    public class DecryptionCommand : Command
    {
        protected override string CommandName => base.CommandName + " " + "dec";
        private readonly long c;
        private readonly long d;
        private readonly long p;
        private readonly long a;

        public DecryptionCommand(long c, long d, long p, long a)
        {
            this.c = c;
            this.d = d;
            this.p = p;
            this.a = a;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                c.ToString(),
                d.ToString(),
                p.ToString(),
                a.ToString()
            };
        }
    }
}
