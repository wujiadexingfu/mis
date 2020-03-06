using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MIS.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace MIS.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            SetAutofacWeb();
            SetAutofacWebApi();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += (sender, e) => HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            base.Init();
        }


        /// <summary>
        /// 将AutoFac注册到MVC中
        /// </summary>
        private static void SetAutofacWeb()
        {
            //  创建autofac管理注册类的容器实例
            var builder = new ContainerBuilder();
   
            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly respAss = Assembly.Load("MIS.DAL");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serpAss = Assembly.Load("MIS.BLL");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(serpAss.GetTypes()).AsImplementedInterfaces();

            //使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            // builder.RegisterControllers(Assembly.GetExecutingAssembly());//生成具体的实例
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired(); // 这样支持属性注入

            builder.RegisterType<ExceptionHandleFilterAttribute>();
            builder.RegisterFilterProvider();
          

            var container = builder.Build();
            //下面就是使用MVC的扩展 更改了MVC中的注入方式.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// 将AutoFac注册到WebApi中
        /// </summary>
        private static void SetAutofacWebApi()
        {
            ContainerBuilder builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            Assembly respAss = Assembly.Load("MIS.DAL");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serpAss = Assembly.Load("MIS.BLL");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(serpAss.GetTypes()).AsImplementedInterfaces();

            builder.RegisterType<ExceptionHandleFilterAttribute>();


            builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(config);
                ;

            var container = builder.Build();
            // Set the WebApi dependency resolver.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}
