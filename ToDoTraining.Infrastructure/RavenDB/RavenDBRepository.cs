using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTraining.Domain.Entities;
using ToDoTraining.Domain.Interface;

namespace ToDoTraining.Infrastructure.RavenDB
{
    public class RavenDBRepository<T> : IRepository<T>
    {
        public async Task<T> Create(T entity)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }

            return entity;
        }

        public async Task Delete(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                session.Delete(id);
                await session.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task GetById(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                var todo = await session.LoadAsync<T>(id);
            }
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
