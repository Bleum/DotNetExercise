using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Practices.Unity;

namespace EmployeeSystem.Infrastructure.RequestLifeTimeManager
{
    public class HttpRequestLifetimeManager : LifetimeManager
    {
        private readonly Guid key;

        public HttpRequestLifetimeManager()
        {
            key = Guid.NewGuid();
        }

        public override object GetValue()
        {
            return HttpContext.Current.Items[key];
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[key] = newValue;
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(key);
        }
    }
}
