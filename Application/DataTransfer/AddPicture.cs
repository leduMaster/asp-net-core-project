using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class AddPicture
    {
 
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        
        [Required]
        public string Src { get; set; }
        [Required]
        public string Alt { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
