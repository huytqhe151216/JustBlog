using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlock.Core.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(2000)]
        public string PostContent { get; set; }
        [Required]
        [StringLength(200)]
        public string UrlSlug { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate
        {
            get { return RateCount == 0 ? 0 : TotalRate / RateCount; }
        }
        public virtual Category Category { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
