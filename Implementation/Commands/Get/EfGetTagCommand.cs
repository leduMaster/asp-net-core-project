using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetTagCommand : EfBaseCommand, IGetTagCommand
    {
        public EfGetTagCommand(BlogContext context) : base(context)
        {
        }

        public int Id =>20;

        public string Name => "Get One Tag";

        public TagDto Execute(int querry)
        {

            var tagDto = Context.Tag.Find(querry);
            if (tagDto != null)
            {
                try
                {
                    return new TagDto
                    {
                        Content = tagDto.Content,
                        id = tagDto.Id,
                        IsDeleted = tagDto.IsDeleted,
                        CreatedAt = tagDto.CreatedAt,
                        ModifiedAt = tagDto.ModifidedAt                      

                    };
                }
                catch (EntityNotFoundException)
                {
                    throw new EntityNotFoundException();
                }
            }
            throw new Exception();
        }
    }
}
