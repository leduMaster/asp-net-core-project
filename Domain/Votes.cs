using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Votes : BaseEntity
    {
        public int PostId { get; set; }
        public int Mark { get; set; }
        public Post Post{ get; set; }
    }
}
