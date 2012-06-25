using Domain;
using Domain.Design;
using Rhino.ServiceBus;

namespace Infrastructure.Providers.Eventing
{
    public class Bus : ICommandSender, IEventPublisher
    {
        private readonly IServiceBus _bus;

        public Bus(IServiceBus bus)
        {
            _bus = bus;
        }

        #region Implementation of ICommandSender

        public void Send<T>(T command) where T : Command
        {
            _bus.Send(command);
        }

        #endregion

        #region Implementation of IEventPublisher

        public void Publish<T>(T @event) where T : Event
        {
            _bus.Publish(@event);
        }

        #endregion
    }
}