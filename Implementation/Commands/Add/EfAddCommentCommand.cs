using System;
using System.Collections.Generic;
using System.Text;
using Application.Exceptions;
using EfDataAccess;
using Application.Commands;
using Application.DataTransfer;
using Implementation.Validators;
using FluentValidation;
using System.Linq;

namespace Implementation.Commands
{
    public class EfAddCommentCommand : EfBaseCommand, ICreateCommentCommand
    {
        private readonly AddCommentValidator _validator;
        public EfAddCommentCommand(BlogContext context, AddCommentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Add Comment";

        public void Execute(AddComment request)
        {
            _validator.ValidateAndThrow(request);
            var com = new Domain.Comment
            {
                Text = request.Text,
                UserId = request.UserID,
                PostId = request.PostId,
                CreatedAt = DateTime.Now,
                ModifidedAt = null,
                IsDeleted = false
            };
            Context.Comments.Add(com);
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
