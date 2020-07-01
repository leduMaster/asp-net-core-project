using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Post : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public IEnumerable<PostTag> PostTags { get; set; }
        public IEnumerable<Votes> Votes { get; set; }
        public ICollection<Comment> Comments{ get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
