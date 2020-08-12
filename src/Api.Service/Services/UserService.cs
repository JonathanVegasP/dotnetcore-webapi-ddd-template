using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> delete(Guid id)
        {
            return await _repository.deleteAsync(id);
        }

        public async Task<UserEntity> get(Guid id)
        {
            return await _repository.selectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> getAll(int index = 0, int count = 10)
        {
            return await _repository.selectAsync(index, count);
        }

        public async Task<UserEntity> post(UserEntity user)
        {
            return await _repository.insertAsync(user);
        }

        public async Task<UserEntity> put(UserEntity user)
        {
            return await _repository.updateAsync(user);
        }
    }
}
