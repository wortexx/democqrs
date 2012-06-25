namespace Primitives
{
    public struct Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateOrProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Address) obj;

            return Line1.Equals(other.Line1) && Line2.Equals(other.Line2) && City.Equals(other.City) &&
                   StateOrProvinceCode.Equals(other.StateOrProvinceCode) && PostalCode.Equals(other.PostalCode)
                   && CountryCode.Equals(other.CountryCode) && Phone.Equals(other.Phone);
        }

        public override int GetHashCode()
        {
            return Line1.GetHashCode() * Line2.GetHashCode();
        }
    }
}