using MIS.IBLL;
using MIS.Model.Account;
using MIS.Utility;
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
            _sysUserBLL.Login("admin", "123456");
;            ViewBag.Title = "Home Page";

            ViewBag.UserName = ((Account)HttpContext.Session[Constant.Account]).Name;
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
