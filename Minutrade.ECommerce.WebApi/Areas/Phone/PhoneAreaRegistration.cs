using System.Web.Mvc;

namespace Minutrade.ECommerce.WebApi.Areas.Phone
{
    public class PhoneAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Phone";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Phone_default",
                "Phone/{controller}/{action}/{Id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}