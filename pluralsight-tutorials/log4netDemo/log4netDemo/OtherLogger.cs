using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace log4netDemo
{
    //A seperate logger to the 'Program' logger object used to demo heirachical logging 
    class OtherLogger
    {
        public static void LogThings()
        {
            
            log4net.ILog log = log4net.LogManager.GetLogger(typeof (OtherLogger));

            const string format = "This is a [{0}] level logging event";

            log.DebugFormat(format, "Debug");
            log.InfoFormat(format, "Info");
            log.WarnFormat(format, "Warn");
            log.ErrorFormat(format, "Error ");
            log.FatalFormat(format, "Fatal");
        }
    }
}
