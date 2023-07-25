using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace ReviewSocial.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
