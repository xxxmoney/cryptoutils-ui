using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Rsa
{
    public class DecryptionCommand : Rsa.Command
    {
        protected override string CommandName => base.CommandName + " " + "dec";
        private readonly long m;
        private readonly long n;
        private readonly long d;

        public DecryptionCommand(long m, long n, long d)
        {
            this.m = m;
            this.n = n;
            this.d = d;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.m.ToString(),
                this.n.ToString(),
                this.d.ToString()
            };
        }
    }
}
