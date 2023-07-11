using System;
using System.Collections.Generic;

#nullable disable

namespace ReviewSocial.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? PostsId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }

        public virtual Post Posts { get; set; }
        public virtual User User { get; set; }
    }
}
