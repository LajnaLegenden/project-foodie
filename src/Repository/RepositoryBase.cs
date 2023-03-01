//Base for all repositories, inherit this class when creating a new repository.

using System.Linq.Expressions;
using project_foodie.Model;

namespace project_foodie.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public RepositoryBase(DatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    protected DatabaseContext DatabaseContext { get; set; }

    public IQueryable<T> FindAll()
    {
        return DatabaseContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return DatabaseContext.Set<T>().Where(expression);
    }

    public void Create(T entity)
    {
        DatabaseContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        DatabaseContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        DatabaseContext.Set<T>().Remove(entity);
    }
}