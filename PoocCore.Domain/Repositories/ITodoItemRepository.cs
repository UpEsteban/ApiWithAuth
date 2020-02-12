using PoocCore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoocCore.Domain.Repositories
{
    public interface ITodoItemRepository
    {
        public Task<TodoItem> getItem(string Id);
        public Task deleteItem(TodoItem itemModel);
        public Task<TodoItem> createItem(TodoItem itemModel);
        public Task<ICollection<TodoItem>> getAllItems();
    }
}
