using FA.JustBlock.Core.Models;
using FA.JustBlock.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    internal class PostUnitTest
    {
        private JustBlockDbContext _context;
        private IPostRepository _postRepository;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<JustBlockDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new JustBlockDbContext(optionsBuilder.Options);

            // Seeding categories
            _context.Categories.AddRange(new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Category 1",
                UrlSlug = "UrlSlug Category 1",
                Description = "Description for Category 1"
            },
            new Category
            {
                Id = 2,
                Name = "Category 2",
                UrlSlug = "UrlSlug Category 2",
                Description = "Description for Category 2"
            } });
            //init post
            _context.Posts.AddRange(
                new List<Post>
                {
                   new Post
                       {
                           Id = 1,
                           Title = "ASP.NET MVC",
                           ShortDescription = "ASP.NET MVC Short Description",
                           PostContent = "ASP.NET MVC Post Content",
                           UrlSlug = "asp-net-mvc",
                           Published = true,
                           PostedOn = System.DateTime.Now,
                           CategoryId = 1,

                       },
                    new Post
                        {
                            Id = 2,
                            Title = "ASP.NET API",
                            ShortDescription = "ASP.NET API Short Description",
                            PostContent = "ASP.NET API Post Content",
                            UrlSlug = "asp-net-api",
                            Published = true,
                            PostedOn = System.DateTime.Now,
                            CategoryId = 1

                        },
                    new Post
                        {
                            Id = 3,
                            Title = "Title",
                            ShortDescription = " Short Description",
                            PostContent = " Post Content",
                            UrlSlug = "asp-net",
                            Published = false,
                            PostedOn = System.DateTime.Now,
                            CategoryId = 1
                        }});
            _context.SaveChanges();

            _postRepository = new PostRepository(_context);
        }
        [Test]
        public void FindPostById_ReturnPost_Succesfully()
        {
            //arrange
            int id = 1;
            //act
            var post = _postRepository.FindPost(id);
            //assert
            Assert.AreNotEqual(post, null);
        }
        [Test]
        public void FindPostByYearMonthUrlSlug_ReturnPost_Succesfully()
        {
            //arrange
            int year = 2024;
            int month = 5;
            string urlSlug = "asp-net-mvc";
            //act
            var post = _postRepository.FindPost(year, month, urlSlug);
            //assert
            Assert.AreNotEqual(post, null);
        }
        [Test]
        public void GetAllPosts_ReturnPosts_Succesfully()
        {
            //act
            var posts = _postRepository.GetAllPosts();
            //assert
            Assert.That(posts, Has.Exactly(3).Items);
        }
        [Test]
        public void GetLatestPost_ReturnLatestPosts_Succesfully()
        {
            //act
            var posts = _postRepository.GetLatestPost(2);
            //assert
            Assert.That(posts, Has.Exactly(2).Items);
        }
        [Test]
        public void GetPostsByCategory_ReturnPosts_Succesfully()
        {
            //arrange
            string category = "Category 1";
            //act
            var posts = _postRepository.GetPostsByCategory(category);
            //assert
            Assert.That(posts, Has.Exactly(3).Items);
        }
        [Test]
        public void GetPostsByMonth_ReturnPosts_Succesfully()
        {
            //arrange
            DateTime monthYear = new DateTime(2024, 5, 14);
            //act
            var posts = _postRepository.GetPostsByMonth(monthYear);
            //assert
            Assert.That(posts, Has.Exactly(3).Items);
        }
        [Test]
        public void GetPublisedPosts_ReturnPosts_Succesfully()
        {
            //act
            var posts = _postRepository.GetPublisedPosts();
            //assert
            Assert.That(posts, Has.Exactly(2).Items);
        }
        [Test]
        public void GetUnpublisedPosts_ReturnPosts_Succesfully()
        {
            //act
            var posts = _postRepository.GetUnpublisedPosts();
            //assert
            Assert.That(posts, Has.Exactly(1).Items);
        }
        [Test]
        public void CountPostsForCategory_ReturnCount_Succesfully()
        {
            //arrange
            int categoryId = 1;
            //act
            var count = _postRepository.CountPostsForCategory(categoryId);
            //assert
            Assert.AreEqual(count, 3);
        }
        [Test]
        public void AddPost_Successfully()
        {
            //arrange
            var post = new Post
            {
                Id = 4,
                Title = "Title 4",
                ShortDescription = " Short Description 4",
                PostContent = " Post Content 4",
                UrlSlug = "url-slug-4",
                Published = true,
                PostedOn = System.DateTime.Now,
                CategoryId = 1
            };
            //act
            _postRepository.AddPost(post);
            //  assert
            List<Post> posts = _context.Posts.ToList();
            Assert.That(posts, Has.Exactly(4).Items);
        }
        [Test]
        public void UpdatePost_Successfully()
        {
            //arrange
            var updatedPost = new Post
            {
                Id = 1,
                Title = "Title 1 update",
                ShortDescription = " Short Description 1 update",
                PostContent = " Post Content 1 update",
                UrlSlug = "url-slug-1",
                Published = true,
                PostedOn = System.DateTime.Now,
                CategoryId = 1
            };
            //act
            _postRepository.UpdatePost(updatedPost);
            //assert
            Post post = _context.Posts.FirstOrDefault(x => x.Id == updatedPost.Id);
            Assert.AreEqual(post.Title, updatedPost.Title);
            Assert.AreEqual(post.ShortDescription, updatedPost.ShortDescription);
            Assert.AreEqual(post.PostContent, updatedPost.PostContent);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

    }
}
