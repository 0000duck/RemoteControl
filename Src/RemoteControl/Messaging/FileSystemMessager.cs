using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace RemoteControl.Messaging
{
    class FileSystemMessager : IMessager
    {
        private String _seedFileName;
        private MessagerContext _context;
        private FileSystemWatcher _fileSystemWatcher;
        private AutoResetEvent _mres;

        private int IncrementSeed()
        {
            var seed = int.Parse(File.ReadAllText(_seedFileName)) + 1;

            File.WriteAllText(_seedFileName, seed.ToString(CultureInfo.InvariantCulture));

            return seed;
        }

        public bool InitializeMessager(MessagerContext ctx)
        {
            ctx.EnsureNotNull("Context should not be null.");
            ctx.QueueName.EnsureNotEmpty("QueueName should not be empty.");

            _context = ctx;

            if (!Directory.Exists(ctx.QueueName))
            {
                Directory.CreateDirectory(ctx.QueueName);
            }

            _seedFileName = Path.Combine(ctx.QueueName, "seed");

            if (!File.Exists(_seedFileName))
            {
                File.WriteAllText(_seedFileName, "0");
            }

            _mres = new AutoResetEvent(false);
            _fileSystemWatcher = new FileSystemWatcher(_context.QueueName);

            //
            // Signal that a new file was created.
            _fileSystemWatcher.Created += (sender, args) => _mres.Set();

            return true;
        }

        public void PushMessage(string message)
        {
            int seed = IncrementSeed();

            File.WriteAllText(Path.Combine(_context.QueueName, seed.ToString(CultureInfo.InvariantCulture), ".msg"), message);
        }

        public string PopMessage()
        {
            while (true)
            {
                var msgFile = Directory
                    .GetFiles(_context.QueueName, "*.msg")
                    .Select(e => e.Replace("*.msg", ""))
                    .Select(e => int.Parse(e))
                    .OrderBy(e => e)
                    .FirstOrDefault();

                //
                // Empty queue
                if (msgFile == 0)
                {
                    _mres.WaitOne();
                    continue;
                }

                var path = Path.Combine(_context.QueueName, msgFile.ToString(CultureInfo.InvariantCulture), ".msg");

                var contents = File.ReadAllText(path);

                File.Delete(path);

                return contents;
            }
        }
    }
}
