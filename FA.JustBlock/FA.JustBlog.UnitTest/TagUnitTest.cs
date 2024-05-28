using FA.JustBlock.Core.Models;
using FA.JustBlock.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    internal class TagUnitTest
    {
        private JustBlockDbContext _context;
        private ITagReppository _tagReppository;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<JustBlockDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new JustBlockDbContext(optionsBuilder.Options);
            _context.Tags.AddRange(new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "ASP.NET",
                    UrlSlug = "asp-net",
                    Description = "ASP.NET Tag",
                    Count = 1
                },
                new Tag
                {
                    Id = 2,
                    Name = "C#",
                    UrlSlug = "c-sharp",
                    Description = "C# Tag",
                    Count = 2
                },
                new Tag
                {
                    Id = 3,
                    Name = "SQL Server",
                    UrlSlug = "sql-server",
                    Description = "Description",
                    Count = 3

                }
            });
            _context.SaveChanges();

            _tagReppository = new TagRepository(_context);
        }
        [Test]
        public void FindTagById_ReturnTag_Succesfully()
        {
            int id = 2;

            var tag = _tagReppository.Find(id);

            Assert.AreNotEqual(tag, null);
        }
        [Test]
        public void GetAllTags_ReturnTags_Succesfully()
        {
            //act
            var tags = _tagReppository.GetAllTags();
            //assert
            Assert.That(tags, Has.Exactly(3).Items);
        }
        [Test]
        public void AddTag_Successfully()
        {
            //arrange
            var tag = new Tag
            {
                Id = 4,
                Name = "Tag 4",
                UrlSlug = "UrlSlug Tag 4",
                Description = "Description for Tag 4",
                Count = 4
            };
            //act
            _tagReppository.AddTag(tag);
            //assert
            var tagInDb = _tagReppository.Find(4);
            Assert.AreEqual(tag, tagInDb);
        }
        [Test]
        public void DeleteTag_Successfully()
        {
            //arrange
            var tag = _tagReppository.Find(1);
            //act
            _tagReppository.DeleteTag(tag);
            //assert
            var tagInDb = _tagReppository.Find(1);
            Assert.AreEqual(tagInDb, null);
        }
        [Test]
        public void DeleteTagById_Successfully()
        {
            //act
            _tagReppository.DeleteTag(1);
            //assert
            var tagInDb = _tagReppository.Find(1);
            Assert.AreEqual(tagInDb, null);
        }


        [Test]
        public void GetTagByUrlSlug_ReturnTag_Succesfully()
        {
            //arrange
            string urlSlug = "asp-net";
            //act
            var tag = _tagReppository.GetTagByUrlSlug(urlSlug);
            //assert
            Assert.AreNotEqual(tag, null) ;
        }
        [Test]
        public void GetTagByUrlSlug_ReturnNull()
        {
            //arrange
            string urlSlug = "asp-net-1";
            //act
            var tag = _tagReppository.GetTagByUrlSlug(urlSlug);
            //assert
            Assert.AreEqual(tag, null);
        }


        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
