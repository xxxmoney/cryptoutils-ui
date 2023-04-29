using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils.Models;

namespace Web.Cryptoutils.Commands.EllipticCurve.Advanced
{
    public class SumCommand : Command
    {
        protected override string CommandName => base.CommandName + " " + "sum";
        private readonly string curveA_G;
        private readonly string curveB_G;
        private readonly string polynomialBinary;
        private readonly string irreduciblePolynomial;
        private readonly long n;
        private readonly CustomPoint firstPoint;
        private readonly CustomPoint secondPoint;

        public SumCommand(string curveA_G, string curveB_G, string polynomialBinary, string irreduciblePolynomial, long n, CustomPoint firstPoint, CustomPoint secondPoint)
        {
            this.curveA_G = curveA_G;
            this.curveB_G = curveB_G;
            this.polynomialBinary = polynomialBinary;
            this.irreduciblePolynomial = irreduciblePolynomial;
            this.n = n;
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                curveA_G,
                curveB_G,
                polynomialBinary,
                irreduciblePolynomial,
                n.ToString(),
                firstPoint.GetAsString(),
                secondPoint.GetAsString()
            };
        }
    }
}
