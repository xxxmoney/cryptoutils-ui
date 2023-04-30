using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Cryptoutils;

namespace Web.Business.Operations
{
    public class PollardRhoAlgorithmHandler : Handler<PollardRhoAlgorithmParameters>
    {
        public PollardRhoAlgorithmHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override Task<string> HandleAsync(PollardRhoAlgorithmParameters parameters)
        {
            var command = new Cryptoutils.Commands.PollardRhoAlgorithmCommand(
                parameters.Number,
                parameters.Seed
            );

            return command.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
