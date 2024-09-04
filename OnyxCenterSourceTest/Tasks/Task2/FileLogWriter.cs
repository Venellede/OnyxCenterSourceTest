namespace OnyxCenterSourceTest.Tasks.Task2
{
    public class FileLogWriter : ILogWriter, IDisposable
    {
        private readonly StreamWriter _writer;
        public FileLogWriter(string path) 
        {
            _writer = new StreamWriter(File.Open(path, FileMode.Append))
            {
                AutoFlush = true
            };
        }

        public void WriteLine(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }

        public void Dispose()
        {
            _writer?.Flush();
            _writer?.Dispose();
        }

    }
}
