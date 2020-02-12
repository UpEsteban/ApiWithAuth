using MongoDB.Driver;
using PoocCore.Domain.Models;
using static PoocCore.Infrastucture.MongoDb.BookContext;

namespace PoocCore.Infrastucture.MongoDb
{
    public class BookContext : IBookContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IBookstoreDatabaseSettings _settings = null;

        public BookContext(IBookstoreDatabaseSettings settings)
        {
            _settings = settings;
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Book> Book()
        {
            return _database.GetCollection<Book>(_settings.BooksCollectionName);
        }

        public interface IBookContext
        {
            public IMongoCollection<Book> Book();
        }
    }
}
