using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PictureDto : BaseDto
    {
        public string src { get; set; }
        public string alt { get; set; }
        public DateTime CreatedAt {get;set;}
            public DateTime? ModifidedAt
        { get; set; }
            public int PostId { get; set; }
    }
}
