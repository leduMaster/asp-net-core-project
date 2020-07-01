using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfCreatePost : EfBaseCommand, ICreatePostCommand 
    {
        private readonly AddpostValidator _validator;
        
        public EfCreatePost(BlogContext context, AddpostValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Creating new post";


        public void Execute(AddPost request)
        {
            _validator.ValidateAndThrow(request);
            var post = new Domain.Post
            {
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                ModifidedAt = null
            };
            if (Context.Posts.Any(p => p.Name == request.Name))
            {
                throw new EntityAllreadyExists("Post");
            }
            Context.Posts.Add(post);
            try
            {
                Context.SaveChanges();
                return;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
