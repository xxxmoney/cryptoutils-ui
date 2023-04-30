using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Cryptoutils;

namespace Web.Business.Operations
{
    public class FermantFactorizationHandler : Handler<FermantFactorizationParameters>
    {
        public FermantFactorizationHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override Task<string> HandleAsync(FermantFactorizationParameters parameters)
        {
            var command = new Cryptoutils.Commands.FermantFactorizationCommand(parameters.Number);

            return command.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
