using DevBlogs.Data;
using DevBlogs.Data.Entities;
using DevBlogs.Service.BlogService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Xunit;

namespace DevBlogs.Service.Test
{
    public class BlogServiceTest
    {

        [Fact]
        #region CreateBlogShouldNotReturnNull
        public void CreateBlogShouldNotReturnNull()
        {
            //Arrange
            var context = TestHelper.GetContext();
            var blogService = new BlogService.BlogService(context);
            var blog = new Blog();

            //Act
            var blogs = blogService.CreateBlog(blog);

            //Assert
            Assert.NotNull(blogs);
        }
        #endregion

        [Fact]
        #region GetMyBlogsShouldNotReturnNull
        public void GetMyBlogsShouldReturnMyBlogs()
        {
            //Arrange
            var context = TestHelper.GetContext();
            var blogService = new BlogService.BlogService(context);
            var appUser = new ApplicationUser();

            //Act
            var myBlogs = blogService.GetMyBlogs(appUser);

            //Assert
            Assert.NotNull(myBlogs);
        }
        #endregion

        [Theory]
        [InlineData(37)]
        [InlineData(38)]
        #region GetBlogByIdShouldReturnExpectedValue
        public void GetBlogByIdShouldReturnExpectedValue(int blogId)
        {
            //Arrange
            var context = TestHelper.GetContext();
            var blogService = new BlogService.BlogService(context);

            //Act
            var blogs = blogService.GetBlogById(blogId);

            //Assert
            Assert.NotNull(blogs);
        }
        #endregion

        [Fact]
        #region UpdateBlogShouldNotReturnNull
        public void UpdateBlogShouldNotReturnNull()
        {
            //Arrange
            var context = TestHelper.GetContext();
            var blogService = new BlogService.BlogService(context);
            var blog = new Blog();
           
            //Act
            var blogToBeUpdated = blogService.Update(blog);

            //Assert
            Assert.NotNull(blogToBeUpdated);
            
        }
        #endregion

        [Theory]
        [InlineData("Lorem ipsum")]
        [InlineData("Marsta yaşam var mı?")]
        [InlineData("gpt 3")]
        #region SearchByKeywordsShouldNotReturnNull
        public void SearchByKeywordsShouldNotReturnNull(string keywords)
        {
            //Arrange
            var context = TestHelper.GetContext();
            var blogService = new BlogService.BlogService(context);

            //Act
            var result = blogService.Search(keywords);

            //Assert
            Assert.NotNull(result);
        }
        #endregion

        [Theory]
        [InlineData("ğ")]
        [InlineData("asdfghjkl")]
        #region SearchByKeywordsShouldReturnEmpty
        public void SearchByKeywordsShouldReturnEmpty(string keywords)
        {
            //Arrange
            var context = TestHelper.GetContext();
            var blogService = new BlogService.BlogService(context);

            //Act
            var result = blogService.Search(keywords);

            //Assert
            Assert.Empty(result);
        }
        #endregion

        //public void Delete(int id)
        //[Fact]
        //public void Delete()
        //{
        //    //Arrange
                     
        //    //Act
           
        //    //Assert
        //}
    }
}
