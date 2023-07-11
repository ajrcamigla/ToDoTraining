using MediatR;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;

namespace ToDoTraining.Application.Features
{
    public record GetToDoByIdquery(string Id) : IRequest<Unit>;

    public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdquery, Unit>
    {
        private readonly IRepository<ToDo> _repository;

        public GetToDoByIdQueryHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(GetToDoByIdquery request, CancellationToken cancellationToken)
        {
            await _repository.GetById(request.Id);

            return Unit.Value;
        }
    }
}
 