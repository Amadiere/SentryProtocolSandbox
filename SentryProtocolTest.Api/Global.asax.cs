using Sentry;
using Sentry.EntityFramework;
using System;
using System.Configuration;
using System.Web.Http;

namespace SentryProtocolTest.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IDisposable _sentrySdk;

        protected void Application_Start()
        {
            SentryDatabaseLogging.UseBreadcrumbs();
            _sentrySdk = SentrySdk.Init(o =>
            {
                o.Dsn = new Dsn(ConfigurationManager.AppSettings["SentryDsn"]);
                o.Environment = ConfigurationManager.AppSettings["SentryEnvironment"] ?? "Unknown";
                o.AddEntityFramework();
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            SentrySdk.CaptureException(exception);
        }

        public override void Dispose()
        {
            _sentrySdk?.Dispose();
            base.Dispose();
        }
    }
}
