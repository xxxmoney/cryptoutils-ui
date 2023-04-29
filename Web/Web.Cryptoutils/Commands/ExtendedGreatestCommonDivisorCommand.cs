using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands
{
    public class ExtendedGreatestCommonDivisorCommand : Command
    {
        protected override string CommandName => "extgcd";
        private readonly long number;
        private readonly long prime;

        public ExtendedGreatestCommonDivisorCommand(long number, long prime)
        {
            this.number = number;
            this.prime = prime;
        }

        public override string[] GetParameters()
        {
            return new string[] 
            { 
                this.number.ToString(), 
                this.prime.ToString() 
            };
        }

    }
}
