using Microsoft.AspNetCore.Mvc;
using OnyxCenterSourceTest.Tasks.Task3;

namespace OnyxCenterSourceTest.Tasks.Task4
{
    [ApiController]
    [Route("vatverify")]
    public class VatVerifierController : ControllerBase
    {
        private readonly Task2.ILogger _logger;
        private readonly IVatVerifier _vatVerifier;


        public VatVerifierController(Task2.ILogger logger, IVatVerifier vatVerifier)
        {
            _logger = logger;
            _vatVerifier = vatVerifier;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Ok()
        {
            return Ok("Success!");
        }

        [HttpGet]
        [Route("{countryCode}/{vatId}")]
        public async Task<IActionResult> VerifyVat(string countryCode, string vatId)
        {
            var result = await _vatVerifier.Verify(countryCode, vatId);
            return Ok(result.ToString());
        }


    }
}
