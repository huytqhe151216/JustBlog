using FA.JustBlock.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlock.Core.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly JustBlockDbContext _context;
        public PostRepository(JustBlockDbContext context)
        {
            _context = context;
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public int CountPostsForCategory(int categoryId)
        {
            var category= _context.Categories.Include(x=>x.Posts).FirstOrDefault(x => x.Id == categoryId);
            if (category == null) return 0;
            return category.Posts.Count;
            
        }

        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = FindPost(postId);
            if(post == null) return;
            DeletePost(post);
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts.FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug == urlSlug);
            
        }

        public Post FindPost(int postId)
        {
            return _context.Posts.FirstOrDefault(x => x.Id == postId);
        }

        public IList<Post> GetAllPosts()
        {
            return _context.Posts.Include(x=>x.Tags).Include(x=>x.Category).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _context.Posts.OrderByDescending(x => x.Rate).Take(size).ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return _context.Posts.OrderByDescending(x => x.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return _context.Posts.OrderByDescending(x => x.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return _context.Posts.Include(x=>x.Category).Where(x => x.Category.Name == category).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _context.Posts.Where(x => x.PostedOn.Month == monthYear.Month && x.PostedOn.Year == monthYear.Year).ToList();
        }

        public IList<Post> GetPublisedPosts()
        {
            return _context.Posts.Where(x => x.Published).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return _context.Posts.Where(x => !x.Published).ToList();
        }

        public void UpdatePost(Post post)
        {
            var postExist = _context.Posts.FirstOrDefault(x => x.Id == post.Id);
            if (postExist != null)
            {
                _context.Entry(postExist).CurrentValues.SetValues(post);
                _context.SaveChanges();
            }
        }
    }
}
