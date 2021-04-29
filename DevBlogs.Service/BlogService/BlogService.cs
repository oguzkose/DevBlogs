using DevBlogs.Data;
using DevBlogs.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlogs.Service.BlogService
{
    public class BlogService : IBlogService
    {
        #region Injection
        private readonly ApplicationDbContext _context;
        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CreateBlog()
        public async Task<Blog> CreateBlog(Blog blog)
        {
            _context.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }     
        #endregion

        #region GetMyBlogs()
        public IEnumerable<Blog> GetMyBlogs(ApplicationUser applicationUser)
        {
            return _context.Blogs.OrderByDescending(blog=>blog.CreatedOn)
                .Include(blog => blog.Author)
                .Where(blog => blog.Author == applicationUser);
            
        }
        #endregion

        #region GetBlogById()
        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs
                .Include(blog=>blog.Author)
                .FirstOrDefault(blog => blog.Id == blogId);
        }
        #endregion

        #region Update()
        public async Task<Blog> Update(Blog blog)
        {
            _context.Update(blog);
            await _context.SaveChangesAsync();
            return blog;
        }
        #endregion

        #region Search()
        public IEnumerable<Blog> Search(string searchKeyword)
        {
            return _context.Blogs.OrderByDescending(blog => blog.CreatedOn)
                .Include(blog => blog.Author)
                .Where(blog => blog.Content.Contains(searchKeyword) ||
                blog.Title.Contains(searchKeyword) ||
                blog.Tag.Contains(searchKeyword));

        }
        #endregion

        #region Delete()
        public void Delete(int id)
        {

            var entity = _context.Blogs.FirstOrDefault(blog => blog.Id == id);
            _context.Blogs.Remove(entity);
            _context.SaveChanges();
        } 
        #endregion
    }
}
