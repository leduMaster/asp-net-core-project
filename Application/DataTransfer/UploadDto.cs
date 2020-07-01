using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class UploadDto
    {        
        public IFormFile Image { get; set; }
    }
}
