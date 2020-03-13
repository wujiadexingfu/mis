using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Areas.WorkFlow.Controllers
{
    public class WorkFlowInstanceController : Controller
    {
       
        public ActionResult Index(string tableName,string workFlowInstanceUniqueId)
        {
            ViewBag.TableName = tableName;
            ViewBag.workFlowInstanceUniqueId = workFlowInstanceUniqueId;
            return View();
        }
    }
}