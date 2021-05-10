using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestCoreApp.Controllers
{
    [ApiController]
    public class TwilioTestController : ControllerBase
    {
        [HttpPost("/TwilioTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult TwilioTest()
        {
            try
            {
                //var deliveryId = HttpContext.Request.Form["CallSid"];
                //var status = HttpContext.Request.Form["CallStatus"];

                return Content("<Response><Say>Hello</Say></Response>", "application/xml");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
