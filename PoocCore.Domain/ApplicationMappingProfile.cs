using AutoMapper;
using PoocCore.Domain.DTO.Dtos;
using PoocCore.Domain.Models;

namespace PoocCore.Domain
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();

            CreateMap<TodoItemDto, TodoItem>();
            CreateMap<TodoItem, TodoItemDto>();
        }
    }
}
