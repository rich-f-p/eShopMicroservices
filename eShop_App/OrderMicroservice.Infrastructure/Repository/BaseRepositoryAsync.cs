using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.Repository;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly OrderMicroDbContext context;

        public BaseRepositoryAsync(OrderMicroDbContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return (int)entity.GetType().GetProperty("Id").GetValue(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
