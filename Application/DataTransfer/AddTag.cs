using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class AddTag
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
