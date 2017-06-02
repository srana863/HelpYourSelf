using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Layer.Business.Common;
using Layer.Business.Interfaces;

namespace HelpYourSelf.Controllers
{
    public class CommonController : Controller
    {

        private readonly ICommonBALManager _commonBalManager;
        public CommonController()
        {
            _commonBalManager=new CommonBALManager();
        }
        #region Combo Loader...

        public JsonResult GetAllTutorialCategory()
        {
            var data = _commonBalManager.GetAllTutorialCategory();
            var list = data.Select(o => new SelectListItem
            {
                Value = o.CategoryId.ToString(),
                Text = o.Name.ToString()
            });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}