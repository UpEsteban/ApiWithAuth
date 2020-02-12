using Microsoft.EntityFrameworkCore;
using PoocCore.Domain.Models;

namespace PoocCore.Infrastucture.Sql
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
    : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
