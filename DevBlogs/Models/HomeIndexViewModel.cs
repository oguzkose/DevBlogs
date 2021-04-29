using DevBlogs.Data.Entities;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlogs.Models
{
    public class HomeIndexViewModel
    {
        public IPagedList<Blog> Blogs { get; set; }
        public string SearchKeyword { get; set; }
        public int PageNumber { get; set; }

    }
}
