using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushSharp.Apple;

namespace ConsoleApp
{
    class Program
    {
        private static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        static void Main(string[] args)
        {
            const int port = 2195;
            const string hostname = "gateway.sandbox.push.apple.com";
            var clientCertificate =
                new X509Certificate2(File.ReadAllBytes($"{Environment.CurrentDirectory}\\App_Data\\Certificates (1).p12"), "");
                var certificatesCollection = new X509Certificate2Collection(clientCertificate);
                var client = new TcpClient(hostname, port);
                var sslStream = new SslStream(client.GetStream(), false);
                try
                {
                    sslStream.AuthenticateAsClient(hostname, certificatesCollection, SslProtocols.Tls, false);
                    var memoryStream = new MemoryStream();
                    var writer = new BinaryWriter(memoryStream);
                    writer.Write(new byte[] { 0, 0, 32 });
                    writer.Write(HexStringToByteArray("d74bff321b033bd23487e71d25165f1cc99313040825ce78d073f4ba12ce939c".ToUpper()));
                    var payload = string.Format("{{\"aps\":{{\"alert\":\"{0}\",\"badge\":1,\"sound\":\"default\"}}}}", "hi");
                    writer.Write(new byte[] { 0, (byte)payload.Length });
                    writer.Write(Encoding.UTF8.GetBytes(payload));
                    writer.Flush();
                    var array = memoryStream.ToArray();
                    sslStream.Write(array);
                    sslStream.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                finally
                {
                    client.Close();
                }


                // var certificate = new X509Certificate2("C:\\Users\\jack.stillwell\\Downloads\\PushSharpCert.p12");
                //var certificate =
                //    new X509Certificate2(File.ReadAllBytes("C:\\Users\\josh.hoffman\\Downloads\\PushSharpCert.p12"));
                //var appleConfig = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, certificate, false);
                //appleConfig.InternalBatchSize = 2000;
                //appleConfig.InternalBatchingWaitPeriod = System.TimeSpan.FromMilliseconds(500);
                //var connManager = new ApnsServiceBroker(appleConfig);
                //var notification = new ApnsNotification();
                //notification.DeviceToken = "CDB66775904DFFE078E7FDB76FBBD893C5B6E2A1FFAD0A240955E0A10EEF60E8";
                //notification.Payload = new JObject(
                //                                new JProperty("aps",
                //                                    new JObject(
                //                                        new JProperty("alert",
                //                                            new JObject(
                //                                                new JProperty("title", "test apns message from assurance title"),
                //                                                new JProperty("body", "test apns message from assurance body")
                //                                            )
                //                                        )
                //                                    )
                //                                )
                //                            );
                //connManager.OnNotificationSucceeded += (s) =>
                //{
                //    Console.WriteLine("success for message: {0}", s.Payload["aps"]["alert"]);
                //    Console.WriteLine("hit enter to exit");
                //    Console.ReadLine();
                //};
                //connManager.OnNotificationFailed += (s, e) =>
                //{
                //    Console.WriteLine("failure for message: {0}", s.Payload["aps"]["alert"]);
                //    Console.WriteLine("hit enter to exit");
                //    Console.ReadLine();
                //};
                //connManager.Start();
                //connManager.QueueNotification(notification);
                //Console.WriteLine("hit enter to exit");
                //Console.ReadLine();
            }
    }
}
