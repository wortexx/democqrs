using System;

namespace Primitives.Views
{
    public class PolicyDocument
    {
        public Guid PolicyId { get; set; }
        
        public string PolicyNumber { get; set; }
        
        public string ClaimNumber { get; set; }
        
        public string LossControlNumber { get; set; }
        
        public DateTime? PolicyExpirationDate { get; set; }
        
        public DateTime? PolicyEffectiveDate { get; set; }

        public BusinessDetails Owner { get; set; }

        public static string GetKey(Guid policyId)
        {
            return "PolicyDocument/" + policyId;
        }
        
    }
}