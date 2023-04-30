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
    public class ElGamalHandler : Handler<ElGamalParameters>
    {
        public ElGamalHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override async Task<string> HandleAsync(ElGamalParameters parameters)
        {
            Command command = null;

            if (parameters.Encryption != null)
            {
                command = new Cryptoutils.Commands.ElGamal.EncryptionCommand(
                    parameters.Encryption.P,
                    parameters.Encryption.Z,
                    parameters.Encryption.B,
                    parameters.Encryption.K,
                    parameters.Encryption.M
                );
            }
            else if (parameters.Decryption != null)
            {
                command = new Cryptoutils.Commands.ElGamal.DecryptionCommand(
                    parameters.Decryption.C,
                    parameters.Decryption.D,
                    parameters.Decryption.P,
                    parameters.Decryption.A
                );
            }

            return await command?.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
