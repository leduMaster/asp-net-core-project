using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PostTag : BaseDto
    {
        public PostDto PostId { get; set; }
        public TagDto TagId { get; set; }
        public ICollection<TagDto> Tags { get; set; }
        public ICollection<PostDto> Posts { get; set; }
    }
}
