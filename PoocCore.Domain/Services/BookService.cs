using AutoMapper;
using PoocCore.Domain.DTO.Dtos;
using PoocCore.Domain.Models;
using PoocCore.Domain.Repositories;
using System.Collections.Generic;

namespace PoocCore.Domain.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public BookDto Create(BookDto bookDto)
        {
            var book = _mapper.Map<BookDto, Book>(bookDto);
            bookDto.Id = _bookRepository.Create(book).Id;
            return bookDto;
        }

        public List<BookDto> Get()
        {
            var books = _bookRepository.Get();
            return _mapper.Map<List<Book>, List<BookDto>>(books);
        }

        public BookDto Get(string id)
        {
            var book = _bookRepository.Get(id);
            return _mapper.Map<Book, BookDto>(book);
        }

        public void Remove(BookDto bookIn)
        {
            var book = _mapper.Map<BookDto, Book>(bookIn);
            _bookRepository.Remove(book);
        }

        public void Remove(string id)
        {
            _bookRepository.Remove(id);
        }

        public void Update(string id, BookDto bookIn)
        {
            var book = _mapper.Map<BookDto, Book>(bookIn);
            _bookRepository.Update(id, book);
        }
    }
}
