using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EmployeeSystem.Infrastructure.DomainBase;

namespace EmployeeSystem.Infrastructure.RepositoryFramework
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, IEntity
    {
        TEntity FindBy(object ID);
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression predicate);
        IQueryable<TEntity> FindBy(string property, string value);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        int Commit();
    }
}
