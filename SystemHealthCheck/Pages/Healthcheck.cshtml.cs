using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Specialized;
using SystemHealthCheck.Services;

namespace SystemHealthCheck.Pages
{
    public class HealthcheckModel : PageModel
    {
        private readonly IWebProvider _webProvider;

        public HealthcheckModel()
        {
            _webProvider = new WebProvider();
        }

        public JsonResult OnGet(string webApi, string baseUrl)
        {
            string result;

            if (!baseUrl.StartsWith("http://"))
            {
                baseUrl = $"http://{baseUrl}";
            }

            try
            {
                var url = $"{baseUrl}/{webApi}";

                result = CallHealthCheck(url);
            }
            catch (Exception e)
            {
                result = $"Error running health check: {e.Message}";
            }

            return new JsonResult(result);
        }

        private string CallHealthCheck(string baseUrl)
        {
            var headers = new NameValueCollection { { "api-version", "1.0" } };
            var result = _webProvider.GetHtml($"{baseUrl}/api/HealthCheck", headers);

            return result;
        }
    }
}