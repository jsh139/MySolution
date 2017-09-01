#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using System.Web.Http;
using SungardAS.Services.Api.Broadcast.Code;
using SungardAS.Services.Api.Broadcast.Hubs.IncidentManagement;

namespace SungardAS.Services.Api.Broadcast.Controllers
{
    public class BroadcastController : ApiControllerWithHub<EventActivityHub>
    {
        [HttpGet, Route("api/broadcast/sendmessage")]
        public bool SendMessage(string group, string message)
        {
            // Uncomment once Identity service is used
            //Hub.Clients.Group(group).sendMessage(message);
            Hub.Clients.All.sendMessage(message);

            return true;
        }
    }
}