using Domain.Design;

namespace Domain
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}