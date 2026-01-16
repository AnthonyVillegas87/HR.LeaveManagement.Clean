using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
  Task<IReadOnlyList<T>> GetAsync();
  Task<T> GetByIdAsync(int id);
  Task UpdateAsync(T entity);
  Task CreateAsync(T entity);
  Task DeleteAsync(T entity);
}