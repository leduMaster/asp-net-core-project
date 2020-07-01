using Application.Commands;
using Application.DataTransfer;
using Application.Email;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetPostCommand : EfBaseCommand, IGetPostCommand
    {
        private readonly AddUserValidator _validator;
        private readonly IEmailSender _sender;
        public EfGetPostCommand(BlogContext context, AddUserValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id =>16;

        public string Name => "Get One Post";

        public PostDto Execute(int request)
        {
            var qveri = Context.Posts.Include(pt => pt.PostTags).ThenInclude(t => t.Tag).Include(pic=>pic.Pictures).Include(com=>com.Comments).Include(v=>v.Votes);

            var post = Context.Posts.FirstOrDefault(pt=>pt.Id == request);
            if (post == null)
                throw new EntityNotFoundException(request, typeof(PostDto));
            if (post.IsDeleted == true)
                throw new EntityNotFoundException(request, typeof(PostDto));           
            return new PostDto
            {
                id = post.Id,
                Name = post.Name,
                Description = post.Description,
                TagsName = post.PostTags.Select(tg => new TagDto { 
                    Content=tg.Tag.Content
                }),
                Ocene = post.Votes.Select(v => new VotesDto { 
                    Mark = v.Mark
                }),
                Pictures = post.Pictures.Select(pic => new PictureDto { 
                alt = pic.alt,
                src = pic.src
                }),
                Comments = post.Comments.Select(com => new CommentDto { 
                    Text = com.Text,
                    UserId = com.UserId,
                    CreatedAt = com.CreatedAt,
                    ModifidedAt = com.ModifidedAt
                })                
            };
        }
    }
}
