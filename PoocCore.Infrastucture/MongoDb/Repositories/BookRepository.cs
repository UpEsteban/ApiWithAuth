using MongoDB.Driver;
using PoocCore.Domain.Models;
using PoocCore.Domain.Repositories;
using System.Collections.Generic;
using static PoocCore.Infrastucture.MongoDb.BookContext;

namespace PoocCore.Infrastucture.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _bookContext;
        public BookRepository(IBookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<Book> Get() =>
            _bookContext.Book().Find(book => true).ToList();

        public Book Get(string id) =>
             _bookContext.Book().Find(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _bookContext.Book().InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
             _bookContext.Book().ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) =>
             _bookContext.Book().DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
             _bookContext.Book().DeleteOne(book => book.Id == id);
    }
}
