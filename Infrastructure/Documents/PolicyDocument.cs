using System;

namespace Infrastructure.Documents
{
    public class PolicyDocument
    {
        public Guid PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        //public string BusinessName { get; set; }
        public DateTime? PolicyExpirationDate { get; set; }
        public DateTime? PolicyEffectiveDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ClaimNumber { get; set; }
        public string LossControlNumber { get; set; }


    }
}