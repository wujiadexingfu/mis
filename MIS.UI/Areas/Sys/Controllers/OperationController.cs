﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.Sys.Controllers
{
    public class OperationController : Controller
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

        public ActionResult OperationFunctionTree(string uniqueId)
        {
            ViewBag.UniqueId = uniqueId;
            return View();
        }

    }

}