using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging;

namespace BL
{
    public static class ExceptionCatcher
    {
      
        public static void ExceptionFinder(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                string userinfo = AuthenticateHelperr.LoginUser[0].PersonelAd + "  " + AuthenticateHelperr.LoginUser[0].PersonelSoyad;
                NLogger.GetLogItems(ex, null, DateTime.UtcNow, null,userinfo);
            }
        }
    }
}
