using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.Sys.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Sys/Function
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Tree()
        {
            return View();
        }

        public ActionResult InputForm(string Id, string parentId)
        {
            ViewBag.Id = Id;
            ViewBag.ParentId = parentId;
            return View();
        }
    }
}