using System;
using System.Collections.Generic;
using Domain;
using Domain.Design;
using Rhino.ServiceBus;
using SimpleCQRS;

namespace Infrastructure.Providers.Eventing
{
    public class Bus : ICommandSender, IEventPublisher
    {
        public void RegisterHandler<T>(Action<T> handler) where T : Message
        {
            List<Action<Message>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<Message>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<Message, T>(x => handler(x)));
        }

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