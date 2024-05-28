using FA.JustBlock.Core.Models;
namespace FA.JustBlock.Core.Repositories
{
    public interface ICategoryRepository
    {
        Category Find(int CategoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void DeleteCategory(int categoryId);
        IList<Category> GetAllCategories();
    }
}
