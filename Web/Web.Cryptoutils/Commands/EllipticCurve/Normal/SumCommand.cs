using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.EllipticCurve.Normal
{
    public class SumCommand : Command
    {
        protected override string CommandName => base.CommandName + " " + "sum";
        private readonly long curveA;
        private readonly long curveB;
        private readonly long curvePrime;
        private readonly Point firstPoint;
        private readonly Point secondPoint;

        public override string[] GetParameters()
        {
            return new string[]
            {
                curveA.ToString(),
                curveB.ToString(),
                curvePrime.ToString(),
                firstPoint.GetAsString(),
                secondPoint.GetAsString()
            };
        }
    }
}
