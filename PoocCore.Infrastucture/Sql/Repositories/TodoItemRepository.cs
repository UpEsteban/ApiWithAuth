using PoocCore.Domain.Models;
using PoocCore.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoocCore.Infrastucture.Sql.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _dbCotentext;
        public TodoItemRepository(TodoContext todoContext)
        {
            _dbCotentext = todoContext;
        }

        public async Task<TodoItem> createItem(TodoItem itemModel)
        {
            _dbCotentext.Add(itemModel);
            await _dbCotentext.SaveChangesAsync();
            return itemModel;
        }

        public async Task deleteItem(TodoItem itemModel)
        {
            _dbCotentext.Remove(itemModel);
            await _dbCotentext.SaveChangesAsync();
        }

        public async Task<ICollection<TodoItem>> getAllItems()
        {
            return _dbCotentext.TodoItems.ToList();
        }

        public async Task<TodoItem> getItem(string itemId)
        {
            return await _dbCotentext.TodoItems.FindAsync(itemId);
        }
    }
}
