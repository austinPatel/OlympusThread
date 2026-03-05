using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympusThread.Models;
using OlympusThread.Utils;

namespace OlympusThread.Services
{
    public class ThreadLogService
    {
        private readonly string _filePath;
        private readonly object _fileLock = new object();
        private int LineIncrement = 0;

        public ThreadLogService(string filePath)
        {
            _filePath = filePath;
        }
        public void Initialize()
        {
            Directory.CreateDirectory("/log");
            var logEntry = new ThreadLog
            {
                LineCount = 0,
                ThreadId = 0,
                CurrentTimeStamp = CommonProvider.GetThreadTimeStamp()
            };
            lock (_fileLock)
            {
                File.WriteAllText(_filePath, logEntry.LineFormat() + Environment.NewLine );
            }
        }

        public void WriteThread() {

            int threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                int lineNumber = Interlocked.Increment(ref LineIncrement);
                var logEntry = new ThreadLog
                {
                    LineCount = lineNumber,
                    ThreadId = threadId,
                    CurrentTimeStamp = CommonProvider.GetThreadTimeStamp()
                };
                WriteLine(logEntry);

            }

        }
        public void WriteLine(ThreadLog threadLog) {
            lock (_fileLock)
            {
                File.AppendAllText(_filePath, threadLog.LineFormat() + Environment.NewLine );
            }
        }
    }
}
