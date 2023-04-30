using Microsoft.AspNetCore.Mvc;
using Web.Business.Dtos;
using Web.Business.Operations;

namespace Web.Api.Controllers
{
    public class CryptoutilsController : BaseController
    {
        private readonly IHandler<ExtendedGreatestCommonDivisorParameters> extendedGreatestCommonDivisorHandler;
        private readonly IHandler<EllipticCurveParameters> ellipticCurveHandler;

        public CryptoutilsController(
            IHandler<ExtendedGreatestCommonDivisorParameters> extendedGreatestCommonDivisorHandler, 
            IHandler<EllipticCurveParameters> ellipticCurveHandler)
        {
            this.extendedGreatestCommonDivisorHandler = extendedGreatestCommonDivisorHandler;
            this.ellipticCurveHandler = ellipticCurveHandler;
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

    }
}
