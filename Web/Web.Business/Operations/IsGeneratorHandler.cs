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
    public class IsGeneratorHandler : Handler<IsGeneratorParameters>
    {
        public IsGeneratorHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override async Task<string> HandleAsync(IsGeneratorParameters parameters)
        {
            Command command = null;

            if (parameters.Normal != null)
            {
                command = new Cryptoutils.Commands.IsGenerator.NormalCommand(
                    parameters.Normal.P,
                    parameters.Normal.Numbers
                );
            }
            else if (parameters.Advanced != null)
            {
                command = new Cryptoutils.Commands.IsGenerator.AdvancedCommand(
                    parameters.Advanced.IrreduciblePolynomialBinary,
                    parameters.Advanced.N,
                    parameters.Advanced.PolynomialsBinary
                );
            }

            if (command == null)
            {
                return null;
            }

            return await command.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
