    using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class EditCommentValidator : AbstractValidator<AddComment>
    {
        private readonly BlogContext _context;
        public EditCommentValidator(BlogContext context)
        {
            this._context = context;
            RuleFor(x => x.Text).NotEmpty(); RuleFor(x => x.IsDeleted).NotEmpty();
            // RuleFor(x => x.IsDeleted).Must(CommentNotDeleted);
        }
                
        private bool CommentNotDeleted(int Id)
        {
            var d = _context.Comments.Find(Id);
            if (d.IsDeleted) { return false; } else { return true; }
        }
    }
}
