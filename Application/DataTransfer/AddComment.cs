using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class AddComment
    {
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Comment name must have at least 3 characters.")]
        public string Text { get; set; }        
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
