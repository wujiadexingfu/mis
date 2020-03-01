using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.Sys.Controllers
{
    public class SysCodeController : Controller
    {
        // GET: Sys/SysCode
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Tree()
        {
            return View();
        }

        public ActionResult InputForm(string uniqueId, string parentUniqueId)
        {
            ViewBag.UniqueId = uniqueId;
            ViewBag.ParentUniqueId = parentUniqueId;
            return View();
        }
    }
}