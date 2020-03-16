using System.Web.Mvc;

namespace MIS.UI.Areas.WorkFlowInstance
{
    public class WorkFlowInstanceAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WorkFlowInstance";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WorkFlowInstance_default",
                "WorkFlowInstance/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}