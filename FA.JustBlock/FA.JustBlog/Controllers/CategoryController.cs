using FA.JustBlock.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Menu()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories;
            return PartialView("_CategoryMenu");
        }
    }
}
