using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSystem.Infrastructure.Utility
{
    public class PagerViewModel
    {
        public int PageCount { get; internal set; }

        public int TotalCount { get; internal set; }

        private int _pageSize = 10;

        public int PageSize
        {
            get 
            {
                return _pageSize; 
            }
            set 
            {
                HttpCookie pageSizeCookie = HttpContext.Current.Response.Cookies["PageSize"];
                pageSizeCookie.Expires = DateTime.MaxValue;
                pageSizeCookie.Value = value.ToString();
                _pageSize = value;
            }
        }

        private int _currentPageIndex = 1;

        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set { _currentPageIndex = value; }
        }
        
        public int? SelectedPageIndex { get; set; }

        public static List<SelectListItem> PageSizeOptions 
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "10", Value = "10", Selected = true },
                    new SelectListItem { Text = "20", Value = "20" },
                    new SelectListItem { Text = "50", Value = "50" },
                    new SelectListItem { Text = "100", Value = "100" }
                };
            }
        }

        public PagerViewModel()
        {
            if (HttpContext.Current.Request.Cookies["PageSize"] != null)
            {
                _pageSize = int.Parse(HttpContext.Current.Request.Cookies["PageSize"].Value);
            }
            else
            {
                HttpCookie pageSizeCookie = new HttpCookie("PageSize", _pageSize.ToString());
                pageSizeCookie.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(pageSizeCookie);
            }
        }
    }
}
