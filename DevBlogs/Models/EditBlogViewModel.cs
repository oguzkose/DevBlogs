using DevBlogs.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlogs.Models
{
    public class EditBlogViewModel
    {
        public Blog Blog { get; set; }

        [Display(Name = "BlogHeaderImage")]
        public IFormFile BlogImage { get; set; }

    }
}
