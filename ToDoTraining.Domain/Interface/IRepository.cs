using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTraining.Domain.Interface
{
    public interface IRepository<T>
    {
        Task<T> GetById(string id);

        Task<List<T>> GetAll();

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(string id); 
    }
}
