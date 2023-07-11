using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTraining.Domain.Entities;

namespace ToDoTraining.Infrastructure.RavenDB
{
    public class TodoRepository : RavenDBRepository<ToDo>
    {
    }
}
