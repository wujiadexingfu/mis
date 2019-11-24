using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace MIS.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //https://www.cnblogs.com/lollipop/p/6651124.html  
            var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, "ApiController");


            //新增路由规则
            config.Routes.MapHttpRoute(
                 name: "DefaultAreaApi",
                 routeTemplate: "api/{area}/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                 name: "SecondAreaApi",
                 routeTemplate: "api/{area}/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                 name: "SecondApi",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                 name: "ThirdApi",
                 routeTemplate: "api/{controller}/{action}",
                 defaults: new { id = RouteParameter.Optional }
             );
            ////增加webAPI权限配置
            config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
            //增加日志记录



            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //默认返回 json  
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("datatype", "json", "application/json"));
            //返回格式选择 datatype 可以替换为任何参数   
        }
    }
}
