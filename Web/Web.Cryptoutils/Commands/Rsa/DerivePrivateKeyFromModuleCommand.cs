using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Rsa
{
    public class DerivePrivateKeyFromModuleCommand : Rsa.Command
    {
        protected override string CommandName => base.CommandName + " " + "derivePrivKeyFromMod";
        private readonly long n;
        private readonly long e;

        public DerivePrivateKeyFromModuleCommand(long n, long e)
        {
            this.n = n;
            this.e = e;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.n.ToString(),
                this.e.ToString(),
            };
        }
    }
}
