using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands
{
    public class ModularExponentiationCommand : Command
    {
        protected override string CommandName => "modexp";
        private readonly long number;
        private readonly long power;
        private readonly long prime;

        public ModularExponentiationCommand(long number, long power, long prime)
        {
            this.number = number;
            this.power = power;
            this.prime = prime;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.number.ToString(),
                this.power.ToString(),
                this.prime.ToString()
            };
        }

    }
}
