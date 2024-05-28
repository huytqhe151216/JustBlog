using FA.JustBlock.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Components
{
    public class Category : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public Category(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories();
            return View("/Views/Category/_CategoryMenu.cshtml",categories);
            //return View("/Views/Category/_ListCategory.cshtml", getLastestPost);
        }
    }
}
