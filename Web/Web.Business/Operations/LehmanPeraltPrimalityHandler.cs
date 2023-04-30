using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Cryptoutils;

namespace Web.Business.Operations
{
    public class LehmanPeraltPrimalityHandler : Handler<LehmanPeraltPrimalityParameters>
    {
        public LehmanPeraltPrimalityHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override Task<string> HandleAsync(LehmanPeraltPrimalityParameters parameters)
        {
            var command = new Cryptoutils.Commands.LehmanPeraltPrimalityTestCommand(
                parameters.ExaminedNumber,
                parameters.Numbers
            );

            return command.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
