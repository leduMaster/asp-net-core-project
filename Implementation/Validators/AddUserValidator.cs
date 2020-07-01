using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace Implementation.Validators
{
    public class AddUserValidator : AbstractValidator<AddUser>
    {
        public AddUserValidator(BlogContext context)
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
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
