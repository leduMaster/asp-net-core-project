using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class DeleteCommentValidator : AbstractValidator<CommentDto>
    {
        public DeleteCommentValidator(BlogContext context)
        {
            RuleFor(u => u.Text).NotEmpty().MinimumLength(6).WithMessage("Minimalno je 6 karaktera!").MaximumLength(50).WithMessage("Maksimalno je 50 karaktera!");
        }
    }
}
