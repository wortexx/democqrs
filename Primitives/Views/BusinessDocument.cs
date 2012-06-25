using System;

namespace Primitives.Views
{
    public class BusinessDocument
    {
        public Guid BusinessId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        
        public static string GetKey(Guid businessId)
        {
            return "BusinessDocument/" + businessId;
        }
        
    }
}