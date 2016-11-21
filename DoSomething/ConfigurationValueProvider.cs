#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using ApiClients.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DoSomething
{
    public class ConfigurationValueProvider : IClientConfigurationValueProvider
    {
        private readonly Dictionary<string, ClientConfiguration> _clientConfigurations;
        public ConfigurationValueProvider()
        {
            var baseUrl = ConfigurationManager.AppSettings["AssuranceServicesBaseUrl"];
            _clientConfigurations = new Dictionary<string, ClientConfiguration>
            {
                {
                    "Assurance.ApiClients.Scheduler", new ClientConfiguration
                    {

                        Url = baseUrl + ConfigurationManager.AppSettings["SchedulerServiceUrl"],
                        UserAgent = "AssuranceServices"
                    }
                },
                {
                    "Assurance.ApiClients.Security", new ClientConfiguration
                    {

                        Url = baseUrl + ConfigurationManager.AppSettings["IdentityServiceUrl"],
                        UserAgent = "AssuranceServices"
                    }
                },
            };
        }

        public ClientConfiguration ConfigurationFor(string apiName)
        {
            if (!_clientConfigurations.ContainsKey(apiName))
                throw new InvalidOperationException("Attempted to access unsupported API: " + apiName);

            return _clientConfigurations[apiName];
        }
    }
}
