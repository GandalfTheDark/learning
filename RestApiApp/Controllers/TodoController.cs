using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RestApiApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if(_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem {
                    Name = "Whisky na Coca",
                    IsComplete = "false" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.FromSql("SELECT * FROM TodoItems").ToList();
        }

        [HttpGet("{id}/{pd}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.Where(p => p.Id == id && p.Name == "America").FirstOrDefault();
            if(item == null)
            {
                return new JsonResult(new ReturnMessages { Message = "The data you requested was not found!", Status = "Failed" });
            }
            return new JsonResult(item);
        }

        // this is a POST to add an item on my todo 
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
    }
}
