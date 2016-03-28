#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using SunGardAS.CMS.Domain.Caching.IncidentManagement;
using SunGardAS.CMS.Domain.IncidentManagement.EventDefinition;
using SunGardAS.IocContainer;

namespace UnderPressure
{
    public static class EventHelper
    {
        public static EventDefinition GetEventDefinition(long eventId)
        {
            var eventDef = AutoIoc.Get<IEventDefinitionProvider, EventDefinition>(service => service.GetEventDefinition(eventId));
            return eventDef;
        }
    }
}
