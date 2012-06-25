using Domain.Model;
using Infrastructure.Providers.Documents;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Infrastructure.Denormalizers
{
    public class InsuarancePolicyDenormalizer : IEventHandler<PolicyCreated>
    {
        public void Handle(PolicyCreated evnt)
        {
            
        }
    }
}