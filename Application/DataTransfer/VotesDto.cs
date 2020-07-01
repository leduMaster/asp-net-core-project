using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class VotesDto : BaseDto
    {
        public int PostId { get; set; }
        public int Mark { get; set; }
    }
}
