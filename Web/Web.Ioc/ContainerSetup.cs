using FoolProof.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Business.Operations;
using Web.Cryptoutils;

namespace Web.Ioc
{
    public interface IContainerSetup
    {
        IServiceCollection Configure(IServiceCollection services, Configuration configuration);
    }

    public class ContainerSetup : IContainerSetup
    {
        public IServiceCollection Configure(IServiceCollection services, Configuration configuration)
        {
            // Configuration
            services.AddSingleton(configuration);

            services.AddFoolProof();

            var consoleApp = ConsoleApp.GetBuilder().WithDefaultExecutablePath().Build();
            services.AddSingleton(consoleApp);
            services.AddSingleton<IHandler<ExtendedGreatestCommonDivisorParameters>, ExtendedGreatestCommonDivisorHandler>();
            services.AddSingleton<IHandler<EllipticCurveParameters>, EllipticCurveHandler>();
            services.AddSingleton<IHandler<ElGamalParameters>, ElGamalHandler>();
            services.AddSingleton<IHandler<FermantFactorizationParameters>, FermantFactorizationHandler>();
            services.AddSingleton<IHandler<IsGeneratorParameters>, IsGeneratorHandler>();
            services.AddSingleton<IHandler<LehmanPeraltPrimalityParameters>, LehmanPeraltPrimalityHandler>();
            services.AddSingleton<IHandler<PollardRhoAlgorithmParameters>, PollardRhoAlgorithmHandler>();
            services.AddSingleton<IHandler<RsaParameters>, RsaHandler>();
            services.AddSingleton<IHandler<ShamirProtocolParameters>, ShamirProtocolHandler>();

            return services;
        }

    }
}
