#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using SunGardAS.Caching.Ncache.CacheItemGeneration;
using SunGardAS.Caching.NCache;
using SunGardAS.CMS.Domain.DataStore.IncidentManagement.EventDefinition;
using SunGardAS.CMS.Domain.IncidentManagement.EventDefinition;

namespace UnderPressure
{
    public class EventDefinitionProvider : IEventDefinitionProvider
    {
        private readonly IEventDefinitionDataStore _eventDefinitionDataStore;
        private readonly IEventDefinitionHydrator _eventDefinitionHydrator;
        private readonly INcacheProvider _ncacheProvider;

        public EventDefinitionProvider(IEventDefinitionDataStore eventDefinitionDataStore,
            IEventDefinitionHydrator eventDefinitionHydrator, INcacheProvider ncacheProvider)
        {
            _eventDefinitionDataStore = eventDefinitionDataStore;
            _eventDefinitionHydrator = eventDefinitionHydrator;
            _ncacheProvider = ncacheProvider;
        }

        public EventDefinition GetEventDefinition(long eventId, bool useDatabase)
        {
            if (!useDatabase)
            {
                var cacheKey = new NcacheEventDefinitionCacheKey(eventId);
                return _ncacheProvider.Get<EventDefinition>(cacheKey);
            }

            var eventDef = new EventDefinition { EventId = eventId };

            var ds = _eventDefinitionDataStore.GetEventDefinition(eventId);

            if (ds.Tables.Count == 2)
            {
                _eventDefinitionHydrator.HydrateEventDefinition(eventDef, ds);
            }

            return eventDef;
        }
    }

    public interface IEventDefinitionProvider
    {
        EventDefinition GetEventDefinition(long eventId, bool useDatabase);
    }
}
