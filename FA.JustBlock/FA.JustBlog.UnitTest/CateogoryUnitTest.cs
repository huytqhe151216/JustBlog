using FA.JustBlock.Core.Models;
using FA.JustBlock.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class CategoryRepositoryTest
    {
        private JustBlockDbContext _context;
        private ICategoryRepository _categoryRepository;

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
            }
        });
            _context.SaveChanges();

            _categoryRepository = new CategoryRepository(_context);
        }

        [Test]
        public void FindCategoryById_ReturnCategory_Succesfully()
        {
            // Arrange
            int id = 2;
            // Act
            var category = _categoryRepository.Find(id);
            // Assert
            Assert.AreNotEqual(category, null);
        }

        [Test]
        public void GetAllCategories_ReturnCategories_Succesfully()
        {
            // Act
            var categories = _categoryRepository.GetAllCategories();
            // Assert
            Assert.That(categories, Has.Exactly(2).Items);
        }

        [Test]
        public void AddCategory_Successfully()
        {
            // Arrange
            var category = new Category
            {
                Id = 3,
                Name = "Category 3",
                UrlSlug = "UrlSlug Category 3",
                Description = "Description for Category 3"
            };
            // Act
            _categoryRepository.AddCategory(category);
            // Assert
            List<Category> categories = _context.Categories.ToList();
            Assert.That(categories, Has.Exactly(3).Items);
        }

        [Test]
        public void UpdateCategory_Successfully()
        {
            // Arrange
            var updatedCategory = new Category
            {
                Id = 1,
                Name = "Category 1 update",
                UrlSlug = "Updated UrlSlug Category 1",
                Description = "Description for Category 1 update"
            };
            // Act
            _categoryRepository.UpdateCategory(updatedCategory);
            // Assert
            Category category = _context.Categories.FirstOrDefault(x => x.Id == updatedCategory.Id);
            Assert.AreEqual(category.UrlSlug, updatedCategory.UrlSlug);
        }

        [Test]
        public void DeleteCategoryByObject_Successfully()
        {
            // Arrange
            var deleteCategory = new Category
            {
                Id = 1,
                Name = "Category 1",
                UrlSlug = "UrlSlug Category 1",
                Description = "Description for Category 1"
            };
            // Act
            _categoryRepository.DeleteCategory(deleteCategory);
            // Assert
            Category category = _context.Categories.FirstOrDefault(x => x.Id == deleteCategory.Id);
            List<Category> categories = _context.Categories.ToList();
            Assert.AreEqual(category, null);
        }

        [Test]
        public void DeleteCategoryById_Successfully()
        {
            // Arrange
            var id = 1;
            // Act
            _categoryRepository.DeleteCategory(id);
            // Assert
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            List<Category> categories = _context.Categories.ToList();
            Assert.AreEqual(category, null);
            Assert.That(categories, Has.Exactly(1).Items);
        }


        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

    }
}
