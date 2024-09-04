namespace OnyxCenterSourceTest.Tasks.Task3
{
    public interface IVatVerifier
    {
        Task<VerificationStatus> Verify(string countryCode, string vatId);
    }
}
