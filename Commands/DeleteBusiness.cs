using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Domain.Commands
{
    [MapsToAggregateRootMethod(typeof(Model.Business), "MarkAsDeleted")]
    public class DeleteBusiness : CommandBase
    {
        [AggregateRootId]
        public Guid BusinessId { get; set; }
    }
}