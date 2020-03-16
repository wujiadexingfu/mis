using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.WorkFlowInstance.Controllers
{
    public class WorkFlowRegisterUserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkFlowInstance/WorkFlowRegisterUser
        public ActionResult Draft()
        {
            return View();
        }

        public ActionResult SupervisorAudit()
        {
            return View();
        }

        public ActionResult SupervisorReview()
        {
            return View();
        }

        public ActionResult FinalAudit()
        {
            return View();
        }


        public ActionResult End()
        {
            return View();
        }
    }
}