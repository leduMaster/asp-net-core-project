using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Picture : BaseEntity
    {
        public string src { get; set; }
        public string alt { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
