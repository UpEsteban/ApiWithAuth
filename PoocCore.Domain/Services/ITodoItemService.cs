using PoocCore.Domain.DTO.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoocCore.Domain.Services
{
    public interface ITodoItemService
    {
        public Task<TodoItemDto> getItemAsync(string Id);
        public Task deleteItemAsync(TodoItemDto itemDto);
        public Task<TodoItemDto> createItemAsync(TodoItemDto itemDto);
        public Task<ICollection<TodoItemDto>> getAllItemsAsync();
    }
}
