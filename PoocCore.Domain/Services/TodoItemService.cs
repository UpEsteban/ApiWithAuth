using AutoMapper;
using PoocCore.Domain.DTO.Dtos;
using PoocCore.Domain.Models;
using PoocCore.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoocCore.Domain.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public TodoItemService(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> createItemAsync(TodoItemDto itemDto)
        {
            var item = _mapper.Map<TodoItemDto, TodoItem>(itemDto);
            var itemModel = await _todoItemRepository.createItem(item);
            itemDto.Id = itemModel.Id;
            return itemDto;
        }

        public async Task deleteItemAsync(TodoItemDto itemDto)
        {
            var itemModel = _mapper.Map<TodoItemDto, TodoItem>(itemDto);
            await _todoItemRepository.deleteItem(itemModel);
        }

        public async Task<ICollection<TodoItemDto>> getAllItemsAsync()
        {
            var itemModel = await _todoItemRepository.getAllItems();
            var itemDto = _mapper.Map<List<TodoItem>, List<TodoItemDto>>(itemModel.ToList());
            return itemDto;
        }

        public async Task<TodoItemDto> getItemAsync(string Id)
        {
            var itemModel = await _todoItemRepository.getItem(Id);
            if (itemModel == null)
                return null;
            var itemDto = _mapper.Map<TodoItem, TodoItemDto>(itemModel);
            return itemDto;
        }
    }
}
