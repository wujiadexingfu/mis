﻿using MIS.UI.Filters;
using System.Web;
using System.Web.Mvc;

namespace MIS.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add( DependencyResolver.Current.GetService<ExceptionHandleFilterAttribute>());
            filters.Add(new AccountFilterAttribute());
            filters.Add(new GetOperationFilterAttribute());



            


        }
    }
}
