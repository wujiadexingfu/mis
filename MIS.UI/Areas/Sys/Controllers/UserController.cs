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
            return View();
        }




        public ActionResult InputForm(string uniqueId)
        {
            ViewBag.UniqueId = uniqueId;
            return View();
        }

        public ActionResult OrganizationUser(string selectedUser)
        {
            if (selectedUser == null)
            {
                selectedUser = "[]";
            }
            ViewBag.SelectedUser = selectedUser;
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}