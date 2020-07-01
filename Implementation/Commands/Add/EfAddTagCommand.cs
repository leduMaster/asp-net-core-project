using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfAddTagCommand : EfBaseCommand, ICreateTagCommand
    {
        private readonly AddTagValidator _validator;

        public EfAddTagCommand(BlogContext context, AddTagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Add Tag";

        public void Execute(AddTag request)
        {
            _validator.ValidateAndThrow(request);
            var tag = new Domain.Tag
            {
                Content = request.Content,
                CreatedAt = DateTime.Now,
                ModifidedAt = null,
                IsDeleted = false
            };
            if (Context.Tag.Any(t => t.Content == request.Content))
            {
                throw new EntityAllreadyExists("Tag");
            }
            Context.Tag.Add(tag);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
