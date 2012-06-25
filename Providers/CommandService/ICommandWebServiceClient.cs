using System.ServiceModel;

namespace Providers.CommandService
{
    public interface ICommandWebServiceClient : ICommandWebService, IClientChannel { }
}