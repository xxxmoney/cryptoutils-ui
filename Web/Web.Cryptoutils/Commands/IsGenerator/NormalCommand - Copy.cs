using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.IsGenerator
{
    public class AdvancedCommand : IsGenerator.Command
    {
        protected override string CommandName => base.CommandName + " " + "\"GF(2^n)\"";
        private readonly string irreduciblePolynomialBinary;
        private readonly long n;
        private readonly string[] polynomialsBinary;

        public AdvancedCommand(string irreduciblePolynomialBinary, long n, string[] polynomialsBinary)
        {
            this.irreduciblePolynomialBinary = irreduciblePolynomialBinary;
            this.n = n;
            this.polynomialsBinary = polynomialsBinary;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.irreduciblePolynomialBinary,
                this.n.ToString()                
            }.Concat(this.polynomialsBinary)
            .ToArray();
        }
    }
}
