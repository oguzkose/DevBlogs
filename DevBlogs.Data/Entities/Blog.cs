using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevBlogs.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Tag { get; set; }
        

    }
}
