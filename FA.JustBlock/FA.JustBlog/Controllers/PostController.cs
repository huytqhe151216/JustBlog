using FA.JustBlock.Core.Models;
using FA.JustBlock.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index()
        {
            var listPost = _postRepository.GetAllPosts();
            return View(listPost);
        }
        public IActionResult LatestPost()
        {
            var latestPost = _postRepository.GetLatestPost(5);
            return View(latestPost);
        }   
        public IActionResult Detail(int id)
        {
            var post = _postRepository.FindPost(id);
            return View(post);
        }
        public IActionResult MostViewPosts()
        {
            var mostViewPost = _postRepository.GetMostViewedPost(5);
            return PartialView("_ListPost", mostViewPost);
        }
        [HttpGet("/Post/{year:int}/{month:int}/{title}")]
        public IActionResult Details(int year, int month, string title)
        {
            var post = _postRepository.FindPost(year, month, title);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
