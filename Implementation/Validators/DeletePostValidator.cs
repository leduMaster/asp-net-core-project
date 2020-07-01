using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class DeletePostValidator : AbstractValidator<PostDto>
    {
        public DeletePostValidator(BlogContext context)
        {
            RuleFor(u => u.id).NotEmpty();
            RuleFor(u => u.IsDeleted).NotEmpty();
            //RuleFor(x => x.UserName)
           //     .NotEmpty()
           //     .MinimumLength(3)
            //    .Must(x => !context.Users.Any(user => user.UserName == x))
           //     .WithMessage("Username allready exists.");
          
        }
    }
}
