using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTraining.Application.Features;
using ToDoTraining.Domain.Entities;

namespace ToDoTraining.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : ControllerBase
    {
        private readonly ILogger<ToDosController> _logger;
        private readonly IMediator _mediator;

        public ToDosController(ILogger<ToDosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ToDo> Create([FromBody] CreateToDoCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<ToDo> GetById([FromRoute] string id)
        {
            return await _mediator.Send(new GetToDoByIdquery(id));
        }

        [HttpPut("{id}")]
        public async Task<ToDo> Update([FromRoute] string Id, [FromBody] UpdateToDoRequest request )
        {
            return await _mediator.Send(new UpdateToDoCommand(Id, request.Title, request.Description, request.DueDate));
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] string id)
        {
            await _mediator.Send(new DeleteToDoCommand(id));
        }
    }
}