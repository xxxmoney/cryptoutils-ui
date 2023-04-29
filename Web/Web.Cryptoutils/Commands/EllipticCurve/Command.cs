using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils.Commands;

namespace Web.Cryptoutils.Commands.EllipticCurve
{
    public abstract class Command : Commands.Command
    {
        protected override string CommandName => "ec";

    }
}
