namespace Domain
{
    public interface Handles<in TMessage>
    {
        void Handle(TMessage message);
    }
}