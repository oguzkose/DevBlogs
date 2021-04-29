using DevBlogs.Data.Entities;
using DevBlogs.Mapping;
using DevBlogs.Models;
using DevBlogs.Service;
using DevBlogs.Service.BlogService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DevBlogs.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        #region Injection
        private readonly IMappingManager _mappingManager;
        public BlogController(IMappingManager mappingManager)
        {
            _mappingManager = mappingManager;

        }
        #endregion

        #region Index Action
        public async Task<IActionResult> Index()
        {
            var model = await _mappingManager.GetMyBlogs(User);
            return View(model);
        }
        #endregion

        #region Create Action (GetMethod)
        public IActionResult Create()
        {
            return View(new CreateBlogViewModel());
        }
        #endregion

        #region Create Action (PostMethod)
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogViewModel model)
        {
            await _mappingManager.BlogMapping(model, User);
            return RedirectToAction(nameof(Index), "Home");

        }
        #endregion

        #region Edit Action (GetMethod)
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var model = _mappingManager.GetEditBlogViewModel(id, User);
            if (model is null)
            {
                return NotFound();
            }
            return View(model);
        }
        #endregion

        #region Edit Action (PostMethod)
        [HttpPost]
        public async Task< IActionResult> Edit(EditBlogViewModel editBlogViewModel)
        {
           
           var entity =await _mappingManager.UpdateBlog(editBlogViewModel,User);
            
            return RedirectToAction(nameof(Index), "Home"); 
            //return View(entity);
        }
        #endregion

        #region Detail Action
        [Route("Detail/{id}"),AllowAnonymous]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = _mappingManager.GetBlogDetail(id);
            return View(model);
        }
        #endregion

        #region Delete Action
        public IActionResult Delete(int id)
        {
            _mappingManager.Delete(id);

            return RedirectToAction(nameof(Index), "Blog");
        } 
        #endregion


    }
}
