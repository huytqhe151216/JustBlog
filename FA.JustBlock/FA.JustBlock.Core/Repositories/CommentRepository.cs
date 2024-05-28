using FA.JustBlock.Core.Models;

namespace FA.JustBlock.Core.Repositories
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly JustBlockDbContext _context;
        public CommentRepository(JustBlockDbContext context)
        {
            _context = context;
        }
        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            Comment c = new Comment
            {
                CommentHeader = commentTitle,
                CommentText = commentBody,
                DateComment = System.DateTime.Now,
                Email = commentEmail,
                Name = commentName,
                PostId = postId,

            };
            _context.Comments.Add(c);
            _context.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int commendId)
        {
            var comment = Find(commendId);
            if (comment == null) return;
            DeleteComment(comment);
        }

        public Comment Find(int commentId)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == commentId);
        }

        public IList<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _context.Comments.Where(x => x.PostId == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return GetCommentsForPost(post.Id);
        }

        public void UpdateComment(Comment comment)
        {
            var commentExist = _context.Comments.FirstOrDefault(x => x.Id == comment.Id);
            if (commentExist != null)
            {
                _context.Entry(commentExist).CurrentValues.SetValues(comment);
                _context.SaveChanges();
            }
        }
    }
}
