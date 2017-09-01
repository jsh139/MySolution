using System.Web.Mvc;

namespace SungardAS.Services.Api.Broadcast
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}