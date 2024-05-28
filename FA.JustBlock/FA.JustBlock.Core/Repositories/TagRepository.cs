using FA.JustBlock.Core.Models;

namespace FA.JustBlock.Core.Repositories
{
    public class TagRepository : ITagReppository
    {
        private readonly JustBlockDbContext _context;
        public TagRepository(JustBlockDbContext context)
        {
            _context = context;
        }
        public void AddTag(Tag Tag)
        {
            _context.Tags.Add(Tag);
            _context.SaveChanges(); 
        }

        public void DeleteTag(Tag Tag)
        {
            _context.Tags.Remove(Tag);
            _context.SaveChanges();
        }

        public void DeleteTag(int TagId)
        {
            var existTag = Find(TagId);
            if (existTag != null)
            {
                _context.Tags.Remove(existTag);
                _context.SaveChanges();
            }
        }

        public Tag Find(int TagId)
        {
           return _context.Tags.FirstOrDefault(x => x.Id == TagId);
        }

        public IList<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.FirstOrDefault(x => x.UrlSlug == urlSlug);
        }

        public void UpdateTag(Tag Tag)
        {
            var tagExist = _context.Posts.FirstOrDefault(x => x.Id == Tag.Id);
            if (tagExist != null)
            {
                _context.Entry(tagExist).CurrentValues.SetValues(Tag);
                _context.SaveChanges();
            }
        }
    }
}
