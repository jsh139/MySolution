using Assurance.ApiClients.Security.Api;
using Assurance.ApiClients.Security.Client;
using Assurance.ApiClients.Security.Model;
using System;
using AuthApiConfiguration = Assurance.ApiClients.Security.Client.Configuration;

namespace TokenGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = "josh.hoffman@assurancesoftware.com";
            var password = "P@ssword1";
            var vanity = "ldrps";

            if (args.Length > 1)
            {
                userName = args[0];
                password = args[1];

                if (args.Length > 2)
                {
                    vanity = args[2];
                }
            }

            Console.WriteLine("Generating access token...");

            var token = GetToken(userName, password, vanity);

            Console.WriteLine($"Bearer {token.AccessToken}");
        }

        private static AssuranceTokens GetToken(string userName, string password, string vanity)
        {
            var apiConfig = new AuthApiConfiguration(new ApiClient("http://local.assuranceservices.assurancesoftware.com/AidSvc/"));
            var api = new AuthApi(apiConfig);

            var token = api.GetToken("password", "assurance", null, userName, password, vanity);
            return token;
        }
    }
}
