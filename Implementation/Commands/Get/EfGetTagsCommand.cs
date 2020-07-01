using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetTagsCommand : EfBaseCommand, IGetTagsCommand
    {
        public EfGetTagsCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Get All Tags";

        public Pagination<TagDto> Execute(TagSearch request)
        {
            var query = Context.Tag.AsQueryable();
            if (request.Keyword != null)
            {
                query = query.Where(t => t.Content.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (request.IsDeleted.HasValue)
            {
                query = query.Where(t => t.IsDeleted == request.IsDeleted);
            }
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<TagDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(t => new TagDto
                {
                    id = t.Id,
                    Content = t.Content,
                    IsDeleted = t.IsDeleted,
                    CreatedAt = t.CreatedAt,
                    ModifiedAt = t.ModifidedAt                    
                })
            };


        }
    }
}
