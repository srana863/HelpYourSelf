using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpYourSelf.Controllers
{
    public class BaseController : Controller
    {
        public AppSession Session;
        public ReturnMessage retunMessage;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (base.Session[AppSetting.UserSession] != null)
            {
                Session = CurrentSession.GetCurrentSession();
            }
            else
            {
                Session = new AppSession();
                var user = new UserInfoSession { UserId = 1, UserName = "Admin", UserRoleId = 1 };
                Session.UserInfo = user;
                base.Session[AppSetting.UserSession] = Session;
                filterContext.Result = new RedirectResult("~/Home");
            }
            ViewBag.Session = Session;
            base.OnActionExecuting(filterContext);
        }
    }
}