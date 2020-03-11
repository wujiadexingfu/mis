using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.WorkFlow.Controllers
{
    public class WorkFlowChartController : Controller
    {
        // GET: WorkFlow/WorkFlowChart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InputForm(string uniqueId)
        {
            ViewBag.UniqueId = uniqueId;
            return View();
        }

        public ActionResult DrawChart(string uniqueId)
        {
            ViewBag.UniqueId = uniqueId;
            return View();
        }


    }
}