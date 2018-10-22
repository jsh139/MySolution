using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using SystemHealthCheck.Code;

namespace SystemHealthCheck.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, string> WebApiList { get; set; }
        public string BaseUrl { get; set; }

        private const string NoData = "No Data";
        private const string DefaultBaseUrl = "http://local.assuranceservices.assurancesoftware.com";

        public IndexModel()
        {
            // TODO: Get from app settings
            BaseUrl = DefaultBaseUrl;  
        }

        public void OnGet()
        {
            WebApiList = new Dictionary<string, string>();

            _webApiMap.ForEach(api => WebApiList.Add(api.Key, NoData));
        }

        private readonly Dictionary<string, string> _webApiMap = new Dictionary<string, string>
        {
            {"AcctSvc", "Assurance.ApiClients.AccountManagement"},
            {"AidSvc", "Assurance.ApiClients.Security"},
            {"AssessmentSvc", "Assurance.ApiClients.Assessment"},
            {"ChartingSvc", "Assurance.ApiClients.Charting"},
            {"DocSvc", "Assurance.ApiClients.DocumentManagement"},
            {"ImSvc", "Assurance.ApiClients.Continuity"},
            {"IxbSvc", "Assurance.ApiClients.Ixb"},
            {"LinkingSvc", "Assurance.ApiClients.Linking"},
            {"PlanningSvc", "Assurance.ApiClients.Planning"},
            {"PublicApiSvc", "Assurance.ApiClients.PublicApi"},
            {"ReportingSvc", "Assurance.ApiClients.Reporting"},
            {"SchSvc", "Assurance.ApiClients.Scheduler"},
            {"WflSvc", "Assurance.ApiClients.Workflow"},
        };
    }
}
