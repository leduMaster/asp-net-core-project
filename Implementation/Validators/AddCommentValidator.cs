using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Domain;

namespace Implementation.Validators
{
    public class AddCommentValidator : AbstractValidator<AddComment>
    {
        private readonly BlogContext _context;
        public AddCommentValidator(BlogContext context)
        {
            this._context = context;
            RuleFor(x => x.Text).NotEmpty(); RuleFor(x => x.IsDeleted).NotEmpty();
            RuleFor(x=>x.CreatedAt).NotEmpty().
                Equal(DateTime.Now)
                .WithMessage("Comment date must be now.");
             //RuleFor(x => x.IsDeleted).Must(CommentNotDeleted);
        }
        private bool CommentNotDeleted(int Id)
        {
            var d =  _context.Comments.Find(Id);
            if (d.IsDeleted) { return false; } else { return true; }
        }
    }
}
