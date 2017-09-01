using System;
using System.Web.Http;

namespace SungardAS.Services.Api.Broadcast.Controllers
{
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Get the UTC time of the identity service. This call is added for test purpose.
        /// If hitting this endpoint from a browser returns time then you know this service is reachable.
        /// </summary>
        /// <returns>DateTime</returns>
        [HttpGet, Route("api/values/CurrentTime")]
        public DateTime CurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}