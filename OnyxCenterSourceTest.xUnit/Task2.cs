using Microsoft.Extensions.Time.Testing;
using Moq;
using OnyxCenterSourceTest.Tasks.Task2;
using Xunit.Abstractions;

namespace OnyxCenterSourceTest.xUnit
{
    public class Task2
    {
        private readonly ITestOutputHelper _output;

        public Task2(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task Log_Message_DateTimeFormatted()
        {
            var logWriterMock = new Mock<ILogWriter>();
            logWriterMock.Setup(l => l.WriteLine(It.IsAny<string>())).Callback<string>(_output.WriteLine);

            var timeProvider = new FakeTimeProvider();
            timeProvider.SetUtcNow(new DateTimeOffset(2024, 08, 27, 11, 00, 00, TimeSpan.Zero));

            var logger = new ReLogger(logWriterMock.Object, timeProvider);

            logger.Log("My test message!");

            logWriterMock.Verify(m => m.WriteLine(It.Is<string>(s => s == "[27.08.24 11:00:00] My test message!")), Times.Once, "Invalid logger message");
        }
    }
}
