using System.ServiceModel;

namespace Providers.CommandService
{
    [MessageContract(WrapperName = "ExecuteResponse", WrapperNamespace = Namespaces.NcqrsCommandWebServiceData)]
    public class ExecuteResponse
    {
    }
}