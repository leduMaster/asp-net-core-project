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
    public class EfDeleteTagCommand : EfBaseCommand, IDeleteTagCommand
    {
         public EfDeleteTagCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Delete Tag";

        public void Execute(int request)
        {
            var tagDto = Context.Tag.Find(request);

            if (tagDto != null)
            {
                try
                {
                    tagDto.IsDeleted = true;
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new EntityNotFoundException(request, typeof(TagDto));
        }
    }
}
