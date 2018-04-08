using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Logging
{
    public static class NLogger
    {
        public static void GetLogItems(Exception ex, InfoLogTypes? infoLogTypes, DateTime dateTime, UserAuthenticationStatus? authenticationStatus,string UserInfo)
        {
            dbLogger logger = new dbLogger();
            string message = "";
            NLog.LogLevel level = null;
            if (ex == null)
            {
                if (infoLogTypes == InfoLogTypes.LoginLogout)
                {
                    message = $"{authenticationStatus.ToString()} : {UserInfo}";
                    level = NLog.LogLevel.Info;
                }
                if (infoLogTypes == InfoLogTypes.Method)
                {
                    StackTrace st = new StackTrace();
                    StackFrame sf = st.GetFrame(0);
                    MethodBase currentMethodName = sf.GetMethod();
                    message = $"{currentMethodName.Name}";
                    level = NLog.LogLevel.Trace;
                }
            }
            else
            {
                if (ex.InnerException != null)
                {
                    message = $"{ex.InnerException.Message}  :  {ex.InnerException.StackTrace}";
                    level = NLog.LogLevel.Error;
                }
                else
                {
                    message = $"{ex.Message}:{ex.StackTrace}";
                    level = NLog.LogLevel.Error;
                }
            }
            logger.DbLogger(level, dateTime, message, UserInfo);
        }
    }
}
