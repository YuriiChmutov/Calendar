using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Calendar.Filters.ActionFilters;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Todo : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public Todo(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var items = await _repositoryWrapper.ToDo.FindByCondition(x => !x.IsDone);
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ToDo>> GetItem(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound($"Id {id} is empty");
            }

            var items = await _repositoryWrapper
                .ToDo.FindByCondition(x => x.TodoId == id && !x.IsDone);
            // var item = await _context.Tasks.Where(x => x.TodoId == id && !x.IsDone).SingleOrDefaultAsync();

            var item = items.SingleOrDefault();

            return item is null ? NotFound($"Item with {id} does not exist") : Ok(item);
        }
        
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Todo>> Post([FromBody] ToDo item)
        {
            // item.DateOfCreation = DateTime.Now;
            // item.IsDone = false;
            // item.IsImportant = false;
    
            if (item is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "");
            }

            item.IsDone = false;
            await _repositoryWrapper.ToDo.Create(item);
            _repositoryWrapper.Save();
            return StatusCode(StatusCodes.Status201Created, $"{item.Name} was created successfully");
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task Put(Guid id, [FromBody] ToDo item)
        {
            var itemsFromDb = await 
                _repositoryWrapper.ToDo.FindByCondition(x => 
                    x.TodoId == id && x.IsDone != true);
            var itemFromDb = itemsFromDb.SingleOrDefault();
            
            if (itemFromDb == null)
            {
                throw new Exception("Unable to find the task");
            }
        
            itemFromDb.Name = item.Name;
            itemFromDb.Description = 
                item.Description != null ? item.Description : itemFromDb.Description;
            itemFromDb.DateToFinish =
                item.DateToFinish != DateTime.MinValue ? item.DateToFinish : itemFromDb.DateToFinish;
            itemFromDb.IsDone = item.IsDone;
            itemFromDb.IsImportant = item.IsImportant;

            await _repositoryWrapper.ToDo.Update(itemFromDb);
            _repositoryWrapper.Save();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(Guid id)
        {
            var itemsFromDb = await _repositoryWrapper.ToDo.FindByCondition(x => x.TodoId == id);
            var itemFromDb = itemsFromDb.SingleOrDefault();
            
            if (itemFromDb == null)
            {
                throw new Exception("Unable to find the task");
            }
            
            itemFromDb.IsDone = true;
            await _repositoryWrapper.ToDo.Update(itemFromDb);
            _repositoryWrapper.Save();
        }
    }
}