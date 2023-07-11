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
            //var toDoList = new List<T>();

            //using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            //{
            //    using (var outputStream = new MemoryStream())
            //    {
            //        toDoList = await session
            //            .Advanced
            //            .LoadStartingWithIntoStreamAsync("todos/", outputStream);

            //    }
            //}
            //return toDoList;
            throw new NotImplementedException();
        }

        public async Task<T> GetById(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                return await session.LoadAsync<T>(id);
            }

        }

        public async Task<T> Update(T entity)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }

            return entity;
        }
    }
}
