using System.IO;
using System.Net;

namespace PdfGenerator
{
    public class HtmlTools
    {
        public static string GetHtml(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = WebRequestMethods.Http.Get;
            request.ContentLength = 0;
            request.Timeout = 600000;

            var html = string.Empty;

            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(responseStream))
                {
                    string responseFromServer = reader.ReadToEnd();
                    html = responseFromServer;
                }
            }

            response.Close();

            return html;
        }
    }
}
