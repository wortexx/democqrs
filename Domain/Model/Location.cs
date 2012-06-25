//using Ncqrs.Eventing.Sourcing;

//namespace Domain.Model
//{
//    public class Location : Ncqrs.Domain.EntityMappedByConvention
//    {
//        public string LocationName { get; set; }
//        public string LocationNumber { get; set; }
//        public bool IsHeadquarter { get; set; }

//        /*public Location(InsuarancePolicy parent, Guid entityId, string locationName, string locationNumber,  bool isHeadquarter) 
//        {
//            LocationName = locationName;
//            LocationNumber = locationNumber;
//            IsHeadquarter = isHeadquarter;

//            ApplyEvent(new LocationCreated(locationName, locationNumber, isHeadquarter));
//        }*/

//        public string Name { get; protected internal set; }
//        public string Number { get; protected internal set; }
//        public bool IsHeadquarters { get; protected internal set; }
//        public bool Deleted { get; protected internal set; }
        
//        public void SetName(string number)
//        {
//            if (Name != number)
//            {
//                Name = number;

//                ApplyEvent(new LocationNameChanged(number));
//            }
//        }

//        public void SetNumber(string number)
//        {
//            if (Number != number)
//            {
//                Number = number;

//                ApplyEvent(new LocationNumberChanged(number));
//            }
//        }

//        public void MarkAsDeleted()
//        {
//            if (!Deleted)
//            {
//                ApplyEvent(new LocationDeleted());
//            }
//        }
//    }

//    public class LocationNumberChanged : SourcedEntityEvent
//    {
//        public readonly string Number;

//        public LocationNumberChanged(string number)
//        {
//            Number = number;
//        }
//    }

//    public class LocationNameChanged : SourcedEntityEvent
//    {
//        public readonly string Name;

//        public LocationNameChanged(string name)
//        {
//            Name = name;
//        }
//    }

//    public class LocationCreated : SourcedEntityEvent
//    {
//        public readonly string LocationName;
//        public readonly string LocationNumber;
//        public readonly bool IsHeadquarter;

//        public LocationCreated(string locationName, string locationNumber, bool isHeadquarter)
//        {
//            LocationName = locationName;
//            LocationNumber = locationNumber;
//            IsHeadquarter = isHeadquarter;
//        }
//    }

//    public class LocationDeleted : SourcedEntityEvent
//    {
//    }
//}