using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands
{
    public class PollardRhoAlgorithmCommand : Command
    {
        protected override string CommandName => "rhoalgo";
        private readonly long number;
        private readonly long seed;

        public PollardRhoAlgorithmCommand(long number, long seed)
        {
            this.number = number;
            this.seed = seed;
        }

        public override string[] GetParameters()
        {
            return new[]
            {
                this.number.ToString(),
                this.seed.ToString()
            };
        }
        
    }
}
