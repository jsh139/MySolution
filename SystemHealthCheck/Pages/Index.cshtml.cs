using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using SystemHealthCheck.Code;
using SystemHealthCheck.Services;

namespace SystemHealthCheck.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, string> ResultList { get; set; }

        private readonly IWebProvider _webProvider;
        private const string NoData = "No Data";

        public IndexModel()
        {
            _webProvider = new WebProvider();
        }

        public void OnGet()
        {
            ResultList = new Dictionary<string, string>();

            _webApiMap.ForEach(api => ResultList.Add(api.Key, NoData));
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
