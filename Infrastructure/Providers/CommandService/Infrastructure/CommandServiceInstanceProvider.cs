using System;
using System.Diagnostics.Contracts;
using System.ServiceModel.Dispatcher;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;

namespace Infrastructure.Providers.CommandService.Infrastructure
{
    internal class CommandServiceInstanceProvider : IInstanceProvider
    {
        public CommandServiceInstanceProvider(Type serviceType)
        {
            if (typeof(CommandWebService) != serviceType)
            {
                throw new InvalidOperationException("The Provider can only be used with the Ncqrs.CommandService.CommandWebService service type.");
            }
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            Contract.Assume(instanceContext != null);
            return new CommandWebService(NcqrsEnvironment.Get<ICommandService>());
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            Contract.Assume(instanceContext != null);
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
        }
    }
}