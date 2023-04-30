using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Shamir
{
    public class GetSubjectsCommand : Command
    {
        protected override string CommandName => base.CommandName + " " + "getSubjects";
        private readonly long p;
        private readonly long K;
        private readonly long N;
        private readonly long S;
        private readonly Point[] points;

        public GetSubjectsCommand(long p, long K, long N, long S, Point[] points)
        {
            this.p = p;
            this.K = K;
            this.N = N;
            this.S = S;
            this.points = points;
        }

        public override string[] GetParameters()
        {
            return new[]
            {
                this.p.ToString(),
                this.K.ToString(),
                this.N.ToString(),
                this.S.ToString()
            }.Concat(this.points.Select(point => point.AsString()).ToArray())
            .ToArray();
        }
    }
}
