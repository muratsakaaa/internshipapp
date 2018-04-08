using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Logging;

namespace BL
{
    public static class AuthenticateHelperr
    {
        public static List<Personel> LoginUser = new List<Personel>();


        public static List<UserPermisson> Permisson(int roleID)
        {
            List<UserPermisson> list = new List<UserPermisson>();
            ExceptionCatcher.ExceptionFinder(() =>
            {
                if (roleID == 1)
                {

                }
                if (roleID == 3)
                {
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "navBar_uruntanim",
                        EnabledState = false
                    });
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "navBar_raporList",
                        EnabledState = false
                    });
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "navBar_personeltanim",
                        EnabledState = false
                    });
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "navBar_musteritanim",
                        EnabledState = false
                    });
                }
                if (roleID == 4)
                {
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "navBar_raporList",
                        EnabledState = false
                    });
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "navBar_urunList",
                        EnabledState = false
                    });
                    list.Add(new UserPermisson()
                    {
                        CompenetName = "Ribbonpage_AlimSatim",
                        EnabledState = false
                    });
                }


            });
            return list;
        }

    }

    public class UserPermisson
    {

        public string CompenetName { get; set; }
        public bool EnabledState { get; set; }
    }


}
