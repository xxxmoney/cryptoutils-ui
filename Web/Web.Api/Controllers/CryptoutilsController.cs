using Microsoft.AspNetCore.Mvc;
using Web.Business.Dtos;
using Web.Business.Operations;

namespace Web.Api.Controllers
{
    public class CryptoutilsController : BaseController
    {
        private readonly IHandler<ExtendedGreatestCommonDivisorParameters> extendedGreatestCommonDivisorParametersHandler;

        public CryptoutilsController(
            IHandler<ExtendedGreatestCommonDivisorParameters> extendedGreatestCommonDivisorParametersHandler)
        {
            this.extendedGreatestCommonDivisorParametersHandler = extendedGreatestCommonDivisorParametersHandler;
        }

        [HttpPost(nameof(HandleExtendedGreatestCommonDivisor))]
        public async Task<IActionResult> HandleExtendedGreatestCommonDivisor([FromBody] ExtendedGreatestCommonDivisorParameters parameters)
        {
            var result = await this.extendedGreatestCommonDivisorParametersHandler
                .HandleAsync(parameters);

            return Ok(result);
        }

    }
}
