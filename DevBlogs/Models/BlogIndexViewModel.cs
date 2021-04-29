using DevBlogs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlogs.Models
{
    public class BlogIndexViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
