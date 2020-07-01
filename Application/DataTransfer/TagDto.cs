using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class TagDto : BaseDto 
    {
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<PostTag> PostTags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}