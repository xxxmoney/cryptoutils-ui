using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands
{
    public class FermantFactorizationCommand : Command
    {
        protected override string CommandName => "fermant";
        private readonly long number;

        public FermantFactorizationCommand(long number)
        {
            this.number = number;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.number.ToString()
            };
        }

    }
}
