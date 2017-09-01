using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;

namespace SungardAS.Services.Api.Broadcast.Controllers
{
    [RoutePrefix("api/push")]
    public class PushController : ApiController
    {
        private const string IosToken = "25656dd633df9ac86652e968d7676d5011c264a1e35c18b5131d2c4eb4758e3d";
        private const string IosPayload = "{{\"aps\":{{\"alert\":\"{0}\",\"badge\":69,\"sound\":\"default\"}}}}";
        private const string AndroidToken = "cRTe3EWwUwA:APA91bHLwFmifC3m8gNUixpChXFqSBOVln4YS6AyPJBJZgG_at5i07_CqqWQq_1-4Xcu07uGymaaE5uR8C6bblo375d5BwAxl71MAxlbDjeY_2AEuwtC53Tpn122upeGg4esaGP8WfN9";
        private const string AndroidApiKey = "AIzaSyCM4XHz4yO7qkiHwCkqTIPcs9TcindjG6c";

        [HttpGet, Route("")]
        public bool Get(string message, string endpoint)
        {
            return endpoint.ToLower() == "ios" ? 
                PushIosMessage(IosToken, message) :
                PushAndroidMessage(AndroidToken, message);
        }

        private bool PushIosMessage(string deviceId, string message)
        {
            const int port = 2195;
            const string hostname = "gateway.sandbox.push.apple.com";
            var clientCertificate =
                new X509Certificate2(File.ReadAllBytes(HostingEnvironment.MapPath("~/App_Data/PushPocCert.p12")), "");
            var certificatesCollection = new X509Certificate2Collection(clientCertificate);

            var client = new TcpClient(hostname, port);
            var sslStream = new SslStream(client.GetStream(), false);

            try
            {
                sslStream.AuthenticateAsClient(hostname, certificatesCollection, SslProtocols.Tls, false);

                var memoryStream = new MemoryStream();
                var writer = new BinaryWriter(memoryStream);
                writer.Write(new byte[] {0, 0, 32});
                writer.Write(HexStringToByteArray(deviceId.ToUpper()));

                var payload = string.Format(IosPayload, message);
                writer.Write(new byte[] {0, (byte) payload.Length});
                writer.Write(Encoding.UTF8.GetBytes(payload));
                writer.Flush();

                var array = memoryStream.ToArray();
                sslStream.Write(array);
                sslStream.Flush();

                client.Close();
            }
            catch (AuthenticationException)
            {
                client.Close();
                return false;
            }
            catch (Exception)
            {
                client.Close();
                return false;
            }

            return true;
        }

        private bool PushAndroidMessage(string deviceId, string message)
        {
            var responseText = string.Empty;
            var request = WebRequest.Create("https://android.googleapis.com/gcm/send");
            request.Method = "post";
            request.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
            request.Headers.Add(string.Format("Authorization: key={0}", AndroidApiKey));
            request.Headers.Add("Sender: id=9999999999");

            var postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + message +
                "&data.time=" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "&registration_id=" + deviceId + "";
            var byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            if (stream != null)
            {
                using (var reader = new StreamReader(stream))
                {
                    responseText = reader.ReadToEnd();
                }
            }

            response.Close();
            return responseText.StartsWith("id=");
        }

        private byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}