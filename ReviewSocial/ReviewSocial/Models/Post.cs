using System;
using System.Collections.Generic;

#nullable disable

namespace ReviewSocial.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Thumbnail { get; set; }
        public int? View { get; set; }
        public int? TotalReport { get; set; }
        public bool? Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
