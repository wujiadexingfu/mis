using MIS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI.Filters
{
    /// <summary>
    /// 全局异常记录
    /// </summary>
    public class ExceptionHandleFilterAttribute: HandleErrorAttribute
    {

        public  ISysLogBLL _sysLogBLL { get; set; }

        public ExceptionHandleFilterAttribute(ISysLogBLL sysLogBLL)
        {
            _sysLogBLL = sysLogBLL;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            //1.获取异常对象
            Exception ex = filterContext.Exception;
            _sysLogBLL.WriteLog(ex);
           
            //重定向到友好页面
            //filterContext.Result = new RedirectResult("/TimeRecord/error");
            ////标记异常已经处理完毕
            //filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}