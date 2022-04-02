using Microsoft.AspNetCore.Mvc;
using Rover.Models;
using Rover.Services;

namespace Rover.Controllers

{
    [ApiController]
    [Route("rover")]
    public class MainController : ControllerBase
    {
        private readonly ICommands _commandsService;

        public MainController(ICommands commandsService)
        {
            _commandsService = commandsService;
            
            _commandsService.Init(10,10, 'N', 20,20);
        }

        [HttpPost("set")]
        public int Set(RequestCommands request)
        {
     
            return _commandsService.Execute(request.Commands.ToCharArray());
           
        }
    }
}