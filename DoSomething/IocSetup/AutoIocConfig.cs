#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using System.Collections.Generic;
using System.Reflection;
using ApiClients.Shared;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SunGardAS.CMS.Service.IocSetup;
using SunGardAS.IocContainer;

namespace DoSomething.IocSetup
{
    public class AutoIocConfig
    {
        public static void Register()
        {
            var container = CreateContainer();

            AutoIoc.Set(container);
        }

        private static IDependencyInjectionContainer CreateContainer()
        {
            var container = new WindsorContainer();

            container.Install(new ServicesInstaller());
            container.Register(Component.For<IClientConfigurationValueProvider>().ImplementedBy<ConfigurationValueProvider>());

            return new WindsorDependencyInjectionContainer(container);
        }
    }

    public class ServicesInstaller : IocAutoInstaller, IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assemblies = new List<Assembly> {GetType().Assembly};
            var iocServicesSetup = new IocServicesSetup();
            assemblies.AddRange(iocServicesSetup.GetAssemblies());
            assemblies.AddRange(Assurance.ApiClients.Scheduler.Client.ApiClientIocSetup.GetAssemblies());
            assemblies.AddRange(Assurance.ApiClients.Security.Client.ApiClientIocSetup.GetAssemblies());
            AutoInstall(container, assemblies.ToArray());
        }
    }
}

