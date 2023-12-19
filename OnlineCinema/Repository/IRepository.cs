using OnlineCinema.Contex.Entities;
using OnlineCinema.Context.Entities;
using System.Linq.Expressions;

namespace Repository;

public interface IRepository<T> where T : class, IBaseEntity
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
    T? GetById(int id);
    T? GetByGuid(Guid id);
    T Save(T entity);
    void Delete(T entity);
}
