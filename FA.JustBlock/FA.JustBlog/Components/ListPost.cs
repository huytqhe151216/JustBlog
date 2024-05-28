using FA.JustBlock.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Components
{
    public class ListPost : ViewComponent
    {
        private readonly IPostRepository _postRepository;

        public ListPost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IViewComponentResult Invoke(string type, int size = 5)
        {
            switch (type)
            {
                case "MostViewedPosts":
                    var getMostViewPost = _postRepository.GetMostViewedPost(size);
                    ViewBag.PartialViewTitle = "Most viewed Posts";
                    return View("/Views/Post/_ListPost.cshtml",getMostViewPost);
                case "LastestPosts":
                    var getLastestPost = _postRepository.GetLatestPost(size);
                    ViewBag.PartialViewTitle = "Lastest Posts";
                    return View("/Views/Post/_ListPost.cshtml",getLastestPost);
                default:
                    break;
            }
            return View();
        }
    }
}
