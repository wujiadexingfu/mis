using MIS.IBLL;
using MIS.UI.Filters;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.Sys.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
           var m= HttpContext.Session[Constant.Account];
            return View();
        }




        public ActionResult InputForm(string uniqueId)
        {
            ViewBag.UniqueId = uniqueId;
            return View();
        }
    }
}