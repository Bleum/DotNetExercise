using System;
using System.Collections.Generic;
using System.Collections;

namespace EmployeeSystem.Infrastructure.Utility
{
    public interface IPager
    {
        PagerViewModel PagerViewModel { get; }
        IEnumerable PagedList { get; }
    }

    public interface IPager<out T> : IPager
    {
        new IEnumerable<T> PagedList { get; }
    }
}
