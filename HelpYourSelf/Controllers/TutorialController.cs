// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TutorialController.cs" company="">
//   
// </copyright>
// <summary>
//   The tutorial controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpYourSelf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Layer.Business.BAL.Tutorial;
    using Layer.Business.Interfaces;
    using Layer.Model.Common;
    using Layer.Model.Model.Tutorial;

    /// <summary>
    /// The tutorial controller.
    /// </summary>
    public class TutorialController : BaseController
    {
        /// <summary>
        /// The tutorial manager.
        /// </summary>
        private readonly ITutorialManager tutorialManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TutorialController"/> class.
        /// </summary>
        public TutorialController()
        {
            this.tutorialManager = new TutorialManager();
        }
        
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The save tutorial.
        /// </summary>
        /// <param name="tutorial">
        /// The tutorial.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveTutorial(Tutorials tutorial)
        {
            var message = this.tutorialManager.Save(tutorial, this.Session);
            return this.Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllTutorialByUserId()
        {
            var data=this.tutorialManager.GetAllTutorialByUserId(this.Session.UserInfo.UserId);
            return this.PartialView("_GetAllTutorialByUserId", data);
        }
    }
}