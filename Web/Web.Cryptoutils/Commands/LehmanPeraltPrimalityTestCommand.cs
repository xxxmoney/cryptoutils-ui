using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands
{
    public class LehmanPeraltPrimalityTestCommand : Command
    {
        protected override string CommandName => "lhperalt";
        private readonly long examinedNumber;
        private readonly long[] numbers;

        public LehmanPeraltPrimalityTestCommand(long examinedNumber, long[] numbers)
        {
            this.examinedNumber = examinedNumber;
            this.numbers = numbers;
        }

        public override string[] GetParameters()
        {
            return new[]
                {
                    this.examinedNumber.ToString()
                }
                .Concat(this.numbers.Select(number => number.ToString()))
                .ToArray();
        }

    }
}
