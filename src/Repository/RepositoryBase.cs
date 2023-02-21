//Base for all repositories, inherit this class when creating a new repository.
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using project_foodie.Model;

namespace project_foodie.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext DatabaseContext { get; set; }
        public RepositoryBase(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public IQueryable<T> FindAll() => DatabaseContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DatabaseContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => DatabaseContext.Set<T>().Add(entity);

        public void Update(T entity) => DatabaseContext.Set<T>().Update(entity);

        public void Delete(T entity) => DatabaseContext.Set<T>().Remove(entity);
    }
}