using System.Web.Mvc;

namespace Minutrade.ECommerce.WebApi.Areas.States
{
    public class StatesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "States";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "States_default",
                "States/{controller}/{action}/{Id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}