using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMain.Repostories
{
    public interface IGenericRepostory<T> where T:BaseEntity,new()
    {
        IQueryable<T> GetAll();
        Task<T>GetByIdAsync(int id);
        IQueryable<T> GetWhere(Func<T, bool> expression);
        Task <bool> IsExistAsync(int id);
        Task AddAsync(T entity);
        void Remove(T entity);
        Task<bool> RemoveAsync(int id);
        Task<int> SaveAsync(); 

    }
}
