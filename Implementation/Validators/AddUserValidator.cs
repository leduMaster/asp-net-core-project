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
            RuleFor(x => x.CreatedAt).NotEmpty().
                 Equal(DateTime.Now)
                 .WithMessage("Username date must be now.");
            RuleFor(u => u.LastName).NotEmpty(); 
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .Must(x => !context.Users.Any(user => user.UserName == x))
                .WithMessage(user => $"Username taken. {user.UserName}");
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
