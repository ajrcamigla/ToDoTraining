using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;

namespace ToDoTraining.Application.Features
{
    public record DeleteToDoCommand(string Id) : IRequest<Unit>;

    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, Unit>
    {
        private readonly IRepository<ToDo> _repository;

        public DeleteToDoCommandHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);

            return Unit.Value;
        }
    }
    
}
