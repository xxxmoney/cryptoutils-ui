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
    public class RsaHandler : Handler<RsaParameters>
    {
        public RsaHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override async Task<string> HandleAsync(RsaParameters parameters)
        {
            Command command = null;

            if (parameters.Encryption != null)
            {
                command = new Cryptoutils.Commands.Rsa.EncryptionCommand(
                    parameters.Encryption.M,
                    parameters.Encryption.N,
                    parameters.Encryption.E
                );
            }
            else if (parameters.Decryption != null)
            {
                command = new Cryptoutils.Commands.Rsa.DecryptionCommand(
                    parameters.Decryption.M,
                    parameters.Decryption.N,
                    parameters.Decryption.D
                );
            }
            else if (parameters.DerivePrivateKeyFromModule != null)
            {
                command = new Cryptoutils.Commands.Rsa.DerivePrivateKeyFromModuleCommand(
                    parameters.DerivePrivateKeyFromModule.N,
                    parameters.DerivePrivateKeyFromModule.E
                );
            }
            else if (parameters.DeriveKeysFromPublicExponent != null)
            {
                command = new Cryptoutils.Commands.Rsa.DeriveKeysFromPublicExponent(
                    parameters.DeriveKeysFromPublicExponent.P,
                    parameters.DeriveKeysFromPublicExponent.Q,
                    parameters.DeriveKeysFromPublicExponent.E
                );
            }
            else if (parameters.DeriveKeysFromPrivateExponent != null)
            {
                command = new Cryptoutils.Commands.Rsa.DeriveKeysFromPrivateExponent(
                    parameters.DeriveKeysFromPrivateExponent.P,
                    parameters.DeriveKeysFromPrivateExponent.Q,
                    parameters.DeriveKeysFromPrivateExponent.D
                );
            }

            return await command?.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
