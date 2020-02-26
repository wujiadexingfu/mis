using MIS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Controllers
{
    public class HomeController : Controller
    {
        private ISysUserBLL _sysUserBLL;
        public HomeController(ISysUserBLL sysUserBLL)
        {
            _sysUserBLL = sysUserBLL;
        }


        public ActionResult Index()
        {
            _sysUserBLL.Login("admin", "admin");
;            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Chart()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }


        public ActionResult JsTree()
        {
            return View();
        }
    }
}
