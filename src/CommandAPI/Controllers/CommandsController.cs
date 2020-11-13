using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;

        // Class constructor gets called when we want to use the controller.
        // When the Constructor is called, the DI system will spring into action and inject
        // the required dependency when we ask for an instance of ICommandAPIRepo
        // This is Constructor Dependency Injection
        public CommandsController(ICommandAPIRepo repository)
        {
            // assign injected dependency
            _repository = repository;
        }


        // 1. The controller action responds to the GET verb
        // 2. The controller action should return an enumeration of Command objects
        // 3. We call GetAllCommands and populate a local variable with result
        // 4. We return a HTTP 200 Result (OK) and pass back our result set
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        // Additional Route Parameter "id"
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(commandItem);
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string []{"this","is","hard","coded"};
        // }
    }
}