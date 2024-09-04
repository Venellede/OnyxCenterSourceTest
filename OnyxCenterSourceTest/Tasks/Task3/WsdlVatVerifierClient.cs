using VatServices;

namespace OnyxCenterSourceTest.Tasks.Task3
{
    public class WsdlVatVerifierClient : IVatVerifierClient, IDisposable
    {
        private readonly checkVatPortTypeClient _client;

        public WsdlVatVerifierClient(checkVatPortTypeClient client)
        {
            _client = client;
        }

        public Task<checkVatResponse> CheckVatAsync(checkVatRequest request)
        {
            return _client.checkVatAsync(request);
        }

        public void Dispose()
        {
            _client?.Close();
        }
    }
}
