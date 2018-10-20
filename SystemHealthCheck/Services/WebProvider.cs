using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace SystemHealthCheck.Services
{
    public interface IWebProvider
    {
        string GetHtml(string url, NameValueCollection additionalHeaders = null);
    }

    public class WebProvider : IWebProvider
    {
        private const int RequestTimeout = 600000;

        public string GetHtml(string url, NameValueCollection additionalHeaders = null)
        {
            if (!(WebRequest.Create(url) is HttpWebRequest request))
            {
                return string.Empty;
            }

            if (additionalHeaders != null && additionalHeaders.HasKeys())
            {
                request.Headers.Add(additionalHeaders);
            }

            request.Method = WebRequestMethods.Http.Get;
            request.ContentLength = 0;
            request.Timeout = RequestTimeout;

            return ReadResponse(request);
        }

        private string ReadResponse(WebRequest request)
        {
            var html = string.Empty;

            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (response.StatusCode == HttpStatusCode.OK && responseStream != null)
            {
                using (var reader = new StreamReader(responseStream))
                {
                    var responseFromServer = reader.ReadToEnd();
                    html = responseFromServer;
                }
            }

            response.Close();

            return html;
        }
    }
}
