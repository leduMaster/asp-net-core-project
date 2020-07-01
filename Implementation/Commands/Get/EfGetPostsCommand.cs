using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetPostsCommand : EfBaseCommand, IGetPostsCommand
    {
        public EfGetPostsCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Get All Post";

        public Pagination<PostDto> Execute(PostSearch request)
        {
            var query = Context.Posts.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(p => p.Name
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.IsDeleted.HasValue)
            {
                query = query.Where(p => p.IsDeleted != request.IsDeleted);
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<PostDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag)
                .Select(p => new PostDto
                {
                    id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    TagsName = p.PostTags.Select(pt => new TagDto { 
                    Content = pt.Tag.Content,
                        id = pt.Tag.Id
                    })
                })
            };
        }
    }
}
