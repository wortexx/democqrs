using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing;

namespace Domain.Model
{
    public class InsuarancePolicy : EntityMappedByConvention<Business>
    {
        public InsuarancePolicy(Business parent, Guid entityId, string policyNumber, string claimNumber, string lossControlNumber, 
            DateTime? effectiveDate = null, DateTime? lossDate=null, DateTime? expirationDate=null, DateTime? surveyDate=null) : base(parent, entityId)
        {
            PolicyNumber = policyNumber;
            ClaimNumber = claimNumber;
            LossControlNumber = lossControlNumber;
            EffectiveDate = effectiveDate;
            LossDate = lossDate;
            ExpirationDate = expirationDate;
            SurveyDate = surveyDate;

            ApplyEvent(new PolicyCreated(policyNumber, claimNumber, lossControlNumber));
        }
        
        [StringLength(50)]
        public string PolicyNumber { get; internal protected set; }

        [StringLength(50)]
        public string ClaimNumber { get; internal protected set; }
        
        [StringLength(50)]
        public string LossControlNumber { get; internal protected set; }
         
        /// <summary>
        ///  Policy Effective Date
        /// </summary>
        public DateTime? EffectiveDate { get; protected internal set; }

         /// <summary>
         ///  Policy Loss Date
         /// </summary>
        public DateTime? LossDate { get; protected internal set; }

         /// <summary>
         /// Expiration date
         /// </summary>
        public DateTime? ExpirationDate { get; protected internal set; }

         /// <summary>
         ///  Survey Date
         /// </summary>
        public DateTime? SurveyDate { get; protected internal set; }

        public string Source { get; set; }

         public virtual bool Deleted { get; internal protected set; }

        //public IEnumerable<Location> Locations { get; protected internal set; }

        // public void MarkAsDeleted()
        // {
        //     if (!Deleted)
        //     {
        //         Deleted = true;

        //         foreach (var location in Locations)
        //         {
        //             location.MarkAsDeleted();
        //         }

        //         ApplyEvent(new PolicyDeleted());
        //     }
        // }

    }

    public class PolicyCreated : SourcedEntityEvent
    {
        public readonly string PolicyNumber;
        public readonly string ClaimNumber;
        public readonly string LossControlNumber;

        public PolicyCreated(string policyNumber, string claimNumber, string lossControlNumber)
        {
            PolicyNumber = policyNumber;
            ClaimNumber = claimNumber;
            LossControlNumber = lossControlNumber;
        }
    }

    public class PolicyDeleted : SourcedEntityEvent
    {
        
    }
}