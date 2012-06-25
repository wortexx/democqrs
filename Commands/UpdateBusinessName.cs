using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Domain.Commands
{
    [MapsToAggregateRootMethod(typeof(Model.Business), "SetName")]
    public class UpdateBusinessName : CommandBase
    {
        [AggregateRootId]
        public Guid BusinessId { get; set; }
        public string Name { get; set; }
    }
}