#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using SunGardAS.Caching.NCache;
using SunGardAS.CMS.Domain.Config;

namespace UnderPressure
{
    public class NcacheConfig
    {
        public static void Setup()
        {
            var configHelper = new GlobalDatabaseConfigOptionManager();
            NcacheContainer.Initialize(configHelper.GetNcacheCacheId());
        }
    }
}
