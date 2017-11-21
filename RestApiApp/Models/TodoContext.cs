﻿using Microsoft.EntityFrameworkCore;

namespace RestApiApp.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; } // TodoItem is name of the table
    }
}
