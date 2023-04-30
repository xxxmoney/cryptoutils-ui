using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands.Shamir
{
    public abstract class Command : Commands.Command
    {
        protected override string CommandName => "shamir_protocol";
    }
}
