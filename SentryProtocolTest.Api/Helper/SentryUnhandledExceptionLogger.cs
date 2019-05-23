using Sentry;
using System;
using System.Web.Http.Filters;

namespace SentryProtocolTest.Api.Helper
{
    public class SentryUnhandledExceptionLogger : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            SentrySdk.ConfigureScope(scope =>
            {
                 scope.SetTag("servername", Environment.MachineName.ToString());
            });
            SentrySdk.CaptureException(context.Exception);
        }
    }
}