using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class dbLogger
    {
       public void DbLogger(LogLevel logLevel, DateTime dateTime, string loggingMessage, string UnameApp)
        {
            Logger logger = LogManager.GetLogger("databaseLogger");
            LogEventInfo logEventInfo = new LogEventInfo();
            logEventInfo.Properties["logDate"] = dateTime;
            logEventInfo.Properties["logMessage"] = loggingMessage;
            logEventInfo.Properties["userName"] = Environment.UserName;
            logger.Info(logEventInfo);
        }
    }
}
