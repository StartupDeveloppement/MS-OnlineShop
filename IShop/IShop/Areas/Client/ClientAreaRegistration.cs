using System.Web.Mvc;

namespace IShop.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Client_default",
                "Client/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "IShop.Controllers" }
                //new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}