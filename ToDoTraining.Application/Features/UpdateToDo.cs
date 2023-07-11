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
    public record UpdateToDoRequest(string Title, string Description, DateTime? DueDate);

    public record UpdateToDoCommand(string Id, string Title, string Description, DateTime? DueDate) : IRequest<ToDo>;

    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, ToDo>
    {
        private readonly IRepository<ToDo> _repository;

        public UpdateToDoCommandHandler(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public async Task<ToDo> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var existingToDo = await _repository.GetById(request.Id);

            if (existingToDo != null)
            {
                existingToDo.Title = request.Title;
                existingToDo.Description = request.Description;
                existingToDo.DueDate = request.DueDate;

                return await _repository.Update(existingToDo);
            }

            return null;

        }
    }
}
