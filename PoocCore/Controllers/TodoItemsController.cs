using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoocCore.Domain.DTO.Dtos;
using PoocCore.Domain.Services;

namespace PoocCore.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            var itemsDto = await _todoItemService.getAllItemsAsync();
            return itemsDto.ToList();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(string id)
        {
            var todoItem = await _todoItemService.getItemAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemDto todoItem)
        {
            var itemDto = await _todoItemService.createItemAsync(todoItem);
            return itemDto;
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemDto>> DeleteTodoItem(string id)
        {
            var todoItem = await _todoItemService.getItemAsync(id);
            await _todoItemService.deleteItemAsync(todoItem);

            todoItem = await _todoItemService.getItemAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
