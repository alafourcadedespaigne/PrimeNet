using System.Linq.Expressions;
using PrimeNet.Domain;
using PrimeNet.Domain.Common;

namespace PrimeNet.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : BaseDomainModel
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);
    
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T,object>>> includes = null,
        bool disableTracking = true);

    Task<T> GetByIdAsync(int id);

    Task<T> AddAsync(T Entity);
    
    Task<T> UpdateAsync(T Entity);
    
    Task<T> DeleteAsync(T Entity);
}