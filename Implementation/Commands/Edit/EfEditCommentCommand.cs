using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;
using Application.Exceptions;

namespace Implementation.Commands
{
    public class EfEditCommentCommand : EfBaseCommand, IEditCommentCommand
    {
        private readonly EditCommentValidator _validator;

        public EfEditCommentCommand(BlogContext context, EditCommentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Edit Comment";

        public void Execute(AddComment request)
        {
            _validator.ValidateAndThrow(request);
            var comentDto = Context.Comments.Find(request);
            if (comentDto != null)
            {
                try
                {
                    comentDto.IsDeleted = false;
                    comentDto.ModifidedAt = DateTime.Now;
                    comentDto.PostId = request.PostId;
                    comentDto.UserId= request.UserID;
                    comentDto.Text = request.Text;
                    Context.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            else
            {
                throw new EntityNotFoundException(request.Id, typeof(AddComment));
            }
        }

      
    }
}
