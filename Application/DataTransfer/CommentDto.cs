using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class CommentDto: BaseDto 
    {

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Comment name must have at least 3 characters.")]
        public string Text { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifidedAt { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
