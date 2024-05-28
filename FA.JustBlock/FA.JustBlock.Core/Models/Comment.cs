using System.ComponentModel.DataAnnotations;

namespace FA.JustBlock.Core.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime DateComment { get; set; }
        public virtual Post Post { get; set; }
    }
}
