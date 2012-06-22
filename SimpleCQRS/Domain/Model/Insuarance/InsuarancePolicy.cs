using System;
using SimpleCQRS.Domain.Design;

namespace SimpleCQRS.Domain.Model.Insuarance
{
    public class InsuarancePolicy : AggregateRoot
    {
        public bool Deleted { get; protected internal set; }

        private long _id;
        
        public void Delete()
        {
            if (!Deleted)
            {
                Deleted = true;

                ApplyChange(new InsuarancePolicyDeleted(Id));
            }
        }
        
        public string PolicyNumber { get; protected internal set; }
        public string ClaimNumber { get; protected  internal set; }
        public string LossControllNumber { get; protected internal set; }
        public string LossControlNumber { get; protected internal set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? LossDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        ///  Survey Date
        /// </summary>
        public DateTime? SurveyDate { get; set; }


        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName");
            ApplyChange(new InventoryItemRenamed(_id, newName));
        }

        public void Remove(int count)
        {
            if (count <= 0) 
                throw new InvalidOperationException("cant remove negative count from inventory");
            ApplyChange(new ItemsRemovedFromInventory(_id, count));
        }


        public void CheckIn(int count)
        {
            if(count <= 0) 
                throw new InvalidOperationException("must have a count greater than 0 to add to inventory");
            ApplyChange(new ItemsCheckedInToInventory(_id, count));
        }

        public void Deactivate()
        {
            if(!_activated) throw new InvalidOperationException("already deactivated");
            ApplyChange(new InventoryItemDeactivated(_id));
        }

        public override long Id
        {
            get { return _id; }
        }

        public InsuarancePolicy()
        {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }

        public InsuarancePolicy(long id, string policyNumber, string claimNumber, string lossControllNumber)
        {
            PolicyNumber = policyNumber;
            ClaimNumber = claimNumber;
            LossControllNumber = lossControllNumber;
            _id = id;
            ApplyChange(new InsuarancePolicyCreated(id, policyNumber, claimNumber, lossControllNumber));
        }
    }

    public class InsuarancePolicyCreated : Event
    {
        public long Id { get; set; }
        public string PolicyNumber { get; set; }
        public string ClaimNumber { get; set; }
        public string LossControllNumber { get; set; }

        public InsuarancePolicyCreated(long id, string policyNumber, string claimNumber, string lossControllNumber)
        {
            Id = id;
            PolicyNumber = policyNumber;
            ClaimNumber = claimNumber;
            LossControllNumber = lossControllNumber;
        }
    }
    public class InsuarancePolicyDeleted : Event
    {
        public InsuarancePolicyDeleted(long id)
        {
            PolicyId = id;
        }

        public long PolicyId { get; private set; }
    }
}

