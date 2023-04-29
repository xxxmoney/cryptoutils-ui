using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.EllipticCurve.Advanced
{
    public abstract class Command : EllipticCurve.Command
    {
        protected override string CommandName => base.CommandName + " " + "\"GF(2^n)\"";


    }
}
