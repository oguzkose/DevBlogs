using DevBlogs.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlogs.Service.Test
{
    public class TestHelper
    {
        public static ApplicationDbContext GetContext()
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DevBlogsDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ApplicationDbContext(dbContextOptionBuilder.Options);
           
        }
    }
}
