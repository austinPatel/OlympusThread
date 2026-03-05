using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympusThread.Models
{
    public class ThreadLog
    {
        public int LineCount { get; set; }
        public int ThreadId { get; set; }
        public string CurrentTimeStamp { get; set; }

        public string LineFormat()
        {
            return $"{LineCount}, {ThreadId}, {CurrentTimeStamp}";
        }
        

    }
}
