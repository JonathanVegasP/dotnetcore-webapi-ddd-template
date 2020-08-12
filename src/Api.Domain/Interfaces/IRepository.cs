using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> insertAsync(T item);

        Task<T> updateAsync(T item);

        Task<bool> deleteAsync(Guid id);

        Task<T> selectAsync(Guid id);

        Task<IEnumerable<T>> selectAsync(int index = 0, int count = 10);
    }
}
