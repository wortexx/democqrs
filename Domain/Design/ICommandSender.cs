using Domain.Design;

namespace Domain
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;

    }
}