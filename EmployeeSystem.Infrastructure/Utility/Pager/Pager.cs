using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeSystem.Infrastructure.Utility
{
    public class Pager
    {
        /// <summary>
        /// 创建分页对象，支持延迟加载（推荐）
        /// </summary>
        /// <typeparam name="TSource">数据源泛型</typeparam>
        /// <typeparam name="TKey">排序键泛型</typeparam>
        /// <param name="source">需要分页的数据源</param>
        /// <param name="orderByKeySelector">选择排序的键</param>
        /// <param name="isAscending">是否升序</param>
        /// <param name="pagerViewModel">分页视图模型，封装了从视图传递来的参数</param>
        /// <returns>分页对象</returns>
        public static IPager<TSource> GetPager<TSource, TKey>(
            IQueryable<TSource> source, Expression<Func<TSource, TKey>> orderByKeySelector,
            bool isAscending = true, PagerViewModel pagerViewModel = null)
        {
            return Pager<TSource>.GetPager(source, orderByKeySelector, isAscending, pagerViewModel);
        }

        /// <summary>
        /// 创建分页对象，支持延迟加载（推荐）
        /// </summary>
        /// <param name="source">需要分页的数据源（已排序）</param>
        /// <param name="pagerViewModel">分页视图模型，封装了从视图传递来的参数</param>
        /// <returns>分页对象</returns>
        public static IPager<TSource> GetPager<TSource>(IOrderedQueryable<TSource> source, PagerViewModel pagerViewModel = null)
        {
            return Pager<TSource>.GetPager(source, pagerViewModel);
        }

        /// <summary>
        /// 创建分页对象，不支持延迟加载（不推荐）
        /// </summary>
        /// <param name="source">需要分页的数据源（已加载的集合）</param>
        /// <param name="pagerViewModel">分页视图模型，封装了从视图传递来的参数</param>
        /// <returns>分页对象</returns>
        public static IPager<TSource> GetPager<TSource>(List<TSource> source, PagerViewModel pagerViewModel = null)
        {
            return Pager<TSource>.GetPager(source, pagerViewModel);
        }
    }

    class Pager<TSource> : Pager, IPager<TSource>, IPager
    {
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            private set
            {
                _pageSize = value;
            }
        }
        
        public int PageCount
        {
            get
            {
                return (TotalCount + PageSize - 1) / PageSize;
            }
        }

        public int SkipCount
        {
            get
            {
                return CurrentPageIndex != 0 ? (CurrentPageIndex - 1) * PageSize : 0;
            }
        }

        public int TotalCount
        {
            get
            {
                return _source.Count();
            }
        }

        private int _currentPageIndex = 1;

        public int CurrentPageIndex
        {
            get
            {
                return _currentPageIndex;
            }
            internal set
            {
                if (value < 1)
                    _currentPageIndex = PageCount > 0 ? 1 : 0;
                else if (value > PageCount)
                    _currentPageIndex = PageCount;
                else
                    _currentPageIndex = value;
            }
        }

        public PagerViewModel PagerViewModel
        {
            set
            {
                this.PageSize = value.PageSize;
                this.CurrentPageIndex = value.SelectedPageIndex ?? value.CurrentPageIndex;
            }
        }

        PagerViewModel IPager.PagerViewModel
        {
            get
            {
                return new PagerViewModel
                {
                    PageCount = this.PageCount,
                    TotalCount = this.TotalCount,
                    PageSize = this.PageSize,
                    CurrentPageIndex = this.CurrentPageIndex
                };
            }
        }

        IEnumerable<TSource> IPager<TSource>.PagedList
        {
            get 
            {
                return _source.Skip(SkipCount).Take(PageSize).ToList();
            }
        }


        IEnumerable IPager.PagedList
        {
            get
            {
                return _source.Skip(SkipCount).Take(PageSize).ToList();
            }
        }

        private readonly IEnumerable<TSource> _source;

        private Pager(IEnumerable<TSource> source, PagerViewModel pagerViewModel = null)
        {
            _source = source;
            if (pagerViewModel != null)
            {
                this.PagerViewModel = pagerViewModel;
            }
        }

        internal static IPager<TSource> GetPager<TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> orderByKeySelector,
            bool isAscending, PagerViewModel pagerViewModel = null)
        {
            return new Pager<TSource>(
                isAscending ? source.OrderBy(orderByKeySelector) : source.OrderByDescending(orderByKeySelector),
                pagerViewModel);
        }

        internal static IPager<TSource> GetPager(IOrderedQueryable<TSource> source, PagerViewModel pagerViewModel = null)
        {
            return new Pager<TSource>(source, pagerViewModel);
        }

        internal static IPager<TSource> GetPager(List<TSource> source, PagerViewModel pagerViewModel = null)
        {
            return new Pager<TSource>(source, pagerViewModel);
        }
    }
}