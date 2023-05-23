using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstractions
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<T>> ListAsync(Func<T, bool> filter);
        public Task AddAsync(T entity, CancellationToken cancellationToken = default);
        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}
