namespace Domain.Providers
{
    public interface IDocumentProvider
    {
        TDocument Read<TDocument>(string key);
        void Write(string key, object doc);
        void Delete(string key);

    }
}