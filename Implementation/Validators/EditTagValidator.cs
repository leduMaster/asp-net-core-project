using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class EditTagValidator : AbstractValidator<AddTag>
    {
        public EditTagValidator(BlogContext context)
        {
            RuleFor(u => u.Content).NotEmpty().MinimumLength(2).MaximumLength(10);
        }
    }
}
