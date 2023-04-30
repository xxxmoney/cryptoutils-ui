using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.IsGenerator
{
    public class NormalCommand : IsGenerator.Command
    {
        protected override string CommandName => base.CommandName + " " + "\"GF(p)\"";
        private readonly long p;
        private readonly long[] numbers;

        public NormalCommand(long p, long[] numbers)
        {
            this.p = p;
            this.numbers = numbers;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.p.ToString(),
            }.Concat(this.numbers.Select(number => number.ToString()))
            .ToArray();
        }
    }
}
