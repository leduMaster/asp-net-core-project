using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class AddpostValidator : AbstractValidator<AddPost>
    {
        public AddpostValidator(BlogContext context)
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(3); RuleFor(x => x.CreatedAt).NotEmpty().
                 Equal(DateTime.Now)
                 .WithMessage("Comment date must be now.");
            RuleFor(u => u.Description).NotEmpty().MinimumLength(13).MaximumLength(210);
        }
    }
}
