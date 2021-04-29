using DevBlogs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogs.Service.BlogService
{
    public interface IBlogService
    {
        Task<Blog> CreateBlog(Blog blog);
        IEnumerable<Blog> GetMyBlogs(ApplicationUser applicationUser);
        Blog GetBlogById(int blogId);
        Task<Blog> Update(Blog blog);
        IEnumerable<Blog> Search(string searchKeyword);
        void Delete(int id);




    }
}
