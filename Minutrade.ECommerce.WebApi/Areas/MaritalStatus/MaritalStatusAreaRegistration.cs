using System.Web.Mvc;

namespace Minutrade.ECommerce.WebApi.Areas.MaritalStatus
{
    public class MaritalStatusAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MaritalStatus";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MaritalStatus_default",
                "MaritalStatus/{controller}/{action}/{Id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}