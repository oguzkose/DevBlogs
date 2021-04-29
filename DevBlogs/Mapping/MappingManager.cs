using DevBlogs.Data.Entities;
using DevBlogs.Models;
using DevBlogs.Service.BlogService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using PagedList.Core;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DevBlogs.Mapping
{
    public class MappingManager : IMappingManager
    {
        #region Injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MappingManager(UserManager<ApplicationUser> userManager, IBlogService blogService, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Create Mapping
        public async Task<Blog> BlogMapping(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = createBlogViewModel.Blog;

            blog.Author = await _userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;

            blog = await _blogService.CreateBlog(blog);

            string webRootPath = _webHostEnvironment.WebRootPath;
            string pathToImage = $@"{webRootPath}\UserFiles\Blogs\{blog.Id}\BlogImage.jpg";
            EnsureFolder(pathToImage);
            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createBlogViewModel.BlogImage.CopyToAsync(fileStream);
            }

            return blog;
        }
        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
        #endregion

        #region GetMyBlogs Mapping
        public async Task<BlogIndexViewModel> GetMyBlogs(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            return new BlogIndexViewModel
            {
                Blogs = _blogService.GetMyBlogs(applicationUser)
            };
        }
        #endregion

        #region Edit-Update Mapping
        public EditBlogViewModel GetEditBlogViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            var blogId = id.Value;
            var blog = _blogService.GetBlogById(blogId);
            
            return new EditBlogViewModel
            {
                Blog = blog
            };
        }

        public async Task<EditBlogViewModel> UpdateBlog(EditBlogViewModel editBlogViewModel, ClaimsPrincipal claimsPrincipal)
        {
            var blog = _blogService.GetBlogById(editBlogViewModel.Blog.Id);

            blog.Tag = editBlogViewModel.Blog.Tag;
            blog.Title = editBlogViewModel.Blog.Title;
            blog.Content = editBlogViewModel.Blog.Content;
            blog.CreatedOn = DateTime.Now;

            if (editBlogViewModel.BlogImage != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string pathToImage = $@"{webRootPath}\UserFiles\Blogs\{blog.Id}\BlogImage.jpg";
                EnsureFolder(pathToImage);
                using (var fileStream = new FileStream(pathToImage, FileMode.Create))
                {
                    await editBlogViewModel.BlogImage.CopyToAsync(fileStream);
                }
            }

            return new EditBlogViewModel
            {

                Blog = await _blogService.Update(blog)

            };

        }
        #endregion

        #region Home-Index Search Mapping
        public HomeIndexViewModel GetHomeIndexViewModel(string searchKeyword, int? page)
        {
            int pageSize = 20;
            int pageNumber = page ?? 1;
            var blogs = _blogService.Search(searchKeyword ?? string.Empty);
            return new HomeIndexViewModel
            {
                Blogs = new StaticPagedList<Blog>(blogs.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, blogs.Count()),
                SearchKeyword = searchKeyword,
                PageNumber = pageNumber
            };
        }
        #endregion

        #region Blog-Detail Mapping
        public BlogDetailViewModel GetBlogDetail(int? id)
        {
            var blogId = id.Value;
            var blog = _blogService.GetBlogById(blogId);
            var model = new BlogDetailViewModel
            {
                Blog = blog
            };

            return model;
        }
        #endregion

        #region Blog-Delete Mapping
        public void Delete(int id)
        {
            _blogService.Delete(id);
        } 
        #endregion
    }
}
