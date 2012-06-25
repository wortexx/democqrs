using Domain.Providers;
using Raven.Client;
using Raven.Client.Embedded;

namespace Infrastructure.Providers.Documents
{
    public class RavenDbDocumentProvider : IDocumentProvider
    {
        public RavenDbDocumentProvider()
        {
            
        }
        #region Implementation of IDocumentProvider

        public TDocument Read<TDocument>(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string key, object doc)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }

    

}