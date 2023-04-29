using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Shamir
{
    internal class ReconstructionCommand : Command
    {
        protected override string CommandName => base.CommandName + " " + "reconstruction";
        private readonly long p;
        private readonly long K;
        private readonly Point[] points;

        public ReconstructionCommand(long p, long K, Point[] points)
        {
            this.p = p;
            this.K = K;
            this.points = points;
        }

        public override string[] GetParameters()
        {
            return new string[]
            {
                this.p.ToString(),
                this.K.ToString(),
            }.Concat(this.points.Select(point => point.GetAsString()).ToArray())
            .ToArray();
        }
    }
}
