using System.ServiceModel;

namespace Providers.CommandService
{
    [ServiceContract(Namespace = Namespaces.NcqrsCommandWebService)]
    public interface ICommandWebService
    {
        [OperationContract(Action = Namespaces.NcqrsCommandWebService + "ExecuteRequest", ReplyAction = Namespaces.NcqrsCommandWebService + "ExecuteResponse")]
        ExecuteResponse Execute(ExecuteRequest executeRequest);
    }
}