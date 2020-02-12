using PoocCore.Domain.Models;
using System.Collections.Generic;

namespace PoocCore.Domain.Repositories
{
    public interface IBookRepository
    {
        List<Book> Get();
        public Book Get(string id);
        public Book Create(Book book);
        public void Update(string id, Book bookIn);
        public void Remove(Book bookIn);
        public void Remove(string id);
    }
}
