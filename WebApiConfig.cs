
using System.Web.Http;

public static class WebApiConfig
{  
    public static void Register()
    {

        GlobalConfiguration.Configuration.Routes.MapHttpRoute (
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = System.Web.Http.RouteParameter.Optional}
                );
    }
}
