using MediatR;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;

namespace ToDoTraining.Application.Features
{
    public record GetToDoByIdquery(string Id) : IRequest<ToDo>;

    public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdquery, ToDo>
    {
        private readonly IRepository<ToDo> _repository;

        public GetToDoByIdQueryHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<ToDo> Handle(GetToDoByIdquery request, CancellationToken cancellationToken)
        {
             return await _repository.GetById(request.Id);
        }
    }
}
 