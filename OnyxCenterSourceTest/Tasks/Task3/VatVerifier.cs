using Newtonsoft.Json;
using VatServices;

namespace OnyxCenterSourceTest.Tasks.Task3
{
    public class VatVerifier : IVatVerifier
    {
        private readonly Task2.ILogger _logger;
        private readonly IVatVerifierClient _client;
        public VatVerifier(Task2.ILogger logger, IVatVerifierClient client)
        {
            _logger = logger;
            _client = client;
        }

        /// <summary>
        /// Verifies the given VAT ID for the given country using the EU VIES web service.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="vatId"></param>
        /// <returns>Verification status</returns>
        // TODO: Implement Verify method
        public async Task<VerificationStatus> Verify(string countryCode, string vatId)
        {
            try
            {
                var result = await _client.CheckVatAsync(new checkVatRequest(countryCode, vatId));
                _logger.Log($"Recieved result: {JsonConvert.SerializeObject(result)}");
                return result.valid ? VerificationStatus.Valid : VerificationStatus.Invalid;    
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception in checkVatRequest: {ex}");
                return VerificationStatus.Unavailable;
            }
        }
    }
}
