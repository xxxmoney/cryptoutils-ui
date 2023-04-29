﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.EllipticCurve.Normal
{
    public class AlignsonCommand : Normal.Command
    {
        protected override string CommandName => base.CommandName + " " + "alignson";
        private readonly long curveA;
        private readonly long curveB;
        private readonly long curvePrime;
        private readonly Point firstPoint;
        private readonly Point secondPoint;

        public AlignsonCommand(long curveA, long curveB, long curvePrime, Point firstPoint, Point secondPoint)
        {
            this.curveA = curveA;
            this.curveB = curveB;
            this.curvePrime = curvePrime;
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }

        public override string[] GetParameters()
        {
            return new[]
            {
                curveA.ToString(),
                curveB.ToString(),
                curvePrime.ToString(),
                this.fi
            };
        }
    }
}
