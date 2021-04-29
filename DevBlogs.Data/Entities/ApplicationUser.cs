using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlogs.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public string Nickname { get; set; }

    }
}
