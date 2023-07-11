using MediatR;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;

namespace ToDoTraining.Application.Features
{
    public record CreateToDoCommand(string Title, string Description, DateTime? DueDate) : IRequest<ToDo>;

    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDo>
    {
        private readonly IRepository<ToDo> _repository;
        public CreateToDoCommandHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<ToDo> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = new ToDo
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                CreationDate = DateTime.UtcNow,
            };

            return await _repository.Create(todo);
        }
    }
    
}
