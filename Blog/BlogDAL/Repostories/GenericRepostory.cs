using BlogDAL.Context;
using BlogMain.Entites.Common;
using BlogMain.Repostories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Repostories
{
    public class GenericRepostory<T>(AppDbContext _sql) : IGenericRepostory<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table => _sql.Set<T>();
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public IQueryable<T> GetAll()
        {
            Table.AsQueryable();
            return Table;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            await Table.FindAsync(id);
            return Table;

        }

        public IQueryable<T> GetWhere(Func<T, bool> expression)
        {
            Table.Where(expression).AsQueryable();
            return Table;
        }

        public async Task<bool> IsExistAsync(int id)
        {
            await Table.AnyAsync(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            int result = await Table.Where(x => x.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<int> SaveAsync()
        {
            await _sql.SaveChangesAsync();
        }
    }
}
