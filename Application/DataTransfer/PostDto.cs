using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class PostDto :BaseDto
    {

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Category name must have at least 3 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Category Description must have at least 3 characters.")]
        public string Description { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<TagDto> TagsName { get; set; }
        public IEnumerable<CommentDto> Comments{ get; set; }
        public IEnumerable<VotesDto> Ocene { get; set; }
        public virtual IEnumerable<PictureDto> Pictures { get; set; }
    }
}
