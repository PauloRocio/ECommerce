using System.Web.Mvc;

namespace Minutrade.ECommerce.WebApi.Areas.Clients
{
    public class ClientsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clients";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clients_default",
                "Clients/{controller}/{action}/{Id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}