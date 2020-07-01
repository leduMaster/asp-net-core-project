using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<AddUser>
    {
        public EditUserValidator(BlogContext context)
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3)
                .Must(x => !context.Users.Any(user => user.UserName == x))
                .WithMessage("Username Taken.");
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6);
        }
    }
}
