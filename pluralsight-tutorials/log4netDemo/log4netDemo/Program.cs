using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

//Declarative initialisation of the log4net XML configurator 
//attaches xml configurator to the assembly that is loading log4net
//defers config until the first logging event is created but has same effect as using the Configure method . 
//[assembly:log4net.Config.XmlConfigurator]

namespace log4netDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Procedural initialisation for the XML Configurator, to configure log4net
            log4net.Config.XmlConfigurator.Configure();
            // Configure log4net with the default configurator as follows:
            //.Config.BasicConfigurator.Configure();
            //Create the logger object
            log4net.ILog log = log4net.LogManager.GetLogger(typeof (Program));
            //Call to log object to log message 
            //Logs the offeset of message from startup in miliseconds, the thread number, the Log level and the output.
            //Default configuration is limited to console output.

            const string format = "This is a [{0}] level logging event";

            log.DebugFormat(format, "Debug");
            log.InfoFormat(format, "Info");
            log.WarnFormat(format, "Warn");
            log.ErrorFormat(format, "Error ");
            log.FatalFormat(format, "Fatal");

            OtherLogger.LogThings();

            Console.ReadLine();
        }
    }
}
