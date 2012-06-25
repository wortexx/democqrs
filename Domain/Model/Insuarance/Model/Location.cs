using System;
using Domain.Model.Primitives;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing;

namespace Domain.Model.Insuarance.Model
{
    public class Location : EntityMappedByConvention<InsuarancePolicy>
    {
        public Location(InsuarancePolicy parent, Guid locationId, string locationName, Address locationAddress) : base(parent, locationId)
        {
            ApplyEvent(new LocationCreated(locationId, locationName, locationAddress));
        }
    }

    #region Events

    public class LocationCreated : SourcedEntityEvent
    {
        public readonly Guid LocationId;
        public readonly string LocationName;
        public readonly Address LocationAddress;

        public LocationCreated(Guid locationId, string locationName, Address locationAddress)
        {
            LocationId = locationId;
            LocationName = locationName;
            LocationAddress = locationAddress;
        }
    }

    #endregion   
}