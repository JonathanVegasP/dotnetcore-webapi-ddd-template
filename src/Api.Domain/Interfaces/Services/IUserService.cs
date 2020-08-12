using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> get(Guid id);
        Task<IEnumerable<UserEntity>> getAll(int index = 0, int count = 10);

        Task<UserEntity> post(UserEntity user);
        Task<UserEntity> put(UserEntity user);

        Task<bool> delete(Guid id);
    }
}
