using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MyContext _context;

        private readonly DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public async Task<bool> deleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));
                if (result == null) return false;
                _dataset.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        public async Task<T> insertAsync(T item)
        {
            try
            {

                if (item.id == Guid.Empty)
                {
                    item.id = Guid.NewGuid();
                }

                item.createdAt = null;
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return item;
        }

        public async Task<T> selectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> selectAsync(int index = 0, int count = 10)
        {
            try
            {
                var result = await _dataset.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> updateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(item.id));
                if (result == null) return null;
                item.updatedAt = null;
                item.createdAt = result.createdAt;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return item;
        }
    }
}
