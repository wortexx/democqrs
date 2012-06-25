using Raven.Client;
using Raven.Client.Embedded;

namespace Infrastructure.Providers.Documents
{
    public class DocumentProvider
    {
        private readonly IDocumentSession _session;
        
        public DocumentProvider(IDocumentSession session)
        {
            _session = session;
        }

        public void Write(string key, object document)
        {
            _session.Store(document, key);
            _session.SaveChanges();
        }
    }
}