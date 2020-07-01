using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class DeleteUserValidator : AbstractValidator<UserDto>
    {
        public DeleteUserValidator(BlogContext context)
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .Must(x => !context.Users.Any(user => user.UserName == x))
                .WithMessage("Username allready exists.");
            
        }
    }
}
