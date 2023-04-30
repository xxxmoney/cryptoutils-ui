using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils
{
    public interface IConsoleBuilder
    {
        /// <summary>
        /// Sets custom executable path.
        /// </summary>
        /// <param name="executablePath"></param>
        /// <returns></returns>
        IConsoleFinalBuilder WithCustomExecutablePath(string executablePath);

        /// <summary>
        /// Sets default executable path.
        /// </summary>
        /// <returns></returns>
        IConsoleFinalBuilder WithDefaultExecutablePath();
    }

    public interface IConsoleFinalBuilder
    {
        /// <summary>
        /// Builds the console app.
        /// If the executable path was not specified, default will be used.
        /// </summary>
        /// <returns></returns>
        IConsoleApp Build();
    }

    public class ConsoleBuilder : IConsoleBuilder, IConsoleFinalBuilder
    {
        private string executablePath;

        internal ConsoleBuilder()
        {
        }

        public IConsoleFinalBuilder WithCustomExecutablePath(string executablePath)
        {
            this.executablePath = executablePath;
            return this;
        }

        public IConsoleFinalBuilder WithDefaultExecutablePath()
        {
            this.executablePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cryptoutils.exe");
            return this;
        }

        public IConsoleApp Build()
        {
            return new ConsoleApp(this.executablePath);
        }
    }
}
