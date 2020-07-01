﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Tag : BaseEntity
    {
        public string Content { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}
