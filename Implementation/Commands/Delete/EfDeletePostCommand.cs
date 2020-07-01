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
    public class EfDeletePostCommand : EfBaseCommand, IDeletePostCommand
    {
        
        public EfDeletePostCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Delete Post";

        public void Execute(int request)
        {
            var postDto = Context.Posts.Find(request);

            if (postDto != null)
            {
                try
                {
                    postDto.IsDeleted = true;
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new EntityNotFoundException(request, typeof(PostDto));
        }
    }
}
