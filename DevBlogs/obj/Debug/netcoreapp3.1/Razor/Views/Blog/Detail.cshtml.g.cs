#pragma checksum "C:\Users\Oğuz KÖSE\source\repos\DevBlogs\DevBlogs\Views\Blog\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32941568a5728fe22223d2a40a16f6964115e9ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Detail), @"mvc.1.0.view", @"/Views/Blog/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Oğuz KÖSE\source\repos\DevBlogs\DevBlogs\Views\_ViewImports.cshtml"
using DevBlogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oğuz KÖSE\source\repos\DevBlogs\DevBlogs\Views\_ViewImports.cshtml"
using DevBlogs.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32941568a5728fe22223d2a40a16f6964115e9ef", @"/Views/Blog/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6db9cad569de2b4ea5bc6d8fc319a56b97d82779", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Oğuz KÖSE\source\repos\DevBlogs\DevBlogs\Views\Blog\Detail.cshtml"
  

    Layout = "~/Views/Blog/_DetailLayout.cshtml";
    ViewData["HeaderImage"] = $"../../UserFiles/Blogs/{Model.Blog.Id}/BlogImage.jpg";
    ViewData["HeaderTitle"] = Model.Blog.Title;
    ViewData["Author"] = Model.Blog.Author.Nickname;
    ViewData["Date"] = Model.Blog.CreatedOn;

    

    


#line default
#line hidden
#nullable disable
            WriteLiteral("<article>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-8 col-md-10 mx-auto\">\r\n                ");
#nullable restore
#line 19 "C:\Users\Oğuz KÖSE\source\repos\DevBlogs\DevBlogs\Views\Blog\Detail.cshtml"
           Write(Html.Raw(Model.Blog.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</article>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
