using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlock.Core.Models
{
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string UrlSlug { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required] 
        public int Count { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
