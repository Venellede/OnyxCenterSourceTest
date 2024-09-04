using VatServices;

namespace OnyxCenterSourceTest.Tasks.Task3
{
    public interface IVatVerifierClient
    {
        Task<checkVatResponse> CheckVatAsync(checkVatRequest request);
    }
}
