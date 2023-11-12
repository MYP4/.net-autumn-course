using OnlineCinema.Contex.Entities;
using System.Linq.Expressions;

namespace Repository;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
    T? GetById(int id);
    T? GetByID(Guid id);
    T Save(T entity);
    void Delete(T entity);
}
