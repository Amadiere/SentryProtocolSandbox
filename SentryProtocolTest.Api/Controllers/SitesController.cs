using System;
using System.Web.Http;

namespace SentryProtocolTest.Api.Controllers
{
    [RoutePrefix("api/sites")]
    public class SitesController : ApiController
    {
        public IHttpActionResult Get()
        {
            throw new Exception("Ivalidicardo!");
        }
    }
}
