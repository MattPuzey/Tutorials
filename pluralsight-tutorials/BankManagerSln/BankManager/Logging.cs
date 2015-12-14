using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace BankManager
{
    public class Logging
    {
        private static ILogger _logger;
        public static ILogger Logger
        {
            get
            {
                return _logger ?? (_logger = new FileSystemLogger(@"C:\BankTutoriallog.txt"));
            }
            set
            {
                _logger = value;
            }
        }

        public static void WriteLine(string message)
            {
                Logger.WriteLine(message);
            }
    }

    public interface ILogger
    {
        void WriteLine(string message);

    }

    internal class FileSystemLogger : ILogger
    {
        private readonly string _logPath;
        public FileSystemLogger(string logPath)
        {
            _logPath = logPath;
            if (!File.Exists(_logPath))
                File.Create(_logPath);
        }

        public void WriteLine(string message)
        {
            using (var writer = File.AppendText(_logPath))
                writer.WriteLine(message);
        }
    }
}
