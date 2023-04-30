using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils
{
    /// <summary>
    /// Used for executing arguments on executable.
    /// </summary>
    public interface IConsoleApp
    {
        /// <summary>
        /// Executes several arguments.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        Task<string> ExecuteAsync(TimeSpan timeout, params string[] arguments);
    }

    public class ConsoleApp : IConsoleApp
    {
        private readonly string executablePath;

        internal ConsoleApp(string executablePath)
        {
            this.executablePath = executablePath;
        }

        public async Task<string> ExecuteAsync(TimeSpan timeout, params string[] arguments)
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = executablePath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = string.Join(" ", arguments)
                }
            };

            process.Start();
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            // Wait for exit with max timeout on thread pool.
            await Task.Run(() => process.WaitForExit((int)timeout.TotalMilliseconds));

            if (!string.IsNullOrEmpty(error))
            {
                throw new InvalidOperationException($"Error: {error}");
            }

            return output;
        }
        
        /// <summary>
        /// Gets new builder for the console.
        /// </summary>
        /// <returns></returns>
        public static IConsoleBuilder GetBuilder() => new ConsoleBuilder();
    }
    
}
