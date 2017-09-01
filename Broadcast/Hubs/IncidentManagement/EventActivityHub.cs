using Microsoft.AspNet.SignalR;
using SunGardAS.Security.Principal;
using System.Threading.Tasks;

namespace SungardAS.Services.Api.Broadcast.Hubs.IncidentManagement
{
    public class EventActivityHub : Hub
    {
        // TODO: Uncomment once auth token is working
        //public override Task OnConnected()
        //{
        //    var tenant = SungardAsPrincipal.Current.Customer.UrlId;
        //    Groups.Add(Context.ConnectionId, tenant);

        //    return base.OnConnected();
        //}
    }
}