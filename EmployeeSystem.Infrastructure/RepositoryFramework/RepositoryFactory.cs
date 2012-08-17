using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeSystem.Infrastructure.DomainBase;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace EmployeeSystem.Infrastructure.RepositoryFramework
{
    public static class RepositoryFactory
    {
        private static IUnityContainer container;

        public static IUnityContainer Container
        {
            get { return RepositoryFactory.container; }
            set { RepositoryFactory.container = value; }
        }

        static RepositoryFactory()
        {
            container = new UnityContainer();
            container.LoadConfiguration();
        }

        public static TRepository GetRepository<TRepository, TEntity>()
            where TRepository : class, IRepository<TEntity>
            where TEntity : class, IEntity
        {
            return container.Resolve<TRepository>();
        }
    }
}
