using System.Web.Mvc;
using System.Web.Routing;

namespace BulgarianCreators.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Create Post",
                url: "create/post",
                defaults: new { controller = "Post", action = "Create" });

            routes.MapRoute(
                name: "Post",
                url: "post",
                defaults: new { controller = "Post", action = "Index" }
            );

            routes.MapRoute(
                name: "Add to favorites",
                url: "post/add/{id}",
                defaults: new { controller = "Post", action = "Add", id = "" }
            );

            routes.MapRoute(
                name: "Single Post",
                url: "post/{id}",
                defaults: new { controller = "Post", action = "SingleBlogPost" }
            );



            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
