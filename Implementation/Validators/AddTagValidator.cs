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
            RuleFor(t => t.Content).NotEmpty().MinimumLength(2).MaximumLength(10); 
            RuleFor(t => t.CreatedAt).NotEmpty().
                 Equal(DateTime.Now)
                 .WithMessage("Tag date must be now.");
            RuleFor(t=>t.Content)
                  .Must((dto, name) => !context.Tag.Any(t => t.Content == name && t.Id != dto.Id))
                  .WithMessage(t => $"Product with the name of {t.Content} already exists in database.");
        }
    }
}
