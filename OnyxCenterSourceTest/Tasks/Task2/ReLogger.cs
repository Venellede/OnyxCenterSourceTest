namespace OnyxCenterSourceTest.Tasks.Task2
{
    public class ReLogger : ILogger
    {
        private readonly ILogWriter _writer;
        private readonly TimeProvider _timeProvider;

        public ReLogger(ILogWriter writer, TimeProvider? timeProvider = null)
        {
            _writer = writer;
            _timeProvider = timeProvider ?? TimeProvider.System;

            Log("Logger initialized");
        }

        public void Log(string str)
        {
            _writer.WriteLine(string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", _timeProvider.GetUtcNow(), str));
        }
    }
}
