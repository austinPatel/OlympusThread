using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympusThread.Utils
{
    public static class CommonProvider
    {
        public static string GetThreadTimeStamp()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }
    }
}
