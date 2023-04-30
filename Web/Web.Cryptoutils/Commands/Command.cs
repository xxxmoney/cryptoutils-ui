using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Commands
{
    /// <summary>
    /// Base command that other should inherit from.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Command name used in parameters.
        /// </summary>
        protected abstract string CommandName { get; }

        /// <summary>
        /// Gets parameters as string [].
        /// </summary>
        /// <returns></returns>
        public abstract string[] GetParameters();

        private string[] GetFullParameters()
        {
            return new[]
            {
                this.CommandName
            }.Concat(GetParameters())
            .ToArray();
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns></returns>
        public Task<string> ExecuteAsync(IConsoleApp console)
        {
            return console.ExecuteAsync(Constants.Timeout, this.GetFullParameters());
        }

        /// <summary>
        /// Executes the command also with printed parameters in result.
        /// </summary>
        /// <param name="console"></param>
        /// <returns></returns>
        public async Task<string> ExecuteWithParametersPrintedAsync(IConsoleApp console)
        {
            string result = await console.ExecuteAsync(Constants.Timeout, this.GetFullParameters());
            return this.ToString() + Environment.NewLine + result;
        }

        /// <summary>
        /// Gets parameters in a readable form.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(" ", this.GetFullParameters());
        }
    }
}
