#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using SunGardAS.CMS.Service.IocSetup;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SunGardAS.IocContainer;

namespace UnderPressure
{
    public class IocSetup
    {
        public static void Initialize()
        {
            IocCoreSetup.IsInWebProject = false;

            // Create the DI container
            var container = new WindsorContainer();

            // Setup configuration of DI
            container.Install(new ServicesInstaller());

            // Return our DI container wrapper instance
            var windsorContainer = new WindsorDependencyInjectionContainer(container);
            AutoIoc.Set(windsorContainer);
        }

        public class ServicesInstaller : IocAutoInstaller, IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                var iocSetup = new UnderPressureSetup();
                var assemblies = iocSetup.GetAssemblies();
                AutoInstall(container, assemblies.ToArray());
            }
        }
    }

    public class UnderPressureSetup
    {
        public List<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly> {GetType().Assembly};
            var iocServicesSetup = new IocServicesSetup();
            assemblies.AddRange(iocServicesSetup.GetAssemblies());
            return assemblies;
        }
    }
}
