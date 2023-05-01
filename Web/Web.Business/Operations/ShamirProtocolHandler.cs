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
    public class ShamirProtocolHandler : Handler<ShamirProtocolParameters>
    {
        public ShamirProtocolHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override async Task<string> HandleAsync(ShamirProtocolParameters parameters)
        {
            Command command = null;

            if (parameters.GetSubjects != null)
            {
                command = new Cryptoutils.Commands.Shamir.GetSubjectsCommand(
                    parameters.GetSubjects.P,
                    parameters.GetSubjects.K,
                    parameters.GetSubjects.N,
                    parameters.GetSubjects.S,
                    parameters.GetSubjects.Points
                );
            }
            else if (parameters.Reconstruction != null)
            {
                command = new Cryptoutils.Commands.Shamir.ReconstructionCommand(
                    parameters.Reconstruction.P,
                    parameters.Reconstruction.K,
                    parameters.Reconstruction.Points
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
