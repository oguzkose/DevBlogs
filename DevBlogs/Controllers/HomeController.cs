using DevBlogs.Mapping;
using DevBlogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlogs.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMappingManager _mappingManager;
        public HomeController(IMappingManager mappingManager)
        {
            _mappingManager = mappingManager;
        }
        public IActionResult Index(string searchKeyword, int? page)
        {
            
            return View(_mappingManager.GetHomeIndexViewModel(searchKeyword,page));
        }
        //public IActionResult Detail(int? id)
        //{
        //    var model = _mappingManager.GetBlogDetail(id);
        //    return View(model);
        //}


    }
}
