using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing;
using Primitives;

namespace Domain.Model
{
    public class Business : AggregateRootMappedByConvention
    {
        public string Name { get; protected internal set; }
        
        public Address Address { get; protected internal set; }

        public bool Deleted { get; protected internal set; }

        private ICollection<InsuarancePolicy> _policies;
        public ICollection<InsuarancePolicy> Policies
        {
            get { return _policies ?? (_policies = new Collection<InsuarancePolicy>()); }
            protected internal set { _policies = value; }
        }

        public Business(Guid businessId, string name, Address address)
        {
            ApplyEvent(new BusinessAdded(name, address, businessId));
        }

        public void AddPolicy(Guid policyId, string policyNumber, string claimNumber, string lossControlNumber, 
            DateTime? effectiveDate = null, DateTime? lossDate=null, DateTime? expirationDate=null, DateTime? surveyDate=null)
        {
            var policy = new InsuarancePolicy(this, policyId, policyNumber, claimNumber, lossControlNumber,
                                              effectiveDate, lossDate, expirationDate, surveyDate);

            Policies.Add(policy);
        }

        public void MarkAsDeleted()
        {
            if (!Deleted)
            {
                Deleted = true;
                
                ApplyEvent(new BussinesDeleted());
            }
        }
        
        public void SetName(string name)
        {
            if (Name != name)
            {
                Name = name;

                ApplyEvent(new BusinessNameUpdated(name));
            }
        }

        public void SetAddress(Address address)
        {
            if (!Address.Equals(address))
            {
                Address = address;

                ApplyEvent(new BusinessAddressUpdated(address));
            }
        }
    }

    public class BusinessAddressUpdated : SourcedEvent
    {
        public Address Address { get; set; }

        public BusinessAddressUpdated(Address address)
        {
            Address = address;
        }
    }

    public class BusinessNameUpdated : SourcedEvent
    {
        public string Name { get; set; }

        public BusinessNameUpdated(string name)
        {
            Name = name;
        }
    }

    public class BussinesDeleted : SourcedEvent
    {
    }

    public class BusinessAdded : SourcedEvent
    {
        public Guid BusinessId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public BusinessAdded(string name, Address address, Guid businessId)
        {
            BusinessId = businessId;
            Name = name;
            Address = address;
        }
    }
}