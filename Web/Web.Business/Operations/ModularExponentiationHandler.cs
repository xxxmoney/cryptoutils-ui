using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Cryptoutils;

namespace Web.Business.Operations
{
    public class ModularExponentiationHandler : Handler<ModularExponentiationParameters>
    {
        public ModularExponentiationHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override Task<string> HandleAsync(ModularExponentiationParameters parameters)
        {
            var command = new Cryptoutils.Commands.ModularExponentiationCommand(
                parameters.Number,
                parameters.Power,
                parameters.Prime
            );

            return command.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
