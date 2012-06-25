namespace Domain.Model.Primitives
{
    public struct Address
    {
        public string Lines { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set;}
        public string CountryCode { get; set; }
    }
}