using Moq;
using OnyxCenterSourceTest.Tasks.Task2;
using OnyxCenterSourceTest.Tasks.Task3;
using VatServices;
using Xunit.Abstractions;

namespace OnyxCenterSourceTest.xUnit
{
    public class Task3
    {
        private readonly ITestOutputHelper _output;

        public Task3(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("DE", "118856456", VerificationStatus.Valid)]
        [InlineData("DE", "invalid_id", VerificationStatus.Invalid)]
        public async Task Verify_CorrectRequests(string countryCode, string vatId, VerificationStatus expected)
        {
            var logger = new Mock<ILogger>();
            logger.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(_output.WriteLine);

            using var client = new WsdlVatVerifierClient(new checkVatPortTypeClient());

            var service = new VatVerifier(logger.Object, client);
            var result = await service.Verify(countryCode, vatId);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Verify_ErrorInRequest_Unavailable()
        {
            var logger = new Mock<ILogger>();
            logger.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(_output.WriteLine);
            var client = new Mock<IVatVerifierClient>();
            client.Setup(c => c.CheckVatAsync(It.IsAny<checkVatRequest>())).ThrowsAsync(new TimeoutException());

            var service = new VatVerifier(logger.Object, client.Object);
            var result = await service.Verify("any", "value");
            Assert.Equal(VerificationStatus.Unavailable, result);
        }
    }
}
