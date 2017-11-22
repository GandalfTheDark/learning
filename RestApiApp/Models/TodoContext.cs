using Microsoft.EntityFrameworkCore;

namespace RestApiApp.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; } // TodoItems is name of the table
    }
}
