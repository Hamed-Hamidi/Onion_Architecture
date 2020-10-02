using System;
using System.Collections.Generic;
using System.Text;
using Onion.Data.Common;

namespace Onion.Repository.DataTransfer
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
