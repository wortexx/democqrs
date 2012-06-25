using System;
using System.Collections.Generic;
using Ncqrs.Eventing.Sourcing;

namespace Domain.Model.Insuarance.Model
{
    public class InsuarancePolicy : Ncqrs.Domain.AggregateRootMappedByConvention
    {
        private readonly Guid _id;
        
        public InsuarancePolicy(Guid id, string policyNumber)
        {
            _id = id;
            ApplyEvent(new InsuarancePolicyCreated(id, policyNumber));
        }

        public void MarkAsDeleted()
        {
            Deleted = true;
            
            ApplyEvent(new InsuarancePolicyDeleted(_id));
        }

        public Guid Id { get { return _id; } }
        public bool Deleted { get; protected set; }
        public ICollection<Location> Locations { get; protected set; }
    }

    #region Events

    public class InsuarancePolicyDeleted : SourcedEvent
    {
        public readonly Guid ID;

        public InsuarancePolicyDeleted(Guid id)
        {
            ID = id;
        }
    }

    public class InsuarancePolicyCreated : SourcedEvent
    {
        public readonly Guid ID;
        public readonly string PolicyNumber;

        public InsuarancePolicyCreated(Guid id, string policyNumber)
        {
            ID = id;
            PolicyNumber = policyNumber;
        }
    }

    #endregion    
}