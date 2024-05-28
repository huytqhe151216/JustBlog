using FA.JustBlock.Core.Models;

namespace FA.JustBlock.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JustBlockDbContext _context;
        public CategoryRepository(JustBlockDbContext context)
        {
            _context = context;
        }
        // Delete category by object
        public void DeleteCategory(Category category)
        {
            var categoryExist = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            _context.Categories.Remove(categoryExist);
            _context.SaveChanges();
        }
        // Delete category by id
        public void DeleteCategory(int categoryId)
        {
            var category = Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        // Find category by id
        public Category Find(int CategoryId)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == CategoryId);
        }
        // Get all categories
        public IList<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        // Get category by url slug
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        // Update category
        public void UpdateCategory(Category category)
        {
            var categoryExist = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryExist != null)
            {
                _context.Entry(categoryExist).CurrentValues.SetValues(category);
                _context.SaveChanges();
            }
        }
    }
}
