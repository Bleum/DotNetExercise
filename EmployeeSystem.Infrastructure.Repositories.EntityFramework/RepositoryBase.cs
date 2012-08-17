using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using EmployeeSystem.Infrastructure.DomainBase;
using EmployeeSystem.Infrastructure.RepositoryFramework;

namespace EmployeeSystem.Infrastructure.Repositories.EntityFramework
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        private readonly DbContext _context;

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return this.Context.Set<TEntity>();
            }
        }

        public RepositoryBase(DbContext context)
        {
            this._context = context;
        }

        #region IRepository<TEntity> 成员

        public TEntity FindBy(object ID)
        {
            return this.DbSet.Find(ID);
        }

        public IQueryable<TEntity> FindAll()
        {
            return this.DbSet;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return FindAll().Where(predicate);
        }

        public IQueryable<TEntity> FindBy(Expression predicate)
        {
            Expression exp = Expression.Call(typeof(Queryable), "Where",
                new Type[] { typeof(TEntity) }, this.DbSet.AsQueryable().Expression, predicate);
            return this.DbSet.AsQueryable().Provider.CreateQuery<TEntity>(exp);
        }

        public IQueryable<TEntity> FindBy(string property, string value)
        {
            return FindAll().Where(string.Format("{0} = @0", property), value);
        }

        public virtual void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public int Commit()
        {
            try
            {
                return this.Context.SaveChanges();
            }
            catch (SqlException ex)
            {
                foreach (var err in ex.Errors)
                {
                    Trace.WriteLine(err.ToString());
                }
                throw ex;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var err in ex.EntityValidationErrors)
                {
                    Trace.WriteLine(err.ToString());
                }
                throw ex;
            }
        }

        public void RollBack()
        {
            this.Context.ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                this.Context.Dispose();
            }
        }

        #endregion
    }
}
