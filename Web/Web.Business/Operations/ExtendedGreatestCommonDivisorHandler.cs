using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Cryptoutils;
using Web.Cryptoutils.Commands;

namespace Web.Business.Operations
{
    public class ExtendedGreatestCommonDivisorHandler : Handler<ExtendedGreatestCommonDivisorParameters>
    {
        public ExtendedGreatestCommonDivisorHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override Task<string> HandleAsync(ExtendedGreatestCommonDivisorParameters parameters)
        {
            var command = new ExtendedGreatestCommonDivisorCommand(parameters.Number, parameters.Prime);

            return command.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
