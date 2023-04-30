using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Rsa
{
    public class EncryptionCommand : Rsa.Command
    {
        protected override string CommandName => base.CommandName + " " + "enc";
        private readonly long m;
        private readonly long n;
        private readonly long e;

        public EncryptionCommand(long m, long n, long e)
        {
            this.m = m;
            this.n = n;
            this.e = e;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.m.ToString(),
                this.n.ToString(),
                this.e.ToString()
            };
        }
    }
}
