using Ncqrs.Commanding.ServiceModel;

namespace Infrastructure.Providers.CommandService
{
    public class ThrowOnExceptionInterceptor : ICommandServiceInterceptor
    {
        public void OnBeforeBeforeExecutorResolving(CommandContext context)
        {

        }

        public void OnBeforeExecution(CommandContext context)
        {

        }

        public void OnAfterExecution(CommandContext context)
        {
            if (context != null && context.Exception != null)
                throw context.Exception;
        }
    }
}