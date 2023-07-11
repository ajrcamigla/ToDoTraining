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
    public record GetAllToDoCommand : IRequest<ToDo>;

    public class GetAllToDoCommandHandler //: IRequestHandler<GetToDoByIdCommand, ToDo>
    {
        private readonly IRepository<ToDo> _repository;
        private GetAllToDoCommandHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<List<ToDo>> Handle(GetAllToDoCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
             
        }

    }
}
