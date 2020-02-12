using PoocCore.Domain.DTO.Dtos;
using System.Collections.Generic;

namespace PoocCore.Domain.Services
{
    public interface IBookService
    {
        List<BookDto> Get();
        public BookDto Get(string id);
        public BookDto Create(BookDto book);
        public void Update(string id, BookDto bookIn);
        public void Remove(BookDto bookIn);
        public void Remove(string id);
    }
}
