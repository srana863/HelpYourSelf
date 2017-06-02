using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Layer.Model.Common
{
    public class CurrentSession
    {
        public static AppSession GetCurrentSession()
        {
            AppSession vmSession;
            if (HttpContext.Current.Session[AppSetting.UserSession] != null)
            {
                return vmSession = HttpContext.Current.Session[AppSetting.UserSession] as AppSession;
            }
            else
            {
                return vmSession = null;
            }
        }
    }
}
