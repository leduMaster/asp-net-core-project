using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class EditPostValidator : AbstractValidator<AddPost>
    {
        public EditPostValidator(BlogContext context)
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(3);
            RuleFor(u => u.Description).NotEmpty().MinimumLength(13).MaximumLength(210);
        }
    }
}
