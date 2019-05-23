using System.Web.Http;
using SentryProtocolTest.Api.Helper;

namespace SentryProtocolTest.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new SentryUnhandledExceptionLogger());
        }
    }
}
