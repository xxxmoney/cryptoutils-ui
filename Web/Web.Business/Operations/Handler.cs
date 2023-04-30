using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils;
using Web.Cryptoutils.Commands;

namespace Web.Business.Operations
{
    public interface IHandler<R>
        where R : class, new()
    {
        Task<string> HandleAsync(R parameters);
    }

    public abstract class Handler<R> : IHandler<R>
        where R : class, new()
    {
        protected readonly IConsoleApp consoleApp;

        protected Handler(IConsoleApp consoleApp)
        {
            this.consoleApp = consoleApp;
        }

        public abstract Task<string> HandleAsync(R parameters);

    }
}
