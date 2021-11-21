﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Todo : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private RepositoryContext _context;

        public Todo(IRepositoryWrapper repositoryWrapper, RepositoryContext context)
        {
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }


        [HttpGet]
        public ActionResult Get()
        {
            var items = _repositoryWrapper.ToDo.FindAll().ToList();
            return Ok(items);
        }

        // [HttpGet]
        // [Route("{id}")]
        // public async Task<ActionResult<ToDo>> GetItem(Guid id)
        // {
        //     if (id == Guid.Empty)
        //     {
        //         return NotFound($"Id {id} is empty");
        //     }
        //
        //     var item = await _context.Tasks.Where(x => x.TodoId == id && !x.IsDone).SingleOrDefaultAsync();
        //
        //     return item is null ? NotFound("Item with id does not exist") : Ok(item);
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult<Todo>> Post()
        // {
        //     var item = new ToDo()
        //     {
        //         Name = "Second item",
        //         IsDone = false,
        //         IsImportant = false,
        //         DateOfCreation = DateTime.Now,
        //         Description = "My second todo item"
        //     };
        //
        //     if (item != null)
        //     {
        //         await _context.AddAsync(item);
        //         await _context.SaveChangesAsync();
        //         return Ok($"New item ({item.Name}) was added");
        //     } 
        //     return NotFound();
        // }
        //
        // [HttpPut]
        // [Route("{id}")]
        // public async Task Put(Guid id, [FromBody] ToDo item)
        // {
        //     var itemFromDb = await _context.Tasks.FindAsync(id);
        //
        //     if (itemFromDb == null)
        //     {
        //         throw new Exception("Unable to find the task");
        //     }
        //
        //     itemFromDb.Name = item.Name;
        //     await _context.SaveChangesAsync();
        // }
        //
        // [HttpDelete]
        // [Route("{id}")]
        // public async Task Delete(Guid id)
        // {
        //     var itemFromDb = await _context.Tasks.FindAsync(id);
        //     
        //     if (itemFromDb == null)
        //     {
        //         throw new Exception("Unable to find the task");
        //     }
        //
        //     itemFromDb.IsDone = true;
        //     await _context.SaveChangesAsync();
        // }
        //
        // // public static Task<IActionResult> GetErrorResponse(Exception ex)
        // // {
        // //     var error = new ProblemDetails
        // //     {
        // //         Title = "An error occurred",
        // //         Detail = _co
        // //     }
        // // }
    }
}