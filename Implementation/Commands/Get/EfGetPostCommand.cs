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
        public EfGetPostCommand(BlogContext context, AddUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>16;

        public string Name => "Get One Post";

        public PostDto Execute(int request)
        {
            var qveri = Context.Posts.Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag).Include(p=>p.Pictures)
                .Include(p=>p.Comments).Include(p=>p.Votes);

            var post = qveri.FirstOrDefault(pt=>pt.Id == request);
            if (post == null)
                throw new EntityNotFoundException(request, typeof(PostDto));
            if (post.IsDeleted == true)
                throw new EntityNotFoundException(request, typeof(PostDto));
            var ds = post.PostTags;
             return  new PostDto
            {
                id = post.Id,
                Name = post.Name,
                Description = post.Description,
                TagsName = post.PostTags.Select(tg => new TagDto { 
                   Content=tg.Tag.Content,
                        id = tg.Tag.Id
                 }) ,
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
