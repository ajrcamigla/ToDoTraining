using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;

namespace ToDoTraining.Application.Features
{
    public record GetAllToDoQuery : IRequest<List<ToDo>>;

    public class GetAllToDoQueryHandler : IRequestHandler<GetAllToDoQuery, List<ToDo>>
    {
        private readonly IRepository<ToDo> _repository;
        public GetAllToDoQueryHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<List<ToDo>> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
             
        }

    }
}
