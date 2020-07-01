using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class AddTagValidator : AbstractValidator<AddTag>
    {
        public AddTagValidator(BlogContext context)
        {
            RuleFor(u => u.Content).NotEmpty().MinimumLength(2).MaximumLength(10);
        }
    }
}
