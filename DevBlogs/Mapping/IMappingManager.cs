using DevBlogs.Data.Entities;
using DevBlogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DevBlogs.Mapping
{
    public interface IMappingManager
    {
        Task<Blog> BlogMapping(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);
        Task<BlogIndexViewModel> GetMyBlogs(ClaimsPrincipal claimsPrincipal);
        EditBlogViewModel GetEditBlogViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        Task<EditBlogViewModel> UpdateBlog(EditBlogViewModel editBlogViewModel, ClaimsPrincipal claimsPrincipal);
        HomeIndexViewModel GetHomeIndexViewModel(string searchKeyword, int? page);

        BlogDetailViewModel GetBlogDetail(int? id);
        void Delete(int id);


    }
}
