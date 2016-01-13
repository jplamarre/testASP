<%@ Import Namespace="System.Web.Http" %>
<%@ Import Namespace="ProductsApp.Controllers" %>
<%@ Assembly Name="System.Web.Http" %>
<%@ Assembly Name="System.Web.Http.WebHost" %>
<script language="C#" runat="server">

        protected void Application_Start()
        {
            Console.WriteLine("Test");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }

        public static class WebApiConfig
        {
                public static void Register(HttpConfiguration config)
                {
                        
                        config.Routes.MapHttpRoute (
                                name: "DefaultApi",
                                routeTemplate: "api/{controller}/{id}",
                                defaults: new {id = System.Web.Http.RouteParameter.Optional}
                        );
                }
        }
</script>
