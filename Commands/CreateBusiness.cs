using System;
using Domain.Model;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Primitives;

namespace Commands
{
    [MapsToAggregateRootConstructor(typeof(Business))]
    public class CreateBusiness : CommandBase
    {
        public Guid BusinessId { get; set; }
        public string Name { get; set;}
        public Address Address { get; set; }
    }
}