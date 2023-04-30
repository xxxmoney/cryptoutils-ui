using Microsoft.AspNetCore.Mvc;
using Web.Business.Dtos;
using Web.Business.Operations;

namespace Web.Api.Controllers
{
    public class CryptoutilsController : BaseController
    {
        private readonly IHandler<ExtendedGreatestCommonDivisorParameters> extendedGreatestCommonDivisorHandler;
        private readonly IHandler<EllipticCurveParameters> ellipticCurveHandler;
        private readonly IHandler<ElGamalParameters> elGamalHandler;
        private readonly IHandler<FermantFactorizationParameters> fermantFactorizationHandler;
        private readonly IHandler<IsGeneratorParameters> isGeneratorHandler;
        private readonly IHandler<LehmanPeraltPrimalityParameters> lehmanPeraltHandler;
        private readonly IHandler<PollardRhoAlgorithmParameters> pollardRhoHandler;
        private readonly IHandler<RsaParameters> rsaHandler;
        private readonly IHandler<ShamirProtocolParameters> shamirHandler;

        public CryptoutilsController(
            IHandler<ExtendedGreatestCommonDivisorParameters> extendedGreatestCommonDivisorHandler,
            IHandler<EllipticCurveParameters> ellipticCurveHandler,
            IHandler<ElGamalParameters> elGamalHandler,
            IHandler<FermantFactorizationParameters> fermantFactorizationHandler,
            IHandler<IsGeneratorParameters> isGeneratorHandler,
            IHandler<LehmanPeraltPrimalityParameters> lehmanPeraltHandler,
            IHandler<PollardRhoAlgorithmParameters> pollardRhoHandler,
            IHandler<RsaParameters> rsaHandler,
            IHandler<ShamirProtocolParameters> shamirHandler)
        {
            this.extendedGreatestCommonDivisorHandler = extendedGreatestCommonDivisorHandler;
            this.ellipticCurveHandler = ellipticCurveHandler;
            this.elGamalHandler = elGamalHandler;
            this.fermantFactorizationHandler = fermantFactorizationHandler;
            this.isGeneratorHandler = isGeneratorHandler;
            this.lehmanPeraltHandler = lehmanPeraltHandler;
            this.pollardRhoHandler = pollardRhoHandler;
            this.rsaHandler = rsaHandler;
            this.shamirHandler = shamirHandler;
        }

        [HttpPost(nameof(HandleExtendedGreatestCommonDivisor))]
        public async Task<IActionResult> HandleExtendedGreatestCommonDivisor([FromBody] ExtendedGreatestCommonDivisorParameters parameters)
        {
            var result = await this.extendedGreatestCommonDivisorHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleEllipticCurve))]
        public async Task<IActionResult> HandleEllipticCurve([FromBody] EllipticCurveParameters parameters)
        {
            var result = await this.ellipticCurveHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleElGamal))]
        public async Task<IActionResult> HandleElGamal([FromBody] ElGamalParameters parameters)
        {
            var result = await this.elGamalHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleFermantFactorization))]
        public async Task<IActionResult> HandleFermantFactorization([FromBody] FermantFactorizationParameters parameters)
        {
            var result = await this.fermantFactorizationHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleIsGenerator))]
        public async Task<IActionResult> HandleIsGenerator([FromBody] IsGeneratorParameters parameters)
        {
            var result = await this.isGeneratorHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleLehmanPeralt))]
        public async Task<IActionResult> HandleLehmanPeralt([FromBody] LehmanPeraltPrimalityParameters parameters)
        {
            var result = await this.lehmanPeraltHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandlePollardRho))]
        public async Task<IActionResult> HandlePollardRho([FromBody] PollardRhoAlgorithmParameters parameters)
        {
            var result = await this.pollardRhoHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleRsa))]
        public async Task<IActionResult> HandleRsa([FromBody] RsaParameters parameters)
        {
            var result = await this.rsaHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

        [HttpPost(nameof(HandleShamir))]
        public async Task<IActionResult> HandleShamir([FromBody] ShamirProtocolParameters parameters)
        {
            var result = await this.shamirHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

    }
}
