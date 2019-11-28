using MIS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.Sys.Controllers
{
    public class UserController : Controller
    {

        private ISysUserBLL _sysUserBLL;
        public UserController(ISysUserBLL sysUserBLL)
        {
            _sysUserBLL = sysUserBLL;
        }

        // GET: Sys/User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string Id, string password)
        {
            var m1=   _sysUserBLL.Login(Id, password);
            return Json(new { Id = "123" }, JsonRequestBehavior.AllowGet);
        }
    }
}