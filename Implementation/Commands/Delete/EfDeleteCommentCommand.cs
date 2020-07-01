using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfDeleteCommentCommand : EfBaseCommand, IDeleteCommentCommand
    {
      
        public EfDeleteCommentCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Delete Commment";

        public void Execute(int request)
        {
            var comDto = Context.Comments.Find(request);

            if (comDto != null)
            {
                try
                {
                    comDto.IsDeleted = true;
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new EntityNotFoundException(request, typeof(CommentDto));
        }
    }
}
