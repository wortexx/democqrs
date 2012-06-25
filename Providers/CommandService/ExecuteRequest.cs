using System.ServiceModel;
using Ncqrs.Commanding;

namespace Providers.CommandService
{
    [MessageContract(WrapperName = "ExecuteRequest", WrapperNamespace = Namespaces.NcqrsCommandWebServiceData)]
    public class ExecuteRequest
    {
        [MessageBodyMember]
        public CommandBase Command { get; set; }

        public ExecuteRequest()
        {

        }

        public ExecuteRequest(CommandBase command)
        {
            Command = command;
        }
    }
}