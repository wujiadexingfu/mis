using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.WorkFlow.Controllers
{
    public class WorkFlowInstanceController : Controller
    {
       
        public ActionResult Index(string workFlowInstanceUniqueId)
        {

            workFlowInstanceUniqueId = "40100104-47EB-451B-A400-232F6D7BEDC6";
            ViewBag.workFlowInstanceUniqueId = workFlowInstanceUniqueId;
            return View();
        }


        public ActionResult InputForm(string workFlowInstanceUniqueId,string lineUniqueId)
        {
            ViewBag.WorkFlowInstanceUniqueId = workFlowInstanceUniqueId;
            ViewBag.LineUniqueId = lineUniqueId;
            return View();
        }

    }
}