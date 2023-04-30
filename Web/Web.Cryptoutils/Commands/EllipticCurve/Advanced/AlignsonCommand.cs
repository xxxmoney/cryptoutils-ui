using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils.Models;

namespace Web.Cryptoutils.Commands.EllipticCurve.Advanced
{
    public class AlignsonCommand : Advanced.Command
    {
        protected override string CommandName => base.CommandName + " " + "alignson";
        private readonly string curveA_G;
        private readonly string curveB_G;
        private readonly string polynomialBinary;
        private readonly string irreduciblePolynomialBinary;
        private readonly long n;
        private readonly CustomPoint point;

        public AlignsonCommand(string curveA_G, string curveB_G, string polynomialBinary, string irreduciblePolynomialBinary, long n, CustomPoint point)
        {
            this.curveA_G = curveA_G;
            this.curveB_G = curveB_G;
            this.polynomialBinary = polynomialBinary;
            this.irreduciblePolynomialBinary = irreduciblePolynomialBinary;
            this.n = n;
            this.point = point;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                curveA_G,
                curveB_G,
                polynomialBinary,
                irreduciblePolynomialBinary,
                n.ToString(),
                point.AsString()
            };
        }
    }
}
